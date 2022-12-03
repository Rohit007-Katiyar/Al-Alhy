using System.IdentityModel.Tokens.Jwt;
using AhliFans.Core.Feature.Security.Login.Fan.DTO;
using AhliFans.Core.Feature.Security.ResendOtp.Fan.Events;
using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.Login.Fan.Events;
public class LoginEventHandler : IRequestHandler<LoginEvent,ActionResult>
{
  private readonly IMediator _mediator;
  private readonly LoginEventValidator _validator;
  private readonly UserManager<Entities.Fan> _userManager;
  private readonly JWTToken _jwtToken;
  private readonly IRepository<Entities.Fan> _fanRepo;

  public LoginEventHandler(IMediator mediator,LoginEventValidator validator, UserManager<Entities.Fan> userManager, JWTToken jwtToken, IRepository<Entities.Fan> fanRepo)
  {
    _mediator = mediator;
    _validator = validator;
    _userManager = userManager;
    _jwtToken = jwtToken;
    _fanRepo = fanRepo;
  }
  public async Task<ActionResult> Handle(LoginEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validator.ValidateAsync(request, cancellationToken);

    if (!validation.IsValid)
    {
       return new BadRequestObjectResult(new FanResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage).Distinct()), ResponseStatus.Error));
    }
    var fan = await GetFan(request, cancellationToken);
    if (fan is null || !await _userManager.CheckPasswordAsync(fan, request.Password) || fan.IsBlocked)
    {
      return new BadRequestObjectResult(new FanResponse("The user name or password may be incorrect", ResponseStatus.Error));
    }

    if (!fan.IsActive)
    {
      await _mediator.Send(new ResendOtpEvent(fan.PhoneNumber), cancellationToken);
      return new UnauthorizedObjectResult(new FanResponse("The user may doesn't activate his account yet", ResponseStatus.Error));
    }

    var jwtSecurityToken = await _jwtToken.CreateJwtToken(fan);
    var defaultToken = new FanTokenDto(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo, $"Welcome fan {fan.FullName}!", ResponseStatus.Success);
    return new OkObjectResult(defaultToken);
  }
  private async Task<Entities.Fan?> GetFan(LoginEvent request, CancellationToken cancellationToken)
  {
    Entities.Fan? fan;
    try
    {
      var phone = request.EmailOrPhoneNumber.Split('+');
      if (Int64.TryParse(phone[1], out _))
      {
        fan = await _fanRepo.GetBySpecAsync(new GetByPhoneNumberWithOtp<Entities.Fan>(request.EmailOrPhoneNumber),
          cancellationToken);
        return fan;
      }
    }
    catch 
    {
      fan = await _userManager.FindByEmailAsync(request.EmailOrPhoneNumber);
      return fan;
    }

    return null;
  }

}
