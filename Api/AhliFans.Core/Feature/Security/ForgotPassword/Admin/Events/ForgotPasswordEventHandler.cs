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
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Security.ForgotPassword.Admin.Events;
public class ForgotPasswordEventHandler : IRequestHandler<ForgotPasswordEvent, ActionResult>
{

  readonly ForgotPasswordValidator _validator;
  readonly ILogger<ForgotPasswordEventHandler> _logger;
  private readonly UserManager<User> _userManager;
  private readonly ICequensService _cequens;
  private readonly IRepository<User> _userRepo;
  private readonly IRepository<UserOtp> _userOtpRepo;

  public ForgotPasswordEventHandler(ForgotPasswordValidator validator, ILogger<ForgotPasswordEventHandler> logger, UserManager<User> userManager, ICequensService cequens, IRepository<User> userRepo, IRepository<UserOtp> userOtpRepo)
  {
    _validator = validator;
    _logger = logger;
    _userManager = userManager;
    _cequens = cequens;
    _userRepo = userRepo;
    _userOtpRepo = userOtpRepo;
  }
  public async Task<ActionResult> Handle(ForgotPasswordEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validator.ValidateAsync(request, cancellationToken);
    if (!validation.IsValid)
    {
      _logger.LogError(request.ToString());
      return new BadRequestObjectResult(new AdminResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));
    }

    var admin = await _userRepo.GetBySpecAsync(new GetByPhoneNumberWithOtp<User>(request.PhoneNumber), cancellationToken);
    if (admin is null) return new BadRequestObjectResult(new AdminResponse("Can't find the user", ResponseStatus.Error));

    var sendResult = await _cequens.SendOTPAsync(request.PhoneNumber);
    if (!sendResult.IsSuccessful)
    {
      return new BadRequestObjectResult(new FanResponse(sendResult.ErrorMessage, ResponseStatus.Error));
    }

    await ValidateOtp(cancellationToken, sendResult.CheckCode, admin);

    await _userRepo.UpdateAsync(admin, cancellationToken);
    await _userRepo.SaveChangesAsync(cancellationToken);

    _logger.LogInformation($"Admin {request.PhoneNumber} reset password initiated done successfully.");
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
      var otp = new UserOtp() {SendData = DateTime.Now, UserId = admin.Id, Code = code};
      admin.Otp = otp;

      await _userOtpRepo.AddAsync(otp, cancellationToken);
      await _userOtpRepo.SaveChangesAsync(cancellationToken);
    }
  }
}
