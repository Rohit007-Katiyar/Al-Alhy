using AhliFans.Core.Feature.Admin.Season.GetById.DTO;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Season.GetById.Event;

public class GetByIdEventHandler : IRequestHandler<GetSeasonByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.Season> _seasonRepository;
  public GetByIdEventHandler(IRepository<Entities.Season> seasonRepository)
  {
    _seasonRepository = seasonRepository;
  }
  public async Task<ActionResult> Handle(GetSeasonByIdEvent request, CancellationToken cancellationToken)
  {
    var season = await _seasonRepository.GetByIdAsync(request.SeasonId, cancellationToken);
    if (season is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new SeasonDto(season.Id,season.Name , season.NameAr,season.StartDate,season.EndDate));
  }
}
