using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics;

public record GetAllMatchStatisticsRequest(int MatchId,  int PageIndex, int PageSize, string? Lang)
{
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics";
}