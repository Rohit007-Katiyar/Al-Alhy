using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Notification.Setting.Edit.Specification;
using AhliFans.Core.Feature.Fan.Notification.Setting.Get.DTO;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification.Setting.Get.Event;

public class GetSettingEventHandler : IRequestHandler<GetNotificationSettingEvent,ActionResult>
{
  private readonly IRepository<NotificationSetting> _notificationRepository;
  private readonly string _userId;
  public GetSettingEventHandler(IHttpContextAccessor context,IRepository<NotificationSetting> notificationRepository)
  {
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
    _notificationRepository = notificationRepository;
  }
  public async Task<ActionResult> Handle(GetNotificationSettingEvent request, CancellationToken cancellationToken)
  {
    var setting = await _notificationRepository.GetBySpecAsync(new GetUserNotificationSetting(Guid.Parse(_userId)), cancellationToken);
    if (setting is null) return new NotFoundObjectResult(new AdminResponse("no data", ResponseStatus.Error));
    return new OkObjectResult(new UserNotificationSettingDto(setting.EnableAll,setting.PlaySounds,setting.News,setting.MatchStatus,setting.NightMode,setting.From,setting.To));
  }
}
