using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Notification.Manual.Send.Events;

public record SendNotificationEvent(string Header, string Body, IFormFile Icon, string? Link):IRequest<ActionResult>;
