using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.VotePanel.Player.Vote.Events;

public record VoteForPlayerEvent(int PlayerId,int MatchId):IRequest<ActionResult>;
