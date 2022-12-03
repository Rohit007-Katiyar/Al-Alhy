using System.IdentityModel.Tokens.Jwt;
using AhliFans.Core.Feature.Security.Login.Admin.DTO;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.GmailLogin.Fan.Events;

public class GmailLoginEventHandler : IRequestHandler<GmailLoginEvent,ActionResult>
{
  private readonly JWTToken _jwtToken;
  private readonly UserManager<Entities.Fan> _userManager;

  public GmailLoginEventHandler(JWTToken jwtToken, UserManager<Entities.Fan> userManager)
  {
    _jwtToken = jwtToken;
    _userManager = userManager;
  }
  public async Task<ActionResult> Handle(GmailLoginEvent request, CancellationToken cancellationToken)
  {
    
    var user = await _userManager.FindByEmailAsync(request.Email);
    
    if (user is null)
    {
      var newUser = new Entities.Fan()
      {
        UserName = request.Email, 
        Email = request.Email,
        FullName = request.UserName,
        RegistrationDate = DateTime.Now,
      };
     
      var created = await _userManager.CreateAsync(newUser);
      var role = await _userManager.AddToRoleAsync(newUser, Roles.Fan.ToString());
      if (!created.Succeeded || !role.Succeeded)
      {
        return new BadRequestObjectResult(new FanResponse("Server error", ResponseStatus.Error));
      }


      var newUserToken = await _jwtToken.CreateJwtToken(newUser);
      var defaultTokenDto = new TokenDto(new JwtSecurityTokenHandler().WriteToken(newUserToken), newUserToken.ValidTo, "Welcome!", ResponseStatus.Success);
      return new OkObjectResult(defaultTokenDto);
    }

    var token = await _jwtToken.CreateJwtToken(user);
    var defaultToken = new TokenDto(new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo, "Welcome!", ResponseStatus.Success);
    return new OkObjectResult(defaultToken);
  }
}
