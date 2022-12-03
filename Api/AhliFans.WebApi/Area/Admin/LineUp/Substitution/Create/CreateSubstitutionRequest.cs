using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.LineUp;

public record CreateSubstitutionRequest(int PlayerId,int SubstitutionPlayer,int MatchId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Substitution";
}
