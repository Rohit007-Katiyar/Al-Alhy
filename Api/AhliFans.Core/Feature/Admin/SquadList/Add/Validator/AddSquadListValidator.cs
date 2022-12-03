using AhliFans.Core.Feature.Admin.SquadList.Add.Events;
using AhliFans.Core.Feature.Admin.SquadList.Add.Specifications;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.SquadList.Add.Validator;

public class AddSquadListValidator : AbstractValidator<AddSquadListEvent>
{
  private readonly IRepository<Entities.Player> _playersRepository;

  private readonly IRepository<Entities.Match> _matchRepository;

  private readonly IRepository<Entities.SquadList> _squadRepository;
  public AddSquadListValidator(IRepository<Entities.Player> playersRepository, IRepository<Entities.Match> matchRepository, IRepository<Entities.SquadList> squadRepository)
  {
    _playersRepository = playersRepository;
    _matchRepository = matchRepository;
    _squadRepository = squadRepository;
    RuleFor(addEvent => addEvent.PlayersIds)
    .MustAsync(async (playersIds, cancellationToken) =>
    {
      var players = await _playersRepository.ListAsync(new CheckPlayersExistSpec(playersIds), cancellationToken);
      return players.Count == playersIds.Count;
    })
    .WithMessage("A player wasn't found");

    RuleFor(addEvent => addEvent.MatchId)
    .MustAsync(async (matchId, cancellationToken) =>
    {
      var match = await _matchRepository.GetByIdAsync(matchId, cancellationToken);
      return match != null;
    }).WithMessage("Match wasn't found")
    .DependentRules(() =>
    {
      RuleFor(addEvent => addEvent.MatchId)
      .MustAsync(async (matchId, cancellationToken) =>
      {
        var match = await _matchRepository.GetByIdAsync(matchId, cancellationToken);
        return match!.MatchType == MatchTypes.Current;
      }).WithMessage("Match has already started or ended");
    });

    RuleFor(addEvent => addEvent)
    .MustAsync(async (addEvent, cancellationToken) =>
    {
      var squadList = await _squadRepository.ListAsync(new CheckPlayersAlreadyExistsSpec(addEvent.PlayersIds, addEvent.MatchId), cancellationToken);
      return squadList.Count == 0;
    }).WithMessage("Player already exists in squad list");



  }
}
