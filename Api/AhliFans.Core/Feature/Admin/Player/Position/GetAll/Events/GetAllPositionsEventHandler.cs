using AhliFans.Core.Feature.Admin.Player.Position.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Player.Position.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.GetAll.Events;
public class GetAllPositionsEventHandler : IRequestHandler<GetAllPositionsEvent,ActionResult>
{
  private readonly IRepository<Entities.Position> _positionRepository;
  public GetAllPositionsEventHandler(IRepository<Entities.Position> positionRepository)
  {
    _positionRepository = positionRepository;
  }
  public async Task<ActionResult> Handle(GetAllPositionsEvent request, CancellationToken cancellationToken)
  {
    var positions = await _positionRepository.ListAsync(new GetAllPositions(request.Name,request.IsDeleted),cancellationToken);
    if (positions.Count == 0) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
   
    return new OkObjectResult(positions.Select(p => new PositionsDto(p.Id,p.IsDeleted,request.Lang == Languages.En? p.Name : p.NameAr, p.Symbol!, request.Lang == Languages.En ? p.GeneralPosition?.Name!: p.GeneralPosition?.NameAr!)));
  }
}
