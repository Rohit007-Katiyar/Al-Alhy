using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ResetForgetPassword.Admin.Events;
public record AdminForgetPasswordEvent(string NewPassword, string ConfirmPassword) : IRequest<ActionResult>;
