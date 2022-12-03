using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.Login.Fan.Events;

public record LoginEvent(string EmailOrPhoneNumber, string Password):IRequest<ActionResult>;
