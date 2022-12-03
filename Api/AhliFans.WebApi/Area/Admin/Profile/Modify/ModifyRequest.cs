
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Profile.Modify;

public record ModifyRequest(string? FullName, string? EmailAddress, string? MobileNumber)
{
  public const string Route = $"{nameof(Areas.Admin)}/Profile";

}
