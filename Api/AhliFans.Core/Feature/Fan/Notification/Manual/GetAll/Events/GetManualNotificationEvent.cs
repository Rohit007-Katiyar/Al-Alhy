using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification;

public record GetManualNotificationEvent(int PageSize, int PageIndex,string ImageUrl) : IRequest<ActionResult>;
