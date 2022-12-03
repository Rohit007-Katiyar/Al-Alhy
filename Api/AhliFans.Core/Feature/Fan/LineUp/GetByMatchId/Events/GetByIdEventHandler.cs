using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.LineUp.GetByMatchId.DTO;
using AhliFans.Core.Feature.Fan.LineUp.GetByMatchId.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.LineUp.GetByMatchId.Events;

public class GetByIdEventHandler : IRequestHandler<GetLineUpByIdEvent,ActionResult>
{
  private readonly IRepository<MatchLineUp> _lineUpRepository;

  public GetByIdEventHandler(IRepository<MatchLineUp> lineUpRepository)
  {
    _lineUpRepository = lineUpRepository;
  }
  public async Task<ActionResult> Handle(GetLineUpByIdEvent request, CancellationToken cancellationToken)
  {
    var lineUp = await _lineUpRepository.ListAsync(new GetLineUpByMatchId(request.MatchId,request.IsSubstitution),cancellationToken);
    if (lineUp.Count == 0) return new OkObjectResult(Enumerable.Empty<LineUpDto>());

    return new OkObjectResult(lineUp.Select(l=>new LineUpDto(l.PlayerId,request.Lang == Languages.En ? l.Player.Name! : l.Player.NameAr!,
      request.Lang == Languages.En ? l.Position?.Name! : l.Position?.NameAr!, l.Position?.Symbol!,
      l.IsSubstitute)));
  }
}
