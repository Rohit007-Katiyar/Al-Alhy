using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public record GetAllStatisticGroupsEvent(int PageIndex, int PageSize, string? Name, string Language = Languages.Ar) : IRequest<ActionResult>;
