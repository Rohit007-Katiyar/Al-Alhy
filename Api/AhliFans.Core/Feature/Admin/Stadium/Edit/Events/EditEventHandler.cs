using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Stadium.Edit.Events;

public class EditEventHandler : IRequestHandler<EditStadiumEvent,ActionResult>
{
  private readonly IRepository<Entities.Stadium> _stadiumRepository;

  public EditEventHandler(IRepository<Entities.Stadium> stadiumRepository)
  {
    _stadiumRepository = stadiumRepository;
  }
  public async Task<ActionResult> Handle(EditStadiumEvent request, CancellationToken cancellationToken)
  {
    var stadium = await _stadiumRepository.GetByIdAsync(request.StadiumId,cancellationToken);
    if (stadium == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    MapStadium(request,ref stadium);
    await _stadiumRepository.UpdateAsync(stadium, cancellationToken);
    await _stadiumRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private static void MapStadium(EditStadiumEvent request, ref Entities.Stadium stadium)
  {
    stadium.RegionId = request.RegionId ?? stadium.RegionId;
    stadium.Name = request.Name ?? stadium.Name;
    stadium.NameAr = request.NameAr ?? stadium.NameAr;
    stadium.Location = request.Location ?? stadium.Location;
  }
}
