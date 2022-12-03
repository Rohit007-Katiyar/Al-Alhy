namespace AhliFans.Core.Feature.Admin.Season.GetAll.DTO;

public record GetAllSeasonsDto(int SeasonId, string Name, DateTime StarDate,DateTime? EndDate,bool IsDeleted);
