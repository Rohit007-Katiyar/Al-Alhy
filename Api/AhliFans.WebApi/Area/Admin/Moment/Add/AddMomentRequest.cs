using AhliFans.Core.Feature.Enums;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Moment.Add;

public record AddMomentRequest(int PlayerId, int MatchId, DateTime? MomentTime, MomentVoteTypes Type,IFormFile? MomentVideo,
  DateTime VotingStartFrom, DateTime To)
{
  public const string Route = $"{nameof(Areas.Admin)}/Moment";
}
