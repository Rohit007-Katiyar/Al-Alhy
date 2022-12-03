using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.ChangeStatus.Events;

public class ChangeStatusEventHandler:IRequestHandler<ChangePlayerStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Player> _playerRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }
  public async Task<ActionResult> Handle(ChangePlayerStatusEvent request, CancellationToken cancellationToken)
  {
    var player = await _playerRepository.GetByIdAsync(request.PlayerId,cancellationToken);
    if (player is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    player.IsDeleted = !player.IsDeleted;
    await _playerRepository.UpdateAsync(player, cancellationToken);
    await _playerRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(player.IsDeleted ? "Delete Player Done You Can Retrieve It Any Time" : "Retrieve Player Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
