
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Account;


public record RestPasswordRequest(string NewPassword, string ConfirmPassword)
{
  public const string Route = $"{nameof(Areas.Admin)}/Account/RestPassword";
}
