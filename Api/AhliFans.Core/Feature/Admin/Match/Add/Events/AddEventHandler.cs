using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.Add.Events;

public class AddEventHandler : IRequestHandler<AddMatchEvent, ActionResult>
{
  private readonly IRepository<Entities.Match> _matchRepository;
  private readonly IMapper _mapper;

  public AddEventHandler(IRepository<Entities.Match> matchRepository, IMapper mapper)
  {
    _matchRepository = matchRepository;
    _mapper = mapper;
  }
  public async Task<ActionResult> Handle(AddMatchEvent request, CancellationToken cancellationToken)
  {
    var match = _mapper.Map<Entities.Match>(request);

    if (match.PlannedDate > match.ActualDate)
      return new BadRequestObjectResult(new AdminResponse("Can't set Actual Date before Planned date",
        ResponseStatus.Error));
    if (request.MatchType == MatchTypes.All)
    {
      return new BadRequestObjectResult(new AdminResponse("Can't set match type to all",
        ResponseStatus.Error));
    }

    await _matchRepository.AddAsync(match, cancellationToken);
    await _matchRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
