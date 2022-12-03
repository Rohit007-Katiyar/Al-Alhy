using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AhliFans.SharedKernel.Logging;
public class ErrorHandler
{
  private readonly RequestDelegate _requestDelegate;
  private readonly ILogger _logFactory;

  public ErrorHandler(RequestDelegate requestDelegate,ILoggerFactory logFactory)
  {
     _requestDelegate = requestDelegate;
    _logFactory = logFactory.CreateLogger("MyMiddleware");
  }

  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _requestDelegate(context);
      try
      {
        var userId = context.User?.Claims.First(i => i.Type == "User Id").Value;
        var methodVerb = context.Request?.Method;
        var endPointNme = context.Request?.Path;
        _logFactory.LogInformation($"User[{userId}] try to [{methodVerb}]  [{endPointNme}] ");
      }
      catch 
      {
        var methodVerb = context.Request?.Method;
        var endPointNme = context.Request?.Path;
        _logFactory.LogInformation($"User try to [{methodVerb}]  [{endPointNme}] ");
      }

    }
    catch (Exception ex)
    {
      //context.Response.StatusCode = 500;
      var errorLog = new ErrorLogger()
      {
        ErrorDetails = $"{ex.InnerException?.Message!}-----{ex.Message}",
        StatusCode = context.Response.StatusCode,
        EndPointName = context.Request?.Path!,
      };
      _logFactory.LogError(errorLog.ToString());
      //throw ex;
    }
  }
}
