using AhliFans.Core.Feature.Fan.Trophy.TrophyType.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Trophy.TrophyType.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Trophy.TrophyType.GetAll.Events;

public class GetAllEventHandler:IRequestHandler<GetAllTrophyTypesEvent,ActionResult>
{
  private readonly IRepository<Entities.TrophyType> _trophyTypeRepository;
  public GetAllEventHandler(IRepository<Entities.TrophyType> trophyTypeRepository)
  {
    _trophyTypeRepository = trophyTypeRepository;
  }
  public async Task<ActionResult> Handle(GetAllTrophyTypesEvent request, CancellationToken cancellationToken)
  {
    var trophyTypes = await _trophyTypeRepository.ListAsync(new GetAllTrophyTypes(request.Name),cancellationToken);
    if (trophyTypes.Count == 0) return new OkObjectResult(Enumerable.Empty<FanTrophyTypesDto>());

    return new OkObjectResult(trophyTypes.Select(t =>
      new FanTrophyTypesDto(t.Id, request.Lang == Languages.En ? t.Name : t.NameAr)));
  }
}
