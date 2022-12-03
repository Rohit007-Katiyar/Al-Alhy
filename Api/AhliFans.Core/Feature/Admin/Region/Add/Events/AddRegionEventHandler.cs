using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Region.Add.Events;

public class AddRegionEventHandler : IRequestHandler<AddRegionEvent,ActionResult>
{
  private readonly IRepository<Entities.Region> _regionRepository;
  private readonly IMapper _mapper;

  public AddRegionEventHandler(IRepository<Entities.Region> regionRepository,IMapper mapper)
  {
    _regionRepository = regionRepository;
    _mapper = mapper;
  }
  public async Task<ActionResult> Handle(AddRegionEvent request, CancellationToken cancellationToken)
  {
    var region = _mapper.Map<Entities.Region>(request);
    await _regionRepository.AddAsync(region, cancellationToken);
    await _regionRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
