using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.GetById.Events;

public record GetMatchByIdEvent(int MatchId,string Lang) :IRequest<ActionResult>;
