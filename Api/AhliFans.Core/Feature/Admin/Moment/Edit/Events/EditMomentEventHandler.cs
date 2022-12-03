using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment.Edit.Events;

public class EditMomentEventHandler : IRequestHandler<EditMomentEvent,ActionResult>
{
  private readonly IRepository<Entities.Moment> _momentRepository;

  public EditMomentEventHandler(IRepository<Entities.Moment> momentRepository)
  {
    _momentRepository = momentRepository;
  }
  public async Task<ActionResult> Handle(EditMomentEvent request, CancellationToken cancellationToken)
  {
    var moment = await _momentRepository.GetByIdAsync(request.MomentId, cancellationToken);
    if (moment is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    MapMoment(request,ref moment);
    await _momentRepository.UpdateAsync(moment, cancellationToken);
    await _momentRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully",ResponseStatus.Success));
  }

  private static void MapMoment(EditMomentEvent request,ref Entities.Moment moment)
  {
    moment.PlayerId = request.PlayerId ?? moment.PlayerId;
    moment.MatchId = request.MatchId ?? moment.MatchId;
    moment.MomentTime = request.MomentTime ?? moment.MomentTime;
    moment.Type = request.Type ?? moment.Type;
    moment.From = request.VotingStartFrom ?? moment.From;
    moment.To = request.To ?? moment.To;
  }
}
