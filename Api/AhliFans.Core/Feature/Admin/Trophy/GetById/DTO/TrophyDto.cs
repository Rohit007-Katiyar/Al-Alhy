namespace AhliFans.Core.Feature.Admin.Trophy.GetById.DTO;

public record TrophyDto(int TrophyId, string TrophyType, string TrophyTypeName, string Name, string NameAr, DateTime CreatedOn,string CreatedBy, DateTime? ModifiedOn,string? ModifiedBy, bool IsDeleted,List<int> TrophyYear);
