using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.Add.Events;

public class AddCoachHonorEventHandler : IRequestHandler<AddCoachHonorEvent,ActionResult>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Entities.Honor> _honorRepository;

  public AddCoachHonorEventHandler(IMapper mapper,IRepository<Entities.Honor> honorRepository)
  {
    _mapper = mapper;
    _honorRepository = honorRepository;
  }
  public async Task<ActionResult> Handle(AddCoachHonorEvent request, CancellationToken cancellationToken)
  {
    var honor = _mapper.Map<Entities.Honor>(request);
    await _honorRepository.AddAsync(honor, cancellationToken);
    await _honorRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new AdminResponse("Operation done successfully",ResponseStatus.Success));
  }
}
