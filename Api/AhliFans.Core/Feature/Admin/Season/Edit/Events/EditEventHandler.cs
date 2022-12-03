using AhliFans.Core.Feature.Admin.Season.Add.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Season.Edit.Events;

public class EditEventHandler : IRequestHandler<EditSeasonEvent,ActionResult>
{
  private readonly IRepository<Entities.Season> _seasonRepository;
  public EditEventHandler(IRepository<Entities.Season> seasonRepository)
  {
    _seasonRepository = seasonRepository;
  }
  public async Task<ActionResult> Handle(EditSeasonEvent request, CancellationToken cancellationToken)
  {
    var season = await _seasonRepository.GetByIdAsync(request.SeasonId,cancellationToken);
    if(season == null) return new BadRequestObjectResult(new AdminResponse("Not found",ResponseStatus.Error));
    if (await _seasonRepository.AnyAsync(new IsSeasonExist(request.Name!, request.NameAr!, (DateTime) request.StartDate!), cancellationToken))
    {
      return new BadRequestObjectResult(new AdminResponse("Sorry,same season exist already!", ResponseStatus.Error));
    }

    season.Name = request.Name ?? season.Name;
    season.NameAr = request.NameAr ?? season.NameAr;
    season.StartDate = request.StartDate ?? season.StartDate;
    season.EndDate = request.EndDate ?? season.EndDate;

    await _seasonRepository.UpdateAsync(season, cancellationToken);
    await _seasonRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
