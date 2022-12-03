using System.IdentityModel.Tokens.Jwt;
using AhliFans.Core.Feature.Security.Login.Fan.DTO;
using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.APIServices.Cequens.Enums;
using AhliFans.SharedKernel.APIServices.Cequens.IRepository;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ValidateOtp.Fan.Events;

public class ValidateOtpEventHandler : IRequestHandler<ValidateOtpEvent, ActionResult>
{
  private readonly IRepository<Entities.Fan> _userRepository;
  private readonly JWTToken _jwtToken;

  private readonly ICequensService _cequensService;
  public ValidateOtpEventHandler(IRepository<Entities.Fan> userRepository, JWTToken jwtToken, ICequensService cequensService)
  {
    _userRepository = userRepository;
    _jwtToken = jwtToken;
    _cequensService = cequensService;
  }
  public async Task<ActionResult> Handle(ValidateOtpEvent request, CancellationToken cancellationToken)
  {
    var fan = await _userRepository.GetBySpecAsync(new GetByPhoneNumberWithOtp<Entities.Fan>(request.PhoneNumber), cancellationToken);
    if (fan is null) return new BadRequestObjectResult(new FanResponse("Can't find the user", ResponseStatus.Error));

    var validationResult = await _cequensService.ValidateOTPAsync(request.Code, fan.Otp.Code);
    if (validationResult == OtpValidationState.Expired)
    {
      return new BadRequestObjectResult(new FanResponse("Otp has expired", ResponseStatus.Error));
    }
    if (validationResult == OtpValidationState.InvalidOtp)
    {
      return new BadRequestObjectResult(new FanResponse("Bad otp", ResponseStatus.Error));
    }
    if (validationResult == OtpValidationState.Failure)
    {
      return new BadRequestObjectResult(new FanResponse("Something went wrong, please try again with different code", ResponseStatus.Error));
    }
    JwtSecurityToken jwtSecurityToken = await _jwtToken.CreateJwtToken(fan);
    await ActiveUser(cancellationToken, fan);
    var defaultToken = new FanTokenDto(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo, "Welcome !", ResponseStatus.Warning);
    return new OkObjectResult(defaultToken);
  }
  private async Task ActiveUser(CancellationToken cancellationToken, Entities.Fan fan)
  {
    fan.IsActive = true;
    await _userRepository.UpdateAsync(fan, cancellationToken);
    await _userRepository.SaveChangesAsync(cancellationToken);
  }
}
