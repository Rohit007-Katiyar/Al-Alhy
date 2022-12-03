namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public record MatchGoalDto()
{
  public int Id { get; set; }

  public int? PlayerId { get; set; }

  public int Minute { get; set; }

  public string? PlayerName { get; set; }

  public bool IsForAhly { get; set; }

  public bool IsEnabled { get; set; }
}