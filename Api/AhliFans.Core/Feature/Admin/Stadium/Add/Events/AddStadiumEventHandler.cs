using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Stadium.Add.Events;

public class AddStadiumEventHandler : IRequestHandler<AddStadiumEvent,ActionResult>
{
  private readonly IRepository<Entities.Stadium> _stadiumRepository;
  private readonly IMapper _mapper;

  public AddStadiumEventHandler(IRepository<Entities.Stadium> stadiumRepository,IMapper mapper)
  {
    _stadiumRepository = stadiumRepository;
    _mapper = mapper;
  }
  public async Task<ActionResult> Handle(AddStadiumEvent request, CancellationToken cancellationToken)
  {
    var stadiumMapper = _mapper.Map<Entities.Stadium>(request);
    await _stadiumRepository.AddAsync(stadiumMapper,cancellationToken);
    await _stadiumRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully",ResponseStatus.Success));
  }
}
