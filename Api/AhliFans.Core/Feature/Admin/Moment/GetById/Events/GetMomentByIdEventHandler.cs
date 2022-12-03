using AhliFans.Core.Feature.Admin.Moment.GetById.DTO;
using AhliFans.Core.Feature.Admin.Moment.GetById.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment.GetById.Events;

public class GetMomentByIdEventHandler : IRequestHandler<GetMomentByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.Moment> _momentRepository;

  public GetMomentByIdEventHandler(IRepository<Entities.Moment> momentRepository)
  {
    _momentRepository = momentRepository;
  }
  public async Task<ActionResult> Handle(GetMomentByIdEvent request, CancellationToken cancellationToken)
  {
    var moment = await _momentRepository.GetBySpecAsync(new GetMomentById(request.MomentId),cancellationToken);
    if (moment is null) return new NotFoundObjectResult(new AdminResponse("Not found",ResponseStatus.Error));

    return new OkObjectResult(new MomentDto(moment.Id,
      request.Lang == Languages.En ? moment.Player?.Name! : moment.Player?.NameAr!,
      request.Lang == Languages.En ? moment.Match.OpponentTeam.Name : moment.Match.OpponentTeam.NameAr, moment.Type,
      moment.IsAvailable, moment.MomentTime?.ToString("h:mm tt")!,moment.From,moment.To));
  }
}
