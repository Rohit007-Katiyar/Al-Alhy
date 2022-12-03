using AhliFans.Core.Feature.Admin.Referee.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Referee.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Referee.GetAll.Events;

public class GetAllEventHandler:IRequestHandler<GetAllRefereesEvent,ActionResult>
{
  private readonly IRepository<Entities.Referee> _refereeRepository;

  public GetAllEventHandler(IRepository<Entities.Referee> refereeRepository)
  {
    _refereeRepository = refereeRepository;
  }
  public async Task<ActionResult> Handle(GetAllRefereesEvent request, CancellationToken cancellationToken)
  {
    var referees = await _refereeRepository.ListAsync(new GetAllReferees(request.PageIndex, request.PageSize,
      request.SearchWord!, request.IsDeleted),cancellationToken);

    if (referees.Count == 0) return new BadRequestObjectResult(new AdminResponse("Not found",ResponseStatus.Error));

    return new OkObjectResult(referees.Select(c => new RefereesDto(c.Id, request.Lang == Languages.En ? c.Nationality?.Name!: c.Nationality?.NameAr!, request.Lang == Languages.En ? c.Name: c.NameAr, c.IsDeleted)));
  }
}
