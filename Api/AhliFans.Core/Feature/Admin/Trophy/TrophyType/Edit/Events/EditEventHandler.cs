using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.Edit.Events;

public class EditEventHandler : IRequestHandler<EditTrophyTypeEvent,ActionResult>
{
  private readonly IRepository<Entities.TrophyType> _trophyTypeRepository;
  public EditEventHandler(IRepository<Entities.TrophyType> trophyTypeRepository)
  {
    _trophyTypeRepository = trophyTypeRepository;
  }
  public async Task<ActionResult> Handle(EditTrophyTypeEvent request, CancellationToken cancellationToken)
  {
    var trophyType = await _trophyTypeRepository.GetByIdAsync(request.Id, cancellationToken);
    if (trophyType is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    trophyType.Name = request.Name ?? trophyType.Name;
    trophyType.NameAr = request.NameAr ?? trophyType.NameAr;

    await _trophyTypeRepository.UpdateAsync(trophyType,cancellationToken);
    await _trophyTypeRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
