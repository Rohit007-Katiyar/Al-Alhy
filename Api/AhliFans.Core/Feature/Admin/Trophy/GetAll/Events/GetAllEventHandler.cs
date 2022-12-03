using AhliFans.Core.Feature.Admin.Trophy.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Trophy.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.GetAll.Events;

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
      request.Name, request.TrophyTypeId, request.IsDeleted, request.IsAvailable),cancellationToken);

    if (trophies.Count == 0) return new BadRequestObjectResult(new AdminResponse("Not Found", ResponseStatus.Error));

    return new OkObjectResult(trophies.Select(t => new TrophiesDto(t.Id,
      request.Lang == Languages.En ? t.TrophyType.Name : t.TrophyType.NameAr,
      request.Lang == Languages.En ? t.Name : t.NameAr, t.CreatedOn, t.IsDeleted,t.IsAvailable)));
  }
}
