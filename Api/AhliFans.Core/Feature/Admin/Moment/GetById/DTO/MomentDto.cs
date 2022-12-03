using AhliFans.Core.Feature.Enums;

namespace AhliFans.Core.Feature.Admin.Moment.GetById.DTO;

public record MomentDto(int MomentId,string Player,string Match, MomentVoteTypes Type,
  bool IsAvailable, string? MomentTime, DateTime VoteStartFrom, DateTime To);
