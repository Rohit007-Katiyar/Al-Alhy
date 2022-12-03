namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public record MatchStatisticDetailsDto(int Id, int StatisticTypeId, int StatisticCoefficientId, string Name, string GroupName, int Value);