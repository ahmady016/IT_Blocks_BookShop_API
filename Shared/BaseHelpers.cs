using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Web_API.ViewModels;

namespace Web_API
{
  public static class BaseHelpers
  {
    // get the DI [Dependency Injection Services]
    public static IServiceCollection DI { get; set; }
    // Get DI Service<T>
    public static T GetService<T>() => DI.BuildServiceProvider().GetService<T>();
  }
}