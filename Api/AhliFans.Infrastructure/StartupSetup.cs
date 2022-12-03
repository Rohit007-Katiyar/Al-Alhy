using AhliFans.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AhliFans.Infrastructure;

  public static class StartupSetup
  {
      public static void AddDbContext(this IServiceCollection services, string connectionString) =>
          services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(connectionString,x=> x.MigrationsAssembly("AhliFans.WebApi"))); // will be created in web project root
  }
