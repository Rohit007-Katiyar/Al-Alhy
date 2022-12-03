using AhliFans.Core.Feature.Admin.MatchCenter.Substitution.GetByMatchId.DTO;
using AhliFans.Core.Feature.Admin.MatchCenter.Substitution.GetByMatchId.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.Substitution.GetByMatchId.Events;

public class GetSubstitutionEventHandler : IRequestHandler<GetSubstitutionByMatchEvent,ActionResult>
{
  private readonly IRepository<Entities.Substitution> _substitutionRepository;

  public GetSubstitutionEventHandler(IRepository<Entities.Substitution> substitutionRepository)
  {
    _substitutionRepository = substitutionRepository;
  }
  public async Task<ActionResult> Handle(GetSubstitutionByMatchEvent request, CancellationToken cancellationToken)
  {
    var substitutions =
      await _substitutionRepository.ListAsync(new GetSubstitutionByMatchId(request.MatchId), cancellationToken);

    if (substitutions.Count == 0)
      return new BadRequestObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));

    return new OkObjectResult(substitutions.Select(s=>new SubstitutionDto(s.PlayerId,request.Lang == Languages.En?s.Player?.Name!:s.Player?.NameAr!,s.SubstitutionPlayerId, request.Lang == Languages.En ? s.SubstitutionPlayer?.Name! : s.SubstitutionPlayer?.NameAr!)));
  }
}
