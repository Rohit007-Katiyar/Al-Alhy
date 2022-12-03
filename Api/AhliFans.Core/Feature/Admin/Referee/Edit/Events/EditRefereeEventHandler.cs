using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Referee.Edit.Events;

public class EditRefereeEventHandler : IRequestHandler<EditRefereeEvent,ActionResult>
{
  private readonly IRepository<Entities.Referee> _refereeRepository;

  public EditRefereeEventHandler(IRepository<Entities.Referee> refereeRepository)
  {
    _refereeRepository = refereeRepository;
  }
  public async Task<ActionResult> Handle(EditRefereeEvent request, CancellationToken cancellationToken)
  {
    var referee = await _refereeRepository.GetByIdAsync(request.RefereeId, cancellationToken);
    if (referee == null) return new BadRequestObjectResult(new AdminResponse("Not Found",ResponseStatus.Error));

    MapReferee(request,ref referee);
    await _refereeRepository.UpdateAsync(referee, cancellationToken);
    await _refereeRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private static void MapReferee(EditRefereeEvent request,ref Entities.Referee referee)
  {
    referee.RegionId = request.RegionId ?? referee.RegionId;
    referee.Name = request.Name ?? referee.Name;
    referee.NameAr = request.NameAr ?? referee.NameAr;
    referee.NationalityId = request.NationalityId ?? referee.NationalityId;
  }
}
