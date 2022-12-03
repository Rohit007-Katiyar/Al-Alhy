using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.VotePanel.Player.GetAll.DTO;
using AhliFans.Core.Feature.Fan.VotePanel.Player.GetAll.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.VotePanel.Player.GetAll.Events;

public class GetAllPlayersToVoteEventHandler : IRequestHandler<GetAllPlayersToVoteEvent,ActionResult>
{
  private readonly IRepository<MatchPlayer> _playersRepository;

  public GetAllPlayersToVoteEventHandler(IRepository<MatchPlayer> playersRepository)
  {
    _playersRepository = playersRepository;
  }
  public async Task<ActionResult> Handle(GetAllPlayersToVoteEvent request, CancellationToken cancellationToken)
  {
    var players = await _playersRepository.ListAsync(new GetAllPlayersByMatch(request.MatchId),cancellationToken);
    if (players.Count == 0) return new OkObjectResult(Enumerable.Empty<VotePlayersDto>());

    return new OkObjectResult(players.Select(p => new VotePlayersDto(p.PlayerId,
      request.Lang == Languages.En ? p.Player?.Name! : p.Player?.NameAr!,
      request.Lang == Languages.En ? p.Player?.Position?.Name! : p.Player?.Position?.NameAr!,p.Player?.Number)).Where(x=>x.Position != "حارس مرمي" || x.Position != "GoalKeeper"));
  }
}
