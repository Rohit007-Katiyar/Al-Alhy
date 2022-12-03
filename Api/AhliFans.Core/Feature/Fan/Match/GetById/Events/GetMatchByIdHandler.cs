using AhliFans.Core.Feature.Fan.Match.GetById.DTO;
using AhliFans.Core.Feature.Fan.Match.GetById.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Match.GetById.Events;

public class GetMatchByIdHandler : IRequestHandler<GetMatchByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.Match> _repository;

  private readonly IMapper _mapper;

  public GetMatchByIdHandler(IRepository<Entities.Match> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  public async Task<ActionResult> Handle(GetMatchByIdEvent request, CancellationToken cancellationToken)
  {
    var match = await _repository.GetBySpecAsync(new GetMatchById(request.MatchId), cancellationToken);
    if (match == null) return new NotFoundResult();

    var dto = _mapper.Map<MatchDetailsDto>(match);

    dto.StadiumName = request.Language == Languages.Ar ? match.Stadium.NameAr : match.Stadium.Name;
    dto.OpponentTeamName = request.Language == Languages.Ar ? match.OpponentTeam.NameAr : match.OpponentTeam.Name;
    dto.LeagueName = request.Language == Languages.Ar ? match.League.NameAr : match.League.Name;
    dto.PlannedDate = match.PlannedDate.ToString("MMMM dd");
    dto.MatchBroadcastChannels = request.Language == Languages.Ar ? match.BroadcastChannel?.NameAr! : match.BroadcastChannel?.Name!;

    return new OkObjectResult(dto);
  }
}
