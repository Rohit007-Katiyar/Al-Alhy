using Microsoft.Extensions.DependencyInjection;

namespace AhliFans.Infrastructure.UserClaims;

public static class DefaultClaims
{
  public static void AddClaims(this IServiceCollection services)
  {
    //delete admin policy
    services.AddAuthorization(options => 
      options.AddPolicy("CanDeleteAdmin",
        policy=>policy.RequireClaim("DeleteAdmin"))
    );
  }
}
