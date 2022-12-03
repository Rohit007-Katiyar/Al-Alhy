using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ForgotPassword.Admin.Events;
public record ForgotPasswordEvent(string PhoneNumber) : IRequest<ActionResult> ;
