using System.IdentityModel.Tokens.Jwt;
using AhliFans.Core.Feature.Security.Login.Admin.DTO;
using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.APIServices.Cequens.Enums;
using AhliFans.SharedKernel.APIServices.Cequens.IRepository;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ValidateOtp.Admin.Events;

public class ValidateOtpEventHandler : IRequestHandler<ValidateOtpEvent,ActionResult>
{
  private readonly IRepository<Entities.Admin> _userRepository;
  private readonly JWTToken _jwtToken;
  private readonly ICequensService _cequensService;
  public ValidateOtpEventHandler(IRepository<Entities.Admin> userRepository, JWTToken jwtToken, ICequensService cequensService)
  {
    _userRepository = userRepository;
    _jwtToken = jwtToken;
    _cequensService = cequensService;
  }
  public async Task<ActionResult> Handle(ValidateOtpEvent request, CancellationToken cancellationToken)
  {
    var admin = await _userRepository.GetBySpecAsync(new GetByPhoneNumberWithOtp<Entities.Admin>(request.PhoneNumber), cancellationToken);
    if (admin is null) return new BadRequestObjectResult(new AdminResponse("Can't find the user", ResponseStatus.Error));

    var validationResult = await _cequensService.ValidateOTPAsync(request.Code, admin.Otp.Code);
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

    JwtSecurityToken jwtSecurityToken = await _jwtToken.CreateJwtToken(admin, isRoot: admin.IsSuperAdmin);
    var defaultToken = new TokenDto(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo, "Welcome!", ResponseStatus.Warning);
    return new OkObjectResult(defaultToken);
  }
}
