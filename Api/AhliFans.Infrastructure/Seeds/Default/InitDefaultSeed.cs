using System.Security.Claims;
using AhliFans.Core;
using AhliFans.Core.Feature.Security.Entities;
using AhliFans.Core.Feature.Security.Enums.RoleClaims;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AhliFans.Infrastructure.Seeds.Default;
public class InitDefaultSeed
{
  public static async Task Initialize(IServiceProvider serviceProvider)
  {
    using var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);
    var roleManager = serviceProvider.GetService<RoleManager<Role>>();
    var userManager = serviceProvider.GetService<UserManager<User>>();

    if (roleManager != null)
    {
      var admin = new Role(Roles.Admin.ToString());
      var fan = new Role(Roles.Fan.ToString());
      var administratorManager = new Role(Roles.AdministratorManager.ToString());
      var fanManager = new Role(Roles.FanManager.ToString());
      var notificationManager = new Role(Roles.NotificationManager.ToString());
      var teamManager = new Role(Roles.TeamManager.ToString());
      var matchCenterManager = new Role(Roles.MatchCenterManager.ToString());
      var preferencesManager = new Role(Roles.PreferencesManager.ToString());

      if (!await roleManager.RoleExistsAsync(admin.Name))
        await roleManager.CreateAsync(admin);

      if (!await roleManager.RoleExistsAsync(fan.Name))
        await roleManager.CreateAsync(fan);

      if (!await roleManager.RoleExistsAsync(administratorManager.Name))
      {
        await roleManager.CreateAsync(administratorManager);

        foreach (var claim in Enum.GetValues(typeof(AdministratorManagerClaims)))
          await roleManager.AddClaimAsync(administratorManager,
            new Claim("Permission", claim.ToString()!));
      }

      if (!await roleManager.RoleExistsAsync(fanManager.Name))
      {
        await roleManager.CreateAsync(fanManager);

        foreach (var claim in Enum.GetValues(typeof(FanManagerClaims)))
          await roleManager.AddClaimAsync(fanManager,
            new Claim("Permission", claim.ToString()!));
      }

      if (!await roleManager.RoleExistsAsync(notificationManager.Name))
      {
        await roleManager.CreateAsync(notificationManager);

        foreach (var claim in Enum.GetValues(typeof(NotificationManagerClaims)))
          await roleManager.AddClaimAsync(notificationManager,
            new Claim("Permission", claim.ToString()!));
      }

      if (!await roleManager.RoleExistsAsync(teamManager.Name))
      {
        await roleManager.CreateAsync(teamManager);

        foreach (var claim in Enum.GetValues(typeof(TeamManagerClaims)))
          await roleManager.AddClaimAsync(teamManager,
            new Claim("Permission", claim.ToString()!));
      }

      if (!await roleManager.RoleExistsAsync(matchCenterManager.Name))
      {
        await roleManager.CreateAsync(matchCenterManager);

        foreach (var claim in Enum.GetValues(typeof(MatchCenterManagerClaims)))
          await roleManager.AddClaimAsync(matchCenterManager,
            new Claim("Permission", claim.ToString()!));
      }

      if (!await roleManager.RoleExistsAsync(preferencesManager.Name))
      {
        await roleManager.CreateAsync(preferencesManager);

        foreach (var claim in Enum.GetValues(typeof(PreferencesManagerClaims)))
          await roleManager.AddClaimAsync(preferencesManager,
            new Claim("Permission", claim.ToString()!));
      }
    }

    var rootAdmin = new Admin()
    {
      FullName = RootAdmin.UserName,
      IsSuperAdmin = true,
      IsActive = false,
      UserName = RootAdmin.UserName,
      Email = RootAdmin.Email,
      PhoneNumber = RootAdmin.PhoneNumber,
    };

    await userManager!.CreateAsync(rootAdmin, RootAdmin.Password);
    await userManager.AddToRoleAsync(rootAdmin, Roles.Admin.ToString());

    var user = await userManager.FindByEmailAsync(RootAdmin.Email);
    var userClaims = await userManager.GetClaimsAsync(user);

    if (userClaims.Any(x => x.Type == "RootAdmin") is false)
      await userManager.AddClaimAsync(user, new Claim("RootAdmin", "Root"));

    SeedData(dbContext);
  }
  public static void SeedData(AppDbContext dbContext)
  {
    dbContext.SaveChanges();
  }
}
