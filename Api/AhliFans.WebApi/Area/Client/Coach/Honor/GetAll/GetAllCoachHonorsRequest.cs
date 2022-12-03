using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Coach.Honor.GetAll;

public record GetAllCoachHonorsRequest(int CoachId, int TrophyTypeId,bool IsDeleted, string Lang = Languages.Ar, int PageIndex = 1, int PageSize = 10)
{
  public const string Route = $"{nameof(Areas.Client)}/Coach/Honors";
}
