using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Region.Edit.Events;

public class EditRegionEventHandler : IRequestHandler<EditRegionEvent,ActionResult>
{
  private readonly IRepository<Entities.Region> _regionRepository;

  public EditRegionEventHandler(IRepository<Entities.Region> regionRepository)
  {
    _regionRepository = regionRepository;
  }
  public async Task<ActionResult> Handle(EditRegionEvent request, CancellationToken cancellationToken)
  {
    var region = await _regionRepository.GetByIdAsync(request.Id,cancellationToken);
    if (region == null) return new OkObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    MapRegion(request, ref region);
    await _regionRepository.UpdateAsync(region, cancellationToken);
    await _regionRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new AdminResponse("Operation done successfully",ResponseStatus.Success));
  }

  private static void MapRegion(EditRegionEvent request, ref Entities.Region region)
  {
    region.Name = request.Name ?? region.Name;
    region.NameAr = request.NameAr ?? region.NameAr;
  }
}
