using AhliFans.Core.Feature.Admin.Stadium.GetById.DTO;
using AhliFans.Core.Feature.Admin.Stadium.GetById.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Stadium.GetById.Events;

public class GetByIdEventHandler : IRequestHandler<GetStadiumByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.Stadium> _stadiumRepository;

  public GetByIdEventHandler(IRepository<Entities.Stadium> stadiumRepository)
  {
    _stadiumRepository = stadiumRepository;
  }
  public async Task<ActionResult> Handle(GetStadiumByIdEvent request, CancellationToken cancellationToken)
  {
    var stadium = await _stadiumRepository.GetBySpecAsync(new GetStadiumById(request.StadiumId), cancellationToken);
    if (stadium is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    return new OkObjectResult(new StadiumDto(stadium.Id,stadium.Region?.Id.ToString()! ,request.Lang == Languages.En ? stadium.Region?.Name!:stadium.Region?.NameAr!, 
      stadium.Name , stadium.NameAr,stadium.Location?.Split(',')[0]!, stadium.Location?.Split(',')[1]!));
  }
}
