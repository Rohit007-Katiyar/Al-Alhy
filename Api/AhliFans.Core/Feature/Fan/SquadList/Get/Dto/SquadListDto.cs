namespace AhliFans.Core.Feature.Fan.SquadList.Get.Dto;

public class SquadListDto
{
  public int PlayerId { get; set; }

  public int MatchId { get; set; }

  public int PositionId { get; set; }

  public string PlayerName { get; set; } = string.Empty;

  public int PlayerNumber { get; set; }

  public string PositionName { get; set; } = string.Empty;

  public string PositionSymbol { get; set; } = string.Empty;
}
