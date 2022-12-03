using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Notification.Setting.Edit.Specification;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification.Setting.Edit.Events;

public class EditNotificationEventHandler : IRequestHandler<EditNotificationSettingsEvent,ActionResult>
{
  private readonly IRepository<NotificationSetting> _notificationRepository;
  private readonly string _userId;

  public EditNotificationEventHandler(IHttpContextAccessor context,IRepository<NotificationSetting> notificationRepository)
  {
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
    _notificationRepository = notificationRepository;
  }
  public async Task<ActionResult> Handle(EditNotificationSettingsEvent request, CancellationToken cancellationToken)
  {
    var setting = await _notificationRepository.GetBySpecAsync(new GetUserNotificationSetting(Guid.Parse(_userId)),cancellationToken);
    if (setting is null) return new BadRequestObjectResult(new AdminResponse("no data", ResponseStatus.Error));
    
    MapSetting(request,ref setting);
    await _notificationRepository.UpdateAsync(setting, cancellationToken);
    await _notificationRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private static void MapSetting(EditNotificationSettingsEvent request,ref NotificationSetting setting)
  {
    setting.EnableAll = request.EnableAll ?? setting.EnableAll;
    setting.PlaySounds = request.PlaySounds ?? setting.PlaySounds;
    setting.News = request.News ?? setting.News;
    setting.MatchStatus = request.MatchStatus ?? setting.MatchStatus;
    setting.NightMode = request.NightMode ?? setting.NightMode;
    setting.From = request.From ?? setting.From;
    setting.To = request.To ?? setting.To;
  }
}
