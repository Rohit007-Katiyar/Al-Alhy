using AhliFans.Core.Feature.Security.Entities;
using AhliFans.Core.Feature.Security.ForgotPassword.Specifications;
using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.Core.Feature.Security.Utilities.DigitsSecurityProvider;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.APIServices.Cequens.IRepository;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Security.ForgotPassword.Fan.Events;
public class ForgotPasswordEventHandler : IRequestHandler<ForgotPasswordEvent,ActionResult>
{
  private readonly IRepository<User> _userRepo;
  readonly ForgotPasswordValidator _validator;
  readonly ILogger<ForgotPasswordEventHandler> _logger;
  private readonly UserManager<User> _userManager;
  private readonly ICequensService _cequens;
  private readonly IRepository<UserOtp> _userOtpRepo;

  public ForgotPasswordEventHandler(IRepository<User> userRepo,ForgotPasswordValidator validator, ILogger<ForgotPasswordEventHandler> logger, UserManager<User> userManager, ICequensService cequens, IRepository<UserOtp> userOtpRepo)
  {
    _userRepo = userRepo;
    _validator = validator;
    _logger = logger;
    _userManager = userManager;
    _cequens = cequens;
    _userOtpRepo = userOtpRepo;
  }
  public async Task<ActionResult> Handle(ForgotPasswordEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validator.ValidateAsync(request, cancellationToken);
    if (!validation.IsValid)
    {
      _logger.LogError(request.ToString());
      return new BadRequestObjectResult(new FanResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));
    }

    var fan = await _userRepo.GetBySpecAsync(new GetByPhoneNumberWithOtp<User>(request.FanPhoneNumber),cancellationToken);
    if (fan is null) return new BadRequestObjectResult(new FanResponse("Can't find the user", ResponseStatus.Error));

    var sendResult = await _cequens.SendOTPAsync(fan.PhoneNumber);
    if (!sendResult.IsSuccessful)
    {
      var errorResponse = new FanResponse(sendResult.ErrorMessage, ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    await ValidateOtp(cancellationToken, sendResult.CheckCode, fan);

    await _userRepo.UpdateAsync(fan,cancellationToken);
    await _userRepo.SaveChangesAsync(cancellationToken);

    _logger.LogInformation($"Fan {request.FanPhoneNumber} reset password sms sent successfully.");
    return new OkObjectResult(new FanResponse("Please check your phone that we have send you a code to reset your password.", ResponseStatus.Info));
  }
  private async Task ValidateOtp(CancellationToken cancellationToken, string code, User fan)
  {
    var userHasOtp = await _userOtpRepo.GetBySpecAsync(new IsUserHasOtp(fan.Id), cancellationToken);
    if (userHasOtp is not null)
    {
      userHasOtp.Code = code;
      userHasOtp.SendData = DateTime.Now;
      fan.Otp = userHasOtp;

      await _userOtpRepo.UpdateAsync(userHasOtp, cancellationToken);
      await _userOtpRepo.SaveChangesAsync(cancellationToken);
    }
    else
    {
      var otp = new UserOtp() { SendData = DateTime.Now, UserId = fan.Id, Code = code };
      fan.Otp = otp;

      await _userOtpRepo.AddAsync(otp, cancellationToken);
      await _userOtpRepo.SaveChangesAsync(cancellationToken);
    }
  }
}
