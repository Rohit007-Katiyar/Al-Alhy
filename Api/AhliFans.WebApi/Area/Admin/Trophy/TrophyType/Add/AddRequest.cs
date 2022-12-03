using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Trophy.TrophyType;

public record AddRequest(string Name,string NameAr)
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy/Type";

}
