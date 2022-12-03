using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification.Manual.GetCount.Events;

public record GetFanNotificationCountEvent:IRequest<ActionResult>;
