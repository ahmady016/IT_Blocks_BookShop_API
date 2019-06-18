using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web_API
{
  public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
  {
    public override void OnException(ExceptionContext actionContext)
    {
      actionContext.Result = new BadRequestObjectResult(actionContext.Exception);
    }
  }
}
