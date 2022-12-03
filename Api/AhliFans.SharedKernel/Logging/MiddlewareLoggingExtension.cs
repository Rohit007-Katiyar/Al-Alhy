using Microsoft.AspNetCore.Builder;

namespace AhliFans.SharedKernel.Logging;
public static class MiddlewareLoggingExtension
{
  public static void UseAppException(this IApplicationBuilder builder)
  {
    builder.UseMiddleware<ErrorHandler>();
  }
}
