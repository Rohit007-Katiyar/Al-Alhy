using System.IdentityModel.Tokens.Jwt;
using AhliFans.Core.Feature.Security.Login.Admin.DTO;
using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.Login.Admin.Events;
public class LoginEventHandler : IRequestHandler<LoginEvent,ActionResult>
{
  private readonly LoginEventValidator _validator;
  private readonly IRepository<Entities.Admin> _adminRepo;
  private readonly JWTToken _jwtToken;
  private readonly UserManager<Entities.Admin> _userManager;

  public LoginEventHandler(LoginEventValidator validator, JWTToken jwtToken, IRepository<Entities.Admin> adminRepo, UserManager<Entities.Admin> userManager)
  {
    _validator = validator;
    _jwtToken = jwtToken;
    _adminRepo = adminRepo;
    _userManager = userManager;
  }
  public async Task<ActionResult> Handle(LoginEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validator.ValidateAsync(request, cancellationToken);

    if (!validation.IsValid)
    {
       return new BadRequestObjectResult(new AdminResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage).Distinct()), ResponseStatus.Error));
    }
    var admin = await GetAdmin(request, cancellationToken);
    if (admin is null || !await _userManager.CheckPasswordAsync(admin, request.Password) || admin.IsBlocked)
    {
      return new BadRequestObjectResult(new AdminResponse("The user name or password may be incorrect", ResponseStatus.Error));
    }

    JwtSecurityToken jwtSecurityToken;
    if (admin.IsActive)
    {
      //token for active user
      jwtSecurityToken = await _jwtToken.CreateJwtToken(admin,isRoot:admin.IsSuperAdmin);
      var token = new TokenDto(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo, $"Welcome Admin{ admin.FullName}!", ResponseStatus.Warning);
      return new OkObjectResult(token);
    }

    jwtSecurityToken = await _jwtToken.CreateJwtToken(admin, RootAdmin.IsActive, isRoot: admin.IsSuperAdmin);
    var defaultToken = new TokenDto(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo, "Welcome Admin! You still have to reset your default password to get the access to The dashboard.", ResponseStatus.Warning);
    return new OkObjectResult(defaultToken);
  }
  private async Task<Entities.Admin?> GetAdmin(LoginEvent request, CancellationToken cancellationToken)
  {
    Entities.Admin? admin;
    try
    {
      var phone = request.EmailOrPhoneNumber.Split('+');
      if (Int64.TryParse(phone[1], out _))
      {
        admin = await _adminRepo.GetBySpecAsync(new GetByPhoneNumberWithOtp<Entities.Admin>(request.EmailOrPhoneNumber),
          cancellationToken);
        return admin;
      }
    }
    catch 
    {
      admin = await _adminRepo.GetBySpecAsync(new GetByEmail<Entities.Admin>(request.EmailOrPhoneNumber),
        cancellationToken);
      return admin;
    }
    return null;
  }

}
