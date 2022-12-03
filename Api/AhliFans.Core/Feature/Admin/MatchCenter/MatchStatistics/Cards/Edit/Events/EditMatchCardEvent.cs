using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public record EditMatchCardEvent(int Id, int? PlayerId, bool IsForAhly, bool IsRed, int Minute) : IRequest<ActionResult>;