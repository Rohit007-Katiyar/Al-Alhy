using AhliFans.Core.Feature.Enums;

namespace AhliFans.Core.Feature.Admin.Moment.GetAll.DTO;

public record MomentsDto(int MomentId,string Player,string Match, MomentVoteTypes Type,bool IsAvailable, string? MomentTime);
