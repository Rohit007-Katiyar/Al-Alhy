using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Stadium.ChangeStatus.Events; 
public class ChangeStadiumEventHandler : IRequestHandler<ChangeStadiumStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Stadium> _stadiumRepository;

  public ChangeStadiumEventHandler(IRepository<Entities.Stadium> stadiumRepository)
  {
    _stadiumRepository = stadiumRepository;
  }
  public async Task<ActionResult> Handle(ChangeStadiumStatusEvent request, CancellationToken cancellationToken)
  {
    var stadium = await _stadiumRepository.GetByIdAsync(request.StadiumId, cancellationToken);
    if (stadium is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    stadium.IsDeleted = !stadium.IsDeleted;
    await _stadiumRepository.UpdateAsync(stadium, cancellationToken);
    await _stadiumRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(stadium.IsDeleted ? "Delete Stadium Done You Can Retrieve It Any Time" : "Retrieve Stadium Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
