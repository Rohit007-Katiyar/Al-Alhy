namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public record MatchCardDto
{
  public int Id { get; set; }

  public int Minute { get; set; }

  public string? PlayerName { get; set; }

  public int? PlayerId { get; set; }

  public bool IsForAhly { get; set; }

  public bool IsRed { get; set; }

  public bool IsEnabled { get; set; }
}