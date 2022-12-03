using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Region.ChangeStatus.Events;

public class ChangeStatusEventHandler:IRequestHandler<ChangeRegionStatusEvent,ActionResult>
{
  private readonly IRepository<Entities.Region> _regionRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Region> regionRepository)
  {
    _regionRepository = regionRepository;
  }
  public async Task<ActionResult> Handle(ChangeRegionStatusEvent request, CancellationToken cancellationToken)
  {
    var region = await _regionRepository.GetByIdAsync(request.RegionId, cancellationToken);
    if (region is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    region.Isdeleted = !region.Isdeleted;
    await _regionRepository.UpdateAsync(region, cancellationToken);
    await _regionRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(region.Isdeleted ? "Delete Region Done You Can Retrieve It Any Time" : "Retrieve Region Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
