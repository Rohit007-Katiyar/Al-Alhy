namespace AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics;

public record MatchStatisticsDto()
{
  public IReadOnlyList<MatchStatisticDto> Statistics { get; set; } = Array.Empty<MatchStatisticDto>();
  public int RedCards { get; set; }

  public int YellowCards { get; set; }
};

