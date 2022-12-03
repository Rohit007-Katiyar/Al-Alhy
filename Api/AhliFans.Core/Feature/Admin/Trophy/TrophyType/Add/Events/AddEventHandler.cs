using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.Add.Events;

public class AddEventHandler : IRequestHandler<AddTrophyTypeEvent,ActionResult>
{
  private readonly IRepository<Entities.TrophyType> _trophyTypeRepository;
  public AddEventHandler(IRepository<Entities.TrophyType> trophyTypeRepository)
  {
    _trophyTypeRepository = trophyTypeRepository;
  }
  public async Task<ActionResult> Handle(AddTrophyTypeEvent request, CancellationToken cancellationToken)
  {
    var trophyType = new Entities.TrophyType
    {
      Name = request.Name,
      NameAr = request.NameAr,
      Date = DateTime.Now
    };
    await _trophyTypeRepository.AddAsync(trophyType, cancellationToken);
    await _trophyTypeRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation Done Successfully", ResponseStatus.Success));
  }
}
