using System.IdentityModel.Tokens.Jwt;
using AhliFans.Core.Feature.Security.Login.Fan.DTO;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.APIServices.FaceBook.IRepository;
using AhliFans.SharedKernel.Enum;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.FBLogin.Fan.Events;

public class FbLoginEventHandler : IRequestHandler<FbLoginEvent,ActionResult>
{
  private readonly IFaceBookAuthService _faceBookAuthService;
  private readonly JWTToken _jwtToken;
  private readonly UserManager<Entities.Fan> _userManager;

  public FbLoginEventHandler(IFaceBookAuthService faceBookAuthService, JWTToken jwtToken, UserManager<Entities.Fan> userManager)
  {
    _faceBookAuthService = faceBookAuthService;
    _jwtToken = jwtToken;
    _userManager = userManager;
  }
  public async Task<ActionResult> Handle(FbLoginEvent request, CancellationToken cancellationToken)
  {
    var validationTokenResult = await _faceBookAuthService.ValidationAccessToken(request.AccessToken);
    
    if (!validationTokenResult.ValidationData.Isvalid)
      return new BadRequestObjectResult(new FanResponse("Token isn't valid", ResponseStatus.Error));
    
    var userInfo = await _faceBookAuthService.GetUserInfo(request.AccessToken);
    var user = await _userManager.FindByEmailAsync(userInfo.Email);
    
    if (user is null)
    {
      var newUser = new Entities.Fan()
      {
        UserName = userInfo.Email, 
        Email = userInfo.Email,
        FullName = $"{userInfo.FirstName} {userInfo.LastName}",
        RegistrationDate = DateTime.Now,
      };

      var created = await _userManager.CreateAsync(newUser);
      var role = await _userManager.AddToRoleAsync(newUser, Roles.Fan.ToString());
      if (!created.Succeeded || !role.Succeeded)
      {
        return new BadRequestObjectResult(new FanResponse("Token isn't valid", ResponseStatus.Error));
      }

      var newUserToken = await _jwtToken.CreateJwtToken(newUser);
      var defaultTokenDto = new FanTokenDto(new JwtSecurityTokenHandler().WriteToken(newUserToken), newUserToken.ValidTo, "Welcome!", ResponseStatus.Success);
      return new OkObjectResult(defaultTokenDto);
    }

    var token = await _jwtToken.CreateJwtToken(user);
    var defaultToken = new FanTokenDto(new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo, "Welcome!", ResponseStatus.Success);
    return new OkObjectResult(defaultToken);
  }
}
