using AhliFans.Core.Feature.Admin.Region.GetById.DTO;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Region.GetById.Events;

public class GetRegionByIdEventHandler : IRequestHandler<GetRegionByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.Region> _regionRepository;

  public GetRegionByIdEventHandler(IRepository<Entities.Region> regionRepository)
  {
    _regionRepository = regionRepository;
  }
  public async Task<ActionResult> Handle(GetRegionByIdEvent request, CancellationToken cancellationToken)
  {
    var region = await _regionRepository.GetByIdAsync(request.RegionId,cancellationToken);
    if (region == null) return new NotFoundObjectResult(new AdminResponse("Not found",ResponseStatus.Error));

    return new OkObjectResult(new RegionDto(region.Id, region.Name, region.NameAr));
  }
}
