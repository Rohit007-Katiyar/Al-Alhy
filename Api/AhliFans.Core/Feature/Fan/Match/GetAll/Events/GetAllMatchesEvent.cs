using AhliFans.Core.Feature.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Match.GetAll.Events;

public record GetAllMatchesEvent(int PageIndex, int PageSize, int LeagueId, int LeagueDataId, MatchTypes MatchType, string Lang) :IRequest<ActionResult>;
