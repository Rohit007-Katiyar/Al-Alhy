using AhliFans.Core.Feature.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Match;

public record GetAllMatchesEvent(int PageIndex, int PageSize, MatchTypes MatchType, string Lang) :IRequest<ActionResult>;
