using AhliFans.Core.Feature.Admin.Season.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Season.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Season.GetAll.Events;

public class GetAllEventHandler :IRequestHandler<GetAllSeasonsEvent,ActionResult>
{
  private readonly IRepository<Entities.Season> _seasonRepository;
  public GetAllEventHandler(IRepository<Entities.Season> seasonRepository)
  {
    _seasonRepository = seasonRepository;
  }
  public async Task<ActionResult> Handle(GetAllSeasonsEvent request, CancellationToken cancellationToken)
  {
    var seasons = await _seasonRepository.ListAsync(new GetAllSeason(request.PageIndex,request.PageSize,request.Name,request.StartDate,request.EndDate,request.IsDeleted),
      cancellationToken);
    if (seasons.Count == 0) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(seasons.Select(s =>
      new GetAllSeasonsDto(s.Id, request.Lang == Languages.En ? s.Name : s.NameAr, s.StartDate, s.EndDate,s.IsDeleted)));
  }
}
