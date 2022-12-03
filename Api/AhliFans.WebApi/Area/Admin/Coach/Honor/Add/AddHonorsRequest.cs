using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.Honor.Add;

public record AddHonorsRequest(int CoachId, int TrophyId, bool IsPersonal)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Honor";
}
