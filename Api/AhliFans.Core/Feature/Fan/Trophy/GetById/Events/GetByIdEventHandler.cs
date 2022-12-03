using AhliFans.Core.Feature.Fan.Trophy.GetById.DTO;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Trophy.GetById.Events;

public class GetByIdEventHandler : IRequestHandler<GetTrophyById,ActionResult>
{
  private readonly IRepository<Entities.Trophy> _trophyRepository;

  public GetByIdEventHandler(IRepository<Entities.Trophy> trophyRepository)
  {
    _trophyRepository = trophyRepository;
  }
  public async Task<ActionResult> Handle(GetTrophyById request, CancellationToken cancellationToken)
  {
    var trophy = await _trophyRepository.GetBySpecAsync(new Specifications.GetTrophyById(request.TrophyId),cancellationToken);
    if (trophy is null) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new FanTrophyDto(trophy.Id,
      request.Lang == Languages.En ? trophy.TrophyType.Name : trophy.TrophyType.NameAr,
      request.Lang == Languages.En ? trophy.Name : trophy.NameAr, trophy.CreatedOn, trophy.UserCreate?.FullName!,
      trophy.ModifiedOn, trophy.UserModify?.FullName!, trophy.IsDeleted,trophy.TrophyHistories.Count == 0? new List<int>():trophy.TrophyHistories.Select(x=>x.Year).ToList()));
  }
}
