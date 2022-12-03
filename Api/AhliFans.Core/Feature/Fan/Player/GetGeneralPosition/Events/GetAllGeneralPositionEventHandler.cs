using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Player.GetGeneralPosition.DTO;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Player.GetGeneralPosition.Events;

public class GetAllGeneralPositionEventHandler : IRequestHandler<GetAllGeneralPositionsEvent,ActionResult>
{
  private readonly IRepository<GeneralPlayerPosition> _generalPositions;

  public GetAllGeneralPositionEventHandler(IRepository<GeneralPlayerPosition> generalPositions)
  {
    _generalPositions = generalPositions;
  }
  public async Task<ActionResult> Handle(GetAllGeneralPositionsEvent request, CancellationToken cancellationToken)
  {
    var generalPosition = await _generalPositions.ListAsync(cancellationToken);
    if (generalPosition.Count == 0) return new OkObjectResult(Enumerable.Empty<GeneralPositionDto>());
    return new OkObjectResult(generalPosition.Select(g =>
      new GeneralPositionDto(g.Id, request.Lang == Languages.En ? g.Name : g.NameAr)));
  }
}
