using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.ChangeStatus.Events;
public class ChangeStatusEventHandler : IRequestHandler<ChangePositionStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Position> _positionRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Position> positionRepository)
  {
    _positionRepository = positionRepository;
  }
  public async Task<ActionResult> Handle(ChangePositionStatusEvent request, CancellationToken cancellationToken)
  {
    var position = await _positionRepository.GetByIdAsync(request.PositionId, cancellationToken);
    if (position is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    position.IsDeleted = !position.IsDeleted;
    await _positionRepository.UpdateAsync(position, cancellationToken);
    await _positionRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(position.IsDeleted ? "Delete Position Done You Can Retrieve It Any Time" : "Retrieve Position Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
