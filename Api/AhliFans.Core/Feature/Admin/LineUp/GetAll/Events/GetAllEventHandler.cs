using AhliFans.Core.Feature.Admin.LineUp.GetAll.DTO;
using AhliFans.Core.Feature.Admin.LineUp.GetAll.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.LineUp.GetAll.Events;

public class GetAllEventHandler : IRequestHandler<GetAllLineUpEvent,ActionResult>
{
  private readonly IRepository<MatchLineUp> _lineUp;

  public GetAllEventHandler(IRepository<MatchLineUp> lineUp)
  {
    _lineUp = lineUp;
  }
  public async Task<ActionResult> Handle(GetAllLineUpEvent request, CancellationToken cancellationToken)
  {
    var lineUps =
      await _lineUp.ListAsync(new GetAllLineUps(request.PageIndex, request.PageSize, request.Date,
        request.OpponentTeam), cancellationToken);
    if (lineUps.Count == 0) return new OkObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));
    return new OkObjectResult(lineUps.Select(l => new LineUpsDto(l.MatchId,request.Lang == Languages.En ? l.Match.OpponentTeam.Name: l.Match.OpponentTeam.NameAr, l.Date)));
  }
}
