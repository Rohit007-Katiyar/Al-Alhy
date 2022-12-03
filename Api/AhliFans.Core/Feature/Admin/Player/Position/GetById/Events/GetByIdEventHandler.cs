using AhliFans.Core.Feature.Admin.Player.Position.GetById.DTO;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.GetById.Events;

public class GetByIdEventHandler : IRequestHandler<GetPositionByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.Position> _positionRepository;

  public GetByIdEventHandler(IRepository<Entities.Position> positionRepository)
  {
    _positionRepository = positionRepository;
  }
  public async Task<ActionResult> Handle(GetPositionByIdEvent request, CancellationToken cancellationToken)
  {
    var position = await _positionRepository.GetByIdAsync(request.PositionId,cancellationToken);
    if (position == null) return new OkObjectResult(new AdminResponse("Not data yet",ResponseStatus.Error));

    return new OkObjectResult(new PositionDto(position.Id, position.Name, position.NameAr, position.Symbol!));
  }
}
