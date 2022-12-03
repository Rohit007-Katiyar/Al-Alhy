using AhliFans.Core.Feature.Admin.Stadium.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Stadium.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Stadium.GetAll.Events;

public class GetAllEventHandler : IRequestHandler<GetAllStadiumsEvent, ActionResult>
{
  private readonly IRepository<Entities.Stadium> _stadiumRepository;

  public GetAllEventHandler(IRepository<Entities.Stadium> stadiumRepository)
  {
    _stadiumRepository = stadiumRepository;
  }
  public async Task<ActionResult> Handle(GetAllStadiumsEvent request, CancellationToken cancellationToken)
  {
    var stadiums = await _stadiumRepository.ListAsync(new GetAllStadiums(request.PageIndex,request.PageSize,request.IsDeleted), cancellationToken);
    if (stadiums.Count == 0) return new OkObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));

    return new OkObjectResult(stadiums.Select(s => new GetAllStadiumsDto(s.Id, request.Lang == Languages.En ? s.Name : s.NameAr,s.IsDeleted)));
  }
}
