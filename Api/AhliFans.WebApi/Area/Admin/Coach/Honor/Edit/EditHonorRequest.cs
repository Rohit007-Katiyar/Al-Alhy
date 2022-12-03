using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.Honor.Edit;

public record EditHonorRequest(int HonorId,int? CoachId, int? TrophyId, bool? IsPersonal)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Honor";
}
