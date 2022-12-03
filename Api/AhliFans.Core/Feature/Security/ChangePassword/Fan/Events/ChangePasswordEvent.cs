using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ChangePassword.Fan.Events;

public record ChangePasswordEvent
  (string OldPassword, string NewPassword, string ConfirmPassword) : IRequest<ActionResult>;
