using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification.Setting.Get.Event;

public record GetNotificationSettingEvent:IRequest<ActionResult>;
