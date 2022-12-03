namespace AhliFans.Core.Feature.Admin.Trophy.GetAll.DTO;

public record TrophiesDto(int TrophyId,string Type, string Name,DateTime CreationData,bool IsDeleted, bool IsAvailable);
