
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Profile;

public record ModifyRequest(string? FullName, string? EmailAddress, string? MobileNumber, DateTime? DateOfBirth,
  Gender? Gender, int? CityId)
{
  public const string Route = $"{nameof(Areas.Client)}/Profile";

}
