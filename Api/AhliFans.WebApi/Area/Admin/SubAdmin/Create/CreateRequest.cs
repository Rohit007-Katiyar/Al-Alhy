using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.SubAdmin;

public record CreateRequest(string FullName,string? Email,string Password,string ConfirmPassword,string PhoneNumber)
{
  public const string Route = $"{nameof(Areas.Admin)}/SubAdmin";
}
