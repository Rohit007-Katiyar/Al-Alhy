
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.ChangePassword;

public record ChangePasswordRequest(string OldPassword, string NewPassword, string ConfirmPassword)
{
  public const string Route = $"{nameof(Areas.Client)}/Account/ChangePassword";
}

