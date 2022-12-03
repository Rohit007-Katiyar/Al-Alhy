using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.ChangeStatus.Events;

public class ChangeStatusEventHandler:IRequestHandler<ChangeTrophyStatusEvent,ActionResult>
{
  private readonly IRepository<Entities.Trophy> _trophyRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Trophy> trophyRepository)
  {
    _trophyRepository = trophyRepository;
  }
  public async Task<ActionResult> Handle(ChangeTrophyStatusEvent request, CancellationToken cancellationToken)
  {
    var trophy = await _trophyRepository.GetByIdAsync(request.TrophyId, cancellationToken);
    if (trophy is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    trophy.IsDeleted = !trophy.IsDeleted;
    await _trophyRepository.UpdateAsync(trophy, cancellationToken);
    await _trophyRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(trophy.IsDeleted ? "Delete Trophy Done You Can Retrieve It Any Time" : "Retrieve Trophy Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
