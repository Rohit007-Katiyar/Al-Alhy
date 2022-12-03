using AhliFans.Core.Feature.Fan.Notification.Setting.Add.Events;
using AhliFans.Core.Feature.Fan.Preferences.Add.Events;
using AhliFans.Core.Feature.Security.Entities;
using AhliFans.Core.Feature.Security.ForgotPassword.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.APIServices.Cequens.IRepository;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Security.Registration.Fan.Events;
public class RegistrationEventHandler : IRequestHandler<RegistrationEvent,ActionResult>
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  private readonly RegistrationEventValidation _validator;
  private readonly UserManager<Entities.Fan> _userManager;
  private readonly IFileManager _fileManager;
  private readonly ILogger<RegistrationEventHandler> _logger;
  private readonly ICequensService _cequens;
  private readonly IRepository<UserOtp> _userOtpRepo;

  public RegistrationEventHandler(IMediator mediator,IMapper mapper, RegistrationEventValidation validator, UserManager<Entities.Fan> userManager, IFileManager fileManager, ILogger<RegistrationEventHandler> logger, ICequensService cequens, IRepository<UserOtp> userOtpRepo)
  {
    _mediator = mediator;
    _mapper = mapper;
    _validator = validator;
    _userManager = userManager;
    _fileManager = fileManager;
    _logger = logger;
    _cequens = cequens;
    _userOtpRepo = userOtpRepo;
  }
  public async Task<ActionResult> Handle(RegistrationEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validator.ValidateAsync(request, cancellationToken);
    if (!validation.IsValid)
    {
      _logger.LogError(request.ToString());
      return new BadRequestObjectResult(new FanResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));
    }

    var fan = _mapper.Map<Entities.Fan>(request);
    var result = await _userManager.CreateAsync(fan, request.Password);
    var addToResult = await _userManager.AddToRoleAsync(fan, Roles.Fan.ToString());

    if (!result.Succeeded || !addToResult.Succeeded)
    {
      var errors = result.Errors.Select(x => x.Description).Distinct();

      var enumerable = errors.ToList();
      _logger.LogError($"{request} Failed to register {string.Join(',', enumerable)}.");
      return new BadRequestObjectResult(new FanResponse(string.Join(",", enumerable), ResponseStatus.Error));
    }

    //Upload required documents
    bool saveProfile = await SaveProfile(request, fan.Id);
    if (!saveProfile)
    {
      _logger.LogWarning($"{fan.FullName} saving Profile Pic failure .");
    }
    var sendResult = await _cequens.SendOTPAsync(fan.PhoneNumber);
    if (!sendResult.IsSuccessful)
    {
      return new BadRequestObjectResult(new FanResponse(sendResult.ErrorMessage, ResponseStatus.Error));
    }

    //Add Notification Setting
    await _mediator.Send(new AddSettingEvent(fan.Id, true, false, true, true, false, null, null), cancellationToken);
    //default preferences
    await _mediator.Send(new AddPreferencesEvent(null, null, null, null, null, null, null, fan.Id), cancellationToken);
    await ValidateOtp(cancellationToken, sendResult.CheckCode, fan);
    await _userManager.UpdateAsync(fan);
    return new OkObjectResult(new FanResponse("Please check your phone that we have send you a code to activate your account.", ResponseStatus.Info));
  }
  private async Task<bool> SaveProfile(RegistrationEvent request, Guid id)
  {
    if (request.ProfilePic is null)
    {
      return true;
    }

    bool saveProfile = await _fileManager.SaveFileAsync<Entities.Fan>(request.ProfilePic,
      request.ProfilePic.FileName, id.ToString());
    return saveProfile;

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
