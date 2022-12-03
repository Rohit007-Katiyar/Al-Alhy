using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ForgotPassword.Fan.Events;
public record ForgotPasswordEvent(string FanPhoneNumber) : IRequest<ActionResult> ;
