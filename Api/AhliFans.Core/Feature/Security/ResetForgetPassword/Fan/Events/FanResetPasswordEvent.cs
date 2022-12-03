using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ResetForgetPassword.Fan.Events;

public record FanResetPasswordEvent(string NewPassword, string ConfirmPassword):IRequest<ActionResult>;
