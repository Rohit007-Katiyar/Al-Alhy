using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.Login.Admin.Events;

public record LoginEvent(string EmailOrPhoneNumber, string Password) : IRequest<ActionResult>;
