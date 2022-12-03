using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Referee.Add.Events;

public class AddRefereeEventHandler : IRequestHandler<AddRefereeEvent,ActionResult>
{
  private readonly IRepository<Entities.Referee> _refereeRepository;
  private readonly IMapper _mapper;
  public AddRefereeEventHandler(IRepository<Entities.Referee> refereeRepository, IMapper mapper)
  {
    _refereeRepository = refereeRepository;
    _mapper = mapper;
  }
  public async Task<ActionResult> Handle(AddRefereeEvent request, CancellationToken cancellationToken)
  {
    var referee = _mapper.Map<Entities.Referee>(request);

    await _refereeRepository.AddAsync(referee, cancellationToken);
    await _refereeRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation Done Successfully",ResponseStatus.Success));
  }

}
