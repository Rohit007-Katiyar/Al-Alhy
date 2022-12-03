#nullable disable
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Account;

public record ResetForgetPasswordRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Account/ForgetPassword";
  public string NewPassword { get; set; }
  public string ConfirmNewPassword { get; set; }
}
