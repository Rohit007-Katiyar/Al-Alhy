#nullable disable
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.ResetPassword;

public record ResetPasswordRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Account/ResetPassword";
  public string NewPassword { get; set; }
  public string ConfirmNewPassword { get; set; }
}
