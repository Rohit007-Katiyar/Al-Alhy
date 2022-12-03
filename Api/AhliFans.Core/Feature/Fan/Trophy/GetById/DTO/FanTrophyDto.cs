namespace AhliFans.Core.Feature.Fan.Trophy.GetById.DTO;

public record FanTrophyDto(int Id, string TrophyType, string Name, DateTime CreatedOn,string CreatedBy, DateTime? ModifiedOn,string? ModifiedBy, bool IsDeleted,List<int> TrophyYear);
