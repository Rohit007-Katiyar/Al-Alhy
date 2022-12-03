using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ResetPassword.Admin.Events;

public record ResetPasswordEvent(string Password, string ConfirmPassword) : IRequest<ActionResult>;
