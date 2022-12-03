using AhliFans.Core.Feature.Admin.MatchCenter.Substitution.Create.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.Substitution.Create;

public class CreateSubstitutionEventHandler : IRequestHandler<CreateSubstitutionEvent,ActionResult>
{
  private readonly IRepository<Entities.Substitution> _substitutionRepository;
  private readonly IRepository<MatchPlayer> _matchPlayerRepository;

  public CreateSubstitutionEventHandler(IRepository<Entities.Substitution> substitutionRepository, IRepository<MatchPlayer> matchPlayerRepository)
  {
    _substitutionRepository = substitutionRepository;
    _matchPlayerRepository = matchPlayerRepository;
  }
  public async Task<ActionResult> Handle(CreateSubstitutionEvent request, CancellationToken cancellationToken)
  {
    if (request.PlayerId == request.SubstitutionPlayer)
      return new BadRequestObjectResult(new AdminResponse("Bad players Id", ResponseStatus.Error)); 
    if (await _substitutionRepository.AnyAsync(new IsPlayerChangedBefore(request.MatchId,request.PlayerId),cancellationToken))
      return new BadRequestObjectResult(new AdminResponse("You changed this player before", ResponseStatus.Error));

    await _substitutionRepository.AddAsync(new Entities.Substitution()
    {
      PlayerId = request.PlayerId,
      SubstitutionPlayerId = request.SubstitutionPlayer,
      MatchId = request.MatchId,
      Date = DateTime.Now
    },cancellationToken);
    await _substitutionRepository.SaveChangesAsync(cancellationToken);
    await AddMatchPlayers(request.SubstitutionPlayer,request.MatchId);
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
  public async Task AddMatchPlayers(int substitutionPlayer, int matchId)
  {
    await _matchPlayerRepository.AddAsync(new MatchPlayer()
    {
      PlayerId = substitutionPlayer,
      MatchId = matchId,
      IsAvailable = true,
      Date = DateTime.Now
    });
    await _matchPlayerRepository.SaveChangesAsync();
    
  }
}
