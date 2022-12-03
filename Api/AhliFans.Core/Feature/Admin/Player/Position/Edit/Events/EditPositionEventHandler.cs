using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.Edit.Events;

public class EditPositionEventHandler:IRequestHandler<EditPositionEvent,ActionResult>
{
  private readonly IRepository<Entities.Position> _positionRepository;
  public EditPositionEventHandler(IRepository<Entities.Position> positionRepository)
  {
    _positionRepository = positionRepository;
  }
  public async Task<ActionResult> Handle(EditPositionEvent request, CancellationToken cancellationToken)
  {
    var position = await _positionRepository.GetByIdAsync(request.PositionId,cancellationToken);
    if (position is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    MapPosition(request, position);

    await _positionRepository.UpdateAsync(position,cancellationToken);
    await _positionRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private static void MapPosition(EditPositionEvent request, Entities.Position position)
  {
    position.Name = request.Name ?? position.Name;
    position.NameAr = request.NameAr ?? position.NameAr;
    position.Symbol = request.Symbol ?? position.Symbol;
    position.GeneralPositionId = request.GeneralPositionId ?? position.GeneralPositionId;
  }
}
