using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.SubAdmin;

public record EditByIdRequest(Guid AdminId, string? Name, string? Email, string? PhoneNumber)
{
  public const string Route = $"{nameof(Areas.Admin)}/SubAdmin";
}
