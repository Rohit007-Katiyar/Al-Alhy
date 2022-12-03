namespace AhliFans.Core.Feature.Admin.Coach.Honor.GetById.DTO;

public record CoachHonorDto(int HonorId,int TrophyTypeId,int TrophyId, string TrophyName,bool IsPersonal,int Count);
