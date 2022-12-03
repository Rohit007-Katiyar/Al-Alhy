using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment;

public class ChangeMomentEventHandler:IRequestHandler<ChangeMomentStatusEvent,ActionResult>
{
  private readonly IRepository<Entities.Moment> _momentRepository;

  public ChangeMomentEventHandler(IRepository<Entities.Moment> momentRepository)
  {
    _momentRepository = momentRepository;
  }
  public async Task<ActionResult> Handle(ChangeMomentStatusEvent request, CancellationToken cancellationToken)
  {
    var moment = await _momentRepository.GetByIdAsync(request.MomentId,cancellationToken);
    if (moment is null) return new NotFoundObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    moment.IsAvailable = !moment.IsAvailable;
    await _momentRepository.UpdateAsync(moment, cancellationToken);
    await _momentRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(!moment.IsAvailable ? "Delete moment Done You Can Retrieve It Any Time" : "Retrieve moment Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
