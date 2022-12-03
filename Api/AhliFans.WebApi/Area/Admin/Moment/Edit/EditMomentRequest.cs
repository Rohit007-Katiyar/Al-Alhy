using AhliFans.Core.Feature.Enums;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Moment.Edit;

public record EditMomentRequest(int MomentId, int? PlayerId, int? MatchId, DateTime? MomentTime, MomentVoteTypes? Type, DateTime? VotingStartFrom, DateTime? To)
{
  public const string Route = $"{nameof(Areas.Admin)}/Moment";
}
