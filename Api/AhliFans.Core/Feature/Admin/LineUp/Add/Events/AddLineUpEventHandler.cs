using AhliFans.Core.Feature.Admin.LineUp.Add.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.LineUp.Add.Events;

public class AddLineUpEventHandler : IRequestHandler<AddLineUpEvent,ActionResult>
{
  private readonly IRepository<MatchLineUp> _lineUpRepository;
  private readonly IRepository<MatchPlayer> _matchPlayerRepository;

  public AddLineUpEventHandler(IRepository<MatchLineUp> lineUpRepository, IRepository<MatchPlayer> matchPlayerRepository)
  {
    _lineUpRepository = lineUpRepository;
    _matchPlayerRepository = matchPlayerRepository;
  }
  public async Task<ActionResult> Handle(AddLineUpEvent request, CancellationToken cancellationToken)
  {
    if (await _lineUpRepository.AnyAsync(new IsMatchHasLineUp(request.MatchId),cancellationToken))
      return new BadRequestObjectResult(new AdminResponse("The match already has a line up",ResponseStatus.Error));

    if (request.IsSubstitute.Count(x => x) > 5)
      return new BadRequestObjectResult(new AdminResponse("Can't be more than 5 substitution", ResponseStatus.Error));
    var lineupCount = request.IsSubstitute.Count(x => !x);
    if (lineupCount != 11)
      return new BadRequestObjectResult(new AdminResponse("Lineup must be 11 players", ResponseStatus.Error));
    
    int indexCounter = 0;
    foreach (var player in request.PlayersList)
    {
      await _lineUpRepository.AddAsync(new MatchLineUp()
      {
        Date = DateTime.Now, 
        MatchId = request.MatchId,
        PlayerId = player,
        IsSubstitute = request.IsSubstitute[indexCounter],
        PositionId = request.PositionList[indexCounter]
      },cancellationToken);
      await _lineUpRepository.SaveChangesAsync(cancellationToken);
      indexCounter++;
    }
    await AddMatchPlayers(request.PlayersList, request.MatchId);
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
  public async Task AddMatchPlayers(List<int> players,int matchId)
  {
    foreach (var player in players)
    {
      await _matchPlayerRepository.AddAsync(new MatchPlayer()
      {
        PlayerId = player,
        MatchId = matchId,
        IsAvailable = true,
        Date = DateTime.Now
      });
      await _matchPlayerRepository.SaveChangesAsync();
    }
  }
}
