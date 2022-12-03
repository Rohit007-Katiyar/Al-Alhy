using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Season.ChangeStatus.Events; 
public class ChangeStatusEventHandler : IRequestHandler<ChangeSeasonStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Season> _seasonRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Season> seasonRepository)
  {
    _seasonRepository = seasonRepository;
  }
  public async Task<ActionResult> Handle(ChangeSeasonStatusEvent request, CancellationToken cancellationToken)
  {
    var season = await _seasonRepository.GetByIdAsync(request.SeasonId, cancellationToken);
    if (season is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    season.IsDeleted = !season.IsDeleted;
    await _seasonRepository.UpdateAsync(season, cancellationToken);
    await _seasonRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(season.IsDeleted ? "Delete Season Done You Can Retrieve It Any Time" : "Retrieve Season Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
