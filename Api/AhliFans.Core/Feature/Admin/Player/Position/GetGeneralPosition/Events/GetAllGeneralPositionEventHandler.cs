using AhliFans.Core.Feature.Admin.Player.Position.GetGeneralPosition.DTO;
using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.GetGeneralPosition.Events;

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
    if (generalPosition.Count == 0) return new BadRequestObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));
    return new OkObjectResult(generalPosition.Select(g =>
      new GeneralPositionDto(g.Id, request.Lang == Languages.En ? g.Name : g.NameAr)));
  }
}
