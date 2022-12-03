using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification.Manual.GetById.Events;

public record GetNotificationByIdEvent(int NotificationId,string ImageUrl) : IRequest<ActionResult>;
