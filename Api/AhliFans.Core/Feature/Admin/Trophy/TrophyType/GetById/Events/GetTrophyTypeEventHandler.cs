using AhliFans.Core.Feature.Admin.Trophy.TrophyType.GetById.DTO;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.GetById.Events;

public class GetTrophyTypeEventHandler : IRequestHandler<GetTrophyTypeByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.TrophyType> _trophyTypeRepository;

  public GetTrophyTypeEventHandler(IRepository<Entities.TrophyType> trophyTypeRepository)
  {
    _trophyTypeRepository = trophyTypeRepository;
  }
  public async Task<ActionResult> Handle(GetTrophyTypeByIdEvent request, CancellationToken cancellationToken)
  {
    var trophyType = await _trophyTypeRepository.GetByIdAsync(request.TrophyTypeId, cancellationToken);
    if (trophyType is null) return new BadRequestObjectResult(new AdminResponse("Not Found",ResponseStatus.Error));

    return new OkObjectResult(
      new TrophyTypeDto(trophyType.Id, trophyType.Name, trophyType.NameAr, trophyType.IsDeleted));
  }
}
