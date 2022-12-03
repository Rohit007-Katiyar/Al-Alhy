using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.LineUp.GetByMatchId.Events;

public record GetLineUpByIdEvent(int MatchId,string Lang,bool IsSubstitution) : IRequest<ActionResult>;
