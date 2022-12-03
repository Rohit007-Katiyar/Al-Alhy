using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.Title;

public record EditRequest(int TitleId,string? Text,string? TextAr)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Title";
}
