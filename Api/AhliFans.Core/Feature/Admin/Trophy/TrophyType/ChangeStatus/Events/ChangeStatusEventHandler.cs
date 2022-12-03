using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.ChangeStatus.Events;

public class ChangeStatusEventHandler:IRequestHandler<ChangeTrophyTypeStatusEvent,ActionResult>
{
  private readonly IRepository<Entities.TrophyType> _trophyTypeRepository;

  public ChangeStatusEventHandler(IRepository<Entities.TrophyType> trophyTypeRepository)
  {
    _trophyTypeRepository = trophyTypeRepository;
  }
  public async Task<ActionResult> Handle(ChangeTrophyTypeStatusEvent request, CancellationToken cancellationToken)
  {
    var trophyType = await _trophyTypeRepository.GetByIdAsync(request.TypeId, cancellationToken);
    if (trophyType is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    trophyType.IsDeleted = !trophyType.IsDeleted;
    await _trophyTypeRepository.UpdateAsync(trophyType, cancellationToken);
    await _trophyTypeRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(trophyType.IsDeleted ? "Delete Trophy Type Done You Can Retrieve It Any Time" : "Retrieve Trophy Type Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
