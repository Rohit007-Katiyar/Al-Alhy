using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Notification.Setting.Add.Specification;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification.Setting.Add.Events;

public class AddSettingEventHandler : IRequestHandler<AddSettingEvent,ActionResult>
{
  private readonly IMapper _mapper;
  private readonly IRepository<NotificationSetting> _notificationRepository;
  public AddSettingEventHandler(IMapper mapper,IRepository<NotificationSetting> notificationRepository)
  {
    _mapper = mapper;
    _notificationRepository = notificationRepository; 
  }
  public async Task<ActionResult> Handle(AddSettingEvent request, CancellationToken cancellationToken)
  {
    if(await _notificationRepository.AnyAsync(new IsUserAddHisSettingBefore(request.FanId),cancellationToken))
      return new BadRequestObjectResult(new FanResponse("User already add his setting before", ResponseStatus.Error));
   
    var setting = _mapper.Map<NotificationSetting>(request);
    setting.FanId = request.FanId;
    
    await _notificationRepository.AddAsync(setting, cancellationToken);
    await _notificationRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new FanResponse("Operation done successfully",ResponseStatus.Success));
  }
}
