using AhliFans.Core.Feature.Admin.Trophy.TrophyType.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Trophy.TrophyType.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.GetAll.Events;

public class GetAllEventHandler:IRequestHandler<GetAllTrophyTypesEvent,ActionResult>
{
  private readonly IRepository<Entities.TrophyType> _trophyTypeRepository;
  public GetAllEventHandler(IRepository<Entities.TrophyType> trophyTypeRepository)
  {
    _trophyTypeRepository = trophyTypeRepository;
  }
  public async Task<ActionResult> Handle(GetAllTrophyTypesEvent request, CancellationToken cancellationToken)
  {
    var trophyTypes = await _trophyTypeRepository.ListAsync(new GetAllTrophyTypes(request.Name,request.IsDeleted),cancellationToken);
    if (trophyTypes.Count == 0) return new BadRequestObjectResult(new AdminResponse("Not Found", ResponseStatus.Error));

    return new OkObjectResult(trophyTypes.Select(t =>
      new TrophyTypesDto(t.Id, request.Lang == Languages.En ? t.Name : t.NameAr,t.IsDeleted)));
  }
}
