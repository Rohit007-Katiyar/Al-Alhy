using AhliFans.Core.Feature.Fan.Player.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Player.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Player.GetAll.Events;

public class GetAllPlayersEventHandler : IRequestHandler<GetAllPlayersEvent, ActionResult>
{
  private readonly IRepository<Entities.Player> _playerRepository;
  public GetAllPlayersEventHandler(IRepository<Entities.Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }
  public async Task<ActionResult> Handle(GetAllPlayersEvent request, CancellationToken cancellationToken)
  {
    var players =
      await _playerRepository.ListAsync(new GetAllPlayers(request.PageIndex, request.PageSize, request.PlayerName,request.IsDeleted),cancellationToken);
    if (players.Count == 0) return new OkObjectResult(Enumerable.Empty<PlayersDto>());

    return new OkObjectResult(players.Select(p => new PlayersDto(p.Id, p.Number,
      request.Lang == Languages.En ? p.Name : p.NameAr, p.Height, p.Weight,p.IsDeleted)));
  }
}
