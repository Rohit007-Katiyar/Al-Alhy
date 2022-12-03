using AhliFans.Core.Feature.Enums;

#nullable disable
namespace AhliFans.Core.Feature.Fan.Match.GetById.DTO;

public class MatchDetailsDto
{
  public int OpponentTeamId { get; set; }

  public string OpponentTeamName { get; set; } = string.Empty;

  public int StadiumId { get; set; }

  public string StadiumName { get; set; } = string.Empty;

  public string MatchBroadcastChannels { get; set; } = string.Empty;

  public string LeagueName { get; set; } = string.Empty;

  public string PlannedDate { get; set; }

  public string PlannedTime { get; set; } = string.Empty;

  public bool IsAway { get; set; }

  public int Score { get; set; }

  public int OpponentScore { get; set; }
  public MatchStatus? MatchStatus { get; set; }

  public MatchTypes MatchType { get; set; }
}
