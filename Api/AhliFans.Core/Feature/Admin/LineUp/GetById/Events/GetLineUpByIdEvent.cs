using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.LineUp.GetById.Events;

public record GetLineUpByIdEvent(int MatchId,string Lang):IRequest<ActionResult>;
