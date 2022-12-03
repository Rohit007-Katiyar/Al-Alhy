namespace AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics.Goals;
public record MatchGoalDto()
{
  public int Id { get; set; }

  public int? PlayerId { get; set; }

  public string? PlayerName { get; set; }

  public int Minute { get; set; }

  public bool IsForAhly { get; set; }

};