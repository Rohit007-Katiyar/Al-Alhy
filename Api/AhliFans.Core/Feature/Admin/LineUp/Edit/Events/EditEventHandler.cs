using AhliFans.Core.Feature.Admin.LineUp.Edit.Specifications;
using AhliFans.Core.Feature.Admin.LineUp.GetById.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.LineUp.Edit.Events;

public class EditEventHandler : IRequestHandler<EditLineUpEvent,ActionResult>
{
  private readonly IRepository<MatchLineUp> _lineRepository;
  private readonly IRepository<MatchPlayer> _matchPlayerRepository;

  public EditEventHandler(IRepository<MatchLineUp> lineRepository, IRepository<MatchPlayer> matchPlayerRepository)
  {
    _lineRepository = lineRepository;
    _matchPlayerRepository = matchPlayerRepository;
  }
  public async Task<ActionResult> Handle(EditLineUpEvent request, CancellationToken cancellationToken)
  {
    var matchLineUp = await _lineRepository.ListAsync(new GetLineUpByMatchId(request.MatchId), cancellationToken);
    if (matchLineUp.Count == 0) return new BadRequestObjectResult(new AdminResponse("No data", ResponseStatus.Error));

    await _lineRepository.DeleteRangeAsync(matchLineUp,cancellationToken);
    await _lineRepository.SaveChangesAsync(cancellationToken);

    await DeleteMatchPlayers(request, cancellationToken);

    await NewLineUp(request, cancellationToken);
    await AddMatchPlayers(request.PlayersList, request.MatchId);
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private async Task DeleteMatchPlayers(EditLineUpEvent request, CancellationToken cancellationToken)
  {
    var matchPlayers =
      await _matchPlayerRepository.ListAsync(new GetAllMatchPlayersByMatchId(request.MatchId), cancellationToken);
    await _matchPlayerRepository.DeleteRangeAsync(matchPlayers, cancellationToken);
    await _matchPlayerRepository.SaveChangesAsync(cancellationToken);
  }

  private async Task NewLineUp(EditLineUpEvent request, CancellationToken cancellationToken)
  {
    int indexCounter = 0;
    foreach (var player in request.PlayersList)
    {
      await _lineRepository.AddAsync(new MatchLineUp()
      {
        Date = DateTime.Now,
        MatchId = request.MatchId,
        PlayerId = player,
        IsSubstitute = request.IsSubstitute[indexCounter],
        PositionId = request.PositionList[indexCounter]
      }, cancellationToken);
      await _lineRepository.SaveChangesAsync(cancellationToken);
      indexCounter++;
    }
  }
  public async Task AddMatchPlayers(List<int> players, int matchId)
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
