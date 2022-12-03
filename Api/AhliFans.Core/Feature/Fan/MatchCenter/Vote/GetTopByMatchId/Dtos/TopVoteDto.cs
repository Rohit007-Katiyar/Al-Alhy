namespace AhliFans.Core.Feature.Fan.MatchCenter.Vote;

public record TopVoteDto
{
  public int PlayerId { get; set; }

  public string PlayerName { get; set; } = string.Empty;

  public decimal VotePercentage { get; set; }
}