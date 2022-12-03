using AhliFans.Core.Feature.Fan.Notification.Setting.Add.Events;
using AhliFans.Core.Feature.Fan.Preferences.Add.Events;
using AhliFans.Core.Feature.Security.Entities;
using AhliFans.Core.Feature.Security.ResendOtp.Fan.Events;
using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.SocialMediaRegistration.Events;

public class RegistrationEventHandler : IRequestHandler<SocialMediaRegistrationEvent,ActionResult>
{
  private readonly IRepository<User> _userRepository;
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  private readonly UserManager<Entities.Fan> _userManager;
  private readonly string _userId;

  public RegistrationEventHandler(IRepository<User> userRepository, IMediator mediator,IHttpContextAccessor context, IMapper mapper, UserManager<Entities.Fan> userManager)
  {
    _userRepository = userRepository;
    _mediator = mediator;
    _mapper = mapper;
    _userManager = userManager;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(SocialMediaRegistrationEvent request, CancellationToken cancellationToken)
  {
    var fanDb = await _userManager.FindByIdAsync(_userId);
    if (fanDb == null) return new BadRequestObjectResult(new FanResponse("Not found user", ResponseStatus.Error));

    var fan = _mapper.Map<Entities.Fan>(request);
    if (await IsPhoneNumberExist(fan.PhoneNumber!, cancellationToken))
    {
      return new BadRequestObjectResult(new AdminResponse("The Phone Number is already taken", ResponseStatus.Error));
    }
    MapToFan(ref fanDb, fan);

    var result = await _userManager.UpdateAsync(fanDb);
    if (!result.Succeeded)
    {
      var errors = result.Errors.Select(x => x.Description).Distinct();

      var enumerable = errors.ToList();
      return new BadRequestObjectResult(new FanResponse(string.Join(",", enumerable), ResponseStatus.Error));
    }

    //Add Notification Setting
    await _mediator.Send(new AddSettingEvent(Guid.Parse(_userId), true, false, true, true, false, null, null), cancellationToken);

    //default preferences
    await _mediator.Send(new AddPreferencesEvent(null, null, null, null, null, null, null, fan.Id), cancellationToken);
    return await _mediator.Send(new ResendOtpEvent(fanDb.PhoneNumber), cancellationToken);
  }

  private static void MapToFan(ref Entities.Fan fanDb, Entities.Fan fan)
  {
    fanDb.FullName = fan.FullName;
    fanDb.Email = fan.Email;
    fanDb.PhoneNumber = fan.PhoneNumber;
    fanDb.BirthDate = fan.BirthDate;
    fanDb.CityId = fan.CityId;
    fanDb.Gender = fan.Gender;
  }
  private async Task<bool> IsPhoneNumberExist(string phone, CancellationToken cancellationToken)
  {
    if (string.IsNullOrEmpty(phone))
    {
      return false;
    }
    var user = await _userRepository.GetBySpecAsync(new GetByPhoneNumberWithOtp<User>(phone),
      cancellationToken);
    return user is not null && user.Id != Guid.Parse(_userId);
  }
}
