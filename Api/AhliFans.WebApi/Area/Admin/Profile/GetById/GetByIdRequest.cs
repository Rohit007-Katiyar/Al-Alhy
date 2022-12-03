using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Profile;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Profile";
}
