using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification;
public record GetNotificationIconEvent(int NotificationId) :IRequest<ActionResult>;
