using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.GmailLogin.Fan.Events;

public record GmailLoginEvent(string Email, string UserName) :IRequest<ActionResult>;
