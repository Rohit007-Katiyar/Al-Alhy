using AhliFans.Core.Feature.Security.Entities;
using AhliFans.Core.Feature.Security.ForgotPassword.Specifications;
using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.APIServices.Cequens.IRepository;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ResendOtp.Fan.Events;

public class ResendOtpEventHandler : IRequestHandler<ResendOtpEvent,ActionResult>
{
  private readonly IRepository<UserOtp> _userOtpRepo;
  private readonly IRepository<Entities.Fan> _fanRepository;
  private readonly ICequensService _cequens;
  private readonly UserManager<User> _userManager;

  public ResendOtpEventHandler(IRepository<UserOtp> otpRepository,IRepository<Entities.Fan> fanRepository, ICequensService cequens, UserManager<User> userManager)
  {
    _userOtpRepo = otpRepository;
    _fanRepository = fanRepository;
    _cequens = cequens;
    _userManager = userManager;
  }
  public async Task<ActionResult> Handle(ResendOtpEvent request, CancellationToken cancellationToken)
  {
    var fan = await _fanRepository.GetBySpecAsync(new GetByPhoneNumberWithOtp<Entities.Fan>(request.PhoneNumber),cancellationToken);
    if (fan == null) return new BadRequestObjectResult(new FanResponse("No found",ResponseStatus.Error));

    var sendResult = await _cequens.SendOTPAsync(fan.PhoneNumber);
    if (!sendResult.IsSuccessful)
    {
      return new BadRequestObjectResult(new FanResponse(sendResult.ErrorMessage, ResponseStatus.Error));
    }

    await ValidateOtp(cancellationToken, sendResult.CheckCode, fan);

    await _fanRepository.UpdateAsync(fan, cancellationToken);
    await _fanRepository.SaveChangesAsync(cancellationToken);

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
