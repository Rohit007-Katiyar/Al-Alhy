using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public record AddMatchCardEvent(int MatchId, int? PlayerId, bool IsRed, bool IsForAhly, int Minute) : IRequest<ActionResult>;