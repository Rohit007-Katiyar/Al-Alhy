using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.VotePanel.Moment.Vote.Events;

public record VoteForMomentEvent(int MomentId):IRequest<ActionResult>;
