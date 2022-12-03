using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Referee;

public record AddRefereeRequest(int NationalityId, int RegionId, string Name, string NameAr)
{
  public const string Route = $"{nameof(Areas.Admin)}/Referee";
}
