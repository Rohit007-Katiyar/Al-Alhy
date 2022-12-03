using AhliFans.Core.Feature.Admin.Player.GetByPosition.DTO;
using AhliFans.Core.Feature.Admin.Player.GetByPosition.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.GetByPosition.Events;

public class GetPlayerByPositionEventHandler : IRequestHandler<GetPlayerByPositionEvent,ActionResult>
{
  private readonly IRepository<Entities.Player> _playerRepository;

  public GetPlayerByPositionEventHandler(IRepository<Entities.Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }
  public async Task<ActionResult> Handle(GetPlayerByPositionEvent request, CancellationToken cancellationToken)
  {
    var players = await _playerRepository.ListAsync(new GetPlayerByPosition(request.TeamId, request.GeneralPosition, request.TeamCategoryId),cancellationToken);
    if (players.Count == 0) return new OkObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));
    
    return new OkObjectResult(players.Select(p =>
      new PlayersByPositionDto(p.Id, p.Name!, p.Number, request.Lang == Languages.En ? p.Position?.Name!: p.Position?.NameAr!, p.Position?.Symbol!)));
  }
}
