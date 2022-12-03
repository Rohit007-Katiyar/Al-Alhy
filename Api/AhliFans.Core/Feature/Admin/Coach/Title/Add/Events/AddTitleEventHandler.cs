using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Title.Add.Events;

public class AddTitleEventHandler : IRequestHandler<AddTitleEvent,ActionResult>
{
  private readonly IRepository<Entities.Title> _titleRepository;
  private readonly IMapper _mapper;
  public AddTitleEventHandler(IRepository<Entities.Title> titleRepository, IMapper mapper)
  {
    _titleRepository = titleRepository;
    _mapper = mapper;
  }
  public async Task<ActionResult> Handle(AddTitleEvent request, CancellationToken cancellationToken)
  {
    var title = _mapper.Map<Entities.Title>(request);
    await _titleRepository.AddAsync(title,cancellationToken);
    await _titleRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("New coach title has been added successfully", ResponseStatus.Success));
  }
}
