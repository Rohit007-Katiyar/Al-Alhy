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

namespace AhliFans.Core.Feature.Security.ResendOtp.Admin.Events;

public class ResendOtpEventHandler : IRequestHandler<ResendOtpEvent,ActionResult>
{
  private readonly IRepository<UserOtp> _userOtpRepo;
  private readonly IRepository<Entities.Admin> _adminResponse;
  private readonly ICequensService _cequens;
  private readonly UserManager<User> _userManager;

  public ResendOtpEventHandler(IRepository<UserOtp> otpRepository,IRepository<Entities.Admin> adminResponse, ICequensService cequens, UserManager<User> userManager)
  {
    _userOtpRepo = otpRepository;
    _adminResponse = adminResponse;
    _cequens = cequens;
    _userManager = userManager;
  }
  public async Task<ActionResult> Handle(ResendOtpEvent request, CancellationToken cancellationToken)
  {
    var admin = await _adminResponse.GetBySpecAsync(new GetByPhoneNumberWithOtp<Entities.Admin>(request.PhoneNumber),cancellationToken);
    if (admin == null) return new BadRequestObjectResult(new AdminResponse("No found",ResponseStatus.Error));

    var sendResult = await _cequens.SendOTPAsync(admin.PhoneNumber);
    if (!sendResult.IsSuccessful)
    {
      return new BadRequestObjectResult(new AdminResponse(sendResult.ErrorMessage, ResponseStatus.Error));
    }

    await ValidateOtp(cancellationToken, sendResult.CheckCode, admin);

    await _adminResponse.UpdateAsync(admin, cancellationToken);
    await _adminResponse.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Please check your phone that we have send you a code to reset your password.", ResponseStatus.Info));
  }
  private async Task ValidateOtp(CancellationToken cancellationToken, string code, User admin)
  {
    var userHasOtp = await _userOtpRepo.GetBySpecAsync(new IsUserHasOtp(admin.Id), cancellationToken);
    if (userHasOtp is not null)
    {
      userHasOtp.Code = code;
      userHasOtp.SendData = DateTime.Now;
      admin.Otp = userHasOtp;

      await _userOtpRepo.UpdateAsync(userHasOtp, cancellationToken);
      await _userOtpRepo.SaveChangesAsync(cancellationToken);
    }
    else
    {
      var otp = new UserOtp() { SendData = DateTime.Now, UserId = admin.Id, Code = code };
      admin.Otp = otp;

      await _userOtpRepo.AddAsync(otp, cancellationToken);
      await _userOtpRepo.SaveChangesAsync(cancellationToken);
    }
  }
}
