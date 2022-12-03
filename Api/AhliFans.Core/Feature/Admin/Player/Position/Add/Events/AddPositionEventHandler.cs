using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.Add.Events;

public class AddPositionEventHandler : IRequestHandler<AddPositionEvent,ActionResult>
{
  private readonly IRepository<Entities.Position> _positionRepository;
  private readonly IMapper _mapper;
  private readonly AddPositionValidation _validation;
  public AddPositionEventHandler(IRepository<Entities.Position> positionRepository, IMapper mapper, AddPositionValidation validation)
  {
    _positionRepository = positionRepository;
    _mapper = mapper;
    _validation = validation;
  }
  public async Task<ActionResult> Handle(AddPositionEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validation.ValidateAsync(request, cancellationToken);

    if (!validation.IsValid)
    {
      return new BadRequestObjectResult(new AdminResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));
    }

    var position = _mapper.Map<Entities.Position>(request);
    await _positionRepository.AddAsync(position,cancellationToken);
    await _positionRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("New Position has been added", ResponseStatus.Success));
  }
}
