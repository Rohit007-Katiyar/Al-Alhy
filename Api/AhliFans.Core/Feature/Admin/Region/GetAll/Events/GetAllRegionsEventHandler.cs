using AhliFans.Core.Feature.Admin.Region.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Region.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Region.GetAll.Events;

public class GetAllRegionsEventHandler : IRequestHandler<GetAllRegionsEvent,ActionResult>
{
  private readonly IRepository<Entities.Region> _regionRepository;

  public GetAllRegionsEventHandler(IRepository<Entities.Region> regionRepository)
  {
    _regionRepository = regionRepository;
  }
  public async Task<ActionResult> Handle(GetAllRegionsEvent request, CancellationToken cancellationToken)
  {
    var regions = await _regionRepository.ListAsync(new GetAllRegions(request.PageIndex,request.PageSize,request.Name,request.IsDeleted), cancellationToken);
    if (regions.Count == 0) return new OkObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));
   
    return new OkObjectResult(regions.Select(r=>new RegionsDto(r.Id,request.Lang == Languages.En?r.Name:r.NameAr,r.Date , r.Isdeleted)));
  }
}
