using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public record GetAllMatchStatisticsEvent(int MatchId, int PageIndex, int PageSize, string Language = Languages.Ar) : IRequest<ActionResult>;
