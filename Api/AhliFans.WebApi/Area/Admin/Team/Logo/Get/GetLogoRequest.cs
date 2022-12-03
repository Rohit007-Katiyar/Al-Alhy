using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Team.Logo;

public record GetLogoRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Team/Image/{{TeamId}}";
  public int TeamId { get; set; }
}
