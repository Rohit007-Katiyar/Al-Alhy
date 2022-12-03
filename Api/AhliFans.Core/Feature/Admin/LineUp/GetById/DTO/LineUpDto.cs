namespace AhliFans.Core.Feature.Admin.LineUp.GetById.DTO;

public record LineUpDto(int PlayerId,string PlayerName,int? PositionId, string Position, string PositionSymbol, bool IsSubstitute);
