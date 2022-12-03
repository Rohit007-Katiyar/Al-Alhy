using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Team;

public record GetTeamLogoRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Team/Logo/{{TeamId}}";
  public int TeamId { get; set; }
}

