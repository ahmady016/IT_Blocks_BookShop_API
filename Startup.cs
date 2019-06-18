using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json;
using AutoMapper;
using Web_API.EntityModels;

namespace Web_API
{
  public class Startup
  {
    private readonly IConfiguration _config;
    private readonly string _title;
    private readonly string _version;

    public Startup(IConfiguration config)
    {
      _config = config;
      _title = _config.GetValue<string>("API:Title");
      _version = _config.GetValue<string>("API:Version");
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      // get the DI
      BaseHelpers.DI = services;
      // AddScoped configures settings to create new instance of this type per http request
      services.AddScoped<BaseService>();
      // Add automapper
      services.AddAutoMapper(typeof(Startup).Assembly);
      // Register a type of DbContext so that it can be used in DI (inside dependent classes' constructors)
      services.AddDbContext<BookStoreContext>();
      // Configure Swagger
      services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = _title, Version = _version }));
      // Allow CORS
      services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
        {
          builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        }));
      // JWT Authentication
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = UserHelpers.GetTokenValidationOptions(validateLifetime: true);
          options.Events = new JwtBearerEvents()
          {
            OnAuthenticationFailed = context =>
            {
              if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                context.Response.Headers.Add("Token-Expired", "true");
              return Task.CompletedTask;
            }
          };
        });
      // configure MVC options
      services.AddMvc(config => config.Filters.Add(typeof(ApiExceptionFilterAttribute)))
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
        .AddJsonOptions(options =>
        {
          options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
          options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      // Exception Page [Error Page]
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();
      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{_title} {_version}"));
      // Shows UseCors with CorsPolicyBuilder.
      app.UseCors("CorsPolicy");
      // using JWT Authentication
      app.UseAuthentication();
      // global exception handler
      app.UseExceptionHandler(appError =>
      {
        appError.Run(async context =>
        {
          context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          context.Response.ContentType = "application/json";
          var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
          if (contextFeature != null)
            await context.Response.WriteAsync(JsonConvert.SerializeObject(contextFeature.Error));
        });
      });
      // using MVC
      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
