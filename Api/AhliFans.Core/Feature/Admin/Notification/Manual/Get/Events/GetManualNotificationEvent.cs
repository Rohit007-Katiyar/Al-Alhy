using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Notification.Manual.Get.Events;

public record GetManualNotificationEvent(int PageSize, int PageIndex) : IRequest<ActionResult>;
