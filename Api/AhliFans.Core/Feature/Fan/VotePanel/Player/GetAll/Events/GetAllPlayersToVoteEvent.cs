using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.VotePanel.Player.GetAll.Events;

public record GetAllPlayersToVoteEvent(int MatchId,string Lang) : IRequest<ActionResult>;
