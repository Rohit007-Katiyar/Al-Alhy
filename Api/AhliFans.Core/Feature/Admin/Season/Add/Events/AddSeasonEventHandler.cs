using AhliFans.Core.Feature.Admin.Season.Add.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Season.Add.Events;

public class AddSeasonEventHandler : IRequestHandler<AddSeasonEvent,ActionResult>
{
  private readonly IRepository<Entities.Season> _seasonRepository;
  private readonly IMapper _mapper;
  public AddSeasonEventHandler(IRepository<Entities.Season> seasonRepository, IMapper mapper)
  {
    _seasonRepository = seasonRepository;
    _mapper = mapper;
  }
  public async Task<ActionResult> Handle(AddSeasonEvent request, CancellationToken cancellationToken)
  {
    var season = _mapper.Map<Entities.Season>(request);
    if (await _seasonRepository.AnyAsync(new IsSeasonExist(request.Name,request.NameAr,request.StartDate),cancellationToken))
    {
      return new BadRequestObjectResult(new AdminResponse("Sorry,same season exist already!", ResponseStatus.Error));
    }
    await _seasonRepository.AddAsync(season,cancellationToken);
    await _seasonRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
