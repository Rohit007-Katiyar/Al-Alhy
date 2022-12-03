using AhliFans.Core.Feature.Fan.Trophy.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Trophy.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Trophy.GetAll.Events;

public class GetAllEventHandler :IRequestHandler<GetAllTrophyEvent,ActionResult>
{
  private readonly IRepository<Entities.Trophy> _trophyRepository;

  public GetAllEventHandler(IRepository<Entities.Trophy> trophyRepository)
  {
    _trophyRepository = trophyRepository;
  }
  public async Task<ActionResult> Handle(GetAllTrophyEvent request, CancellationToken cancellationToken)
  {
    var trophies = await _trophyRepository.ListAsync(new GetAllTrophies(request.PageIndex, request.PageSize,
      request.Name, request.TrophyTypeId),cancellationToken);

    if (trophies.Count == 0) return new OkObjectResult(Enumerable.Empty<FanTrophiesDto>());

    return new OkObjectResult(trophies.Select(t => new FanTrophiesDto(t.Id,
      request.Lang == Languages.En ? t.TrophyType.Name : t.TrophyType.NameAr,
      request.Lang == Languages.En ? t.Name : t.NameAr, t.CreatedOn, t.IsDeleted)));
  }
}
