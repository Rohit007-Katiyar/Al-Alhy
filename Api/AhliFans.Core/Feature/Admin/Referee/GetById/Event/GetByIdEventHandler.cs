using AhliFans.Core.Feature.Admin.Referee.GetById.DTO;
using AhliFans.Core.Feature.Admin.Referee.GetById.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Referee.GetById.Event;

public class GetByIdEventHandler : IRequestHandler<GetRefereeByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.Referee> _refereeRepository;
  public GetByIdEventHandler(IRepository<Entities.Referee> refereeRepository)
  {
    _refereeRepository = refereeRepository;
  }
  public async Task<ActionResult> Handle(GetRefereeByIdEvent request, CancellationToken cancellationToken)
  {
    var referee = await _refereeRepository.GetBySpecAsync(new GetRefereeById(request.RefereeId), cancellationToken);
    if (referee is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new RefereeDto(referee.Id, request.Lang == Languages.En ? referee.Nationality?.Name! : referee.Nationality?.NameAr!, referee.Nationality?.Id.ToString()!, referee.Region?.Id.ToString()!, request.Lang == Languages.En ?referee.Region?.Name!:referee.Region?.NameAr!, referee.Name , referee.NameAr, referee.IsDeleted));
  }
}
