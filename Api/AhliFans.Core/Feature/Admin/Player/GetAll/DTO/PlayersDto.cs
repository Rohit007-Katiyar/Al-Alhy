namespace AhliFans.Core.Feature.Admin.Player.GetAll.DTO;

public record PlayersDto(int Id,int? Number, int? PositionId, string? Name, int? Height, int? Weight,bool IsDeleted);

