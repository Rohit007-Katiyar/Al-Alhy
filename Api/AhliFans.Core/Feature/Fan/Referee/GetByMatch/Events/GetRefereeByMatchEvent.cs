using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Referee.GetByMatch.Events;

public record GetRefereeByMatchEvent(int MatchId,string Lang):IRequest<ActionResult>;
