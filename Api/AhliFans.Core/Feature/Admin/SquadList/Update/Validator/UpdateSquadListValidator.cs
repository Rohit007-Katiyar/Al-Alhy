using AhliFans.Core.Feature.Admin.SquadList.Update.Events;
using AhliFans.Core.Feature.Admin.SquadList.Update.Specifications;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.SquadList.Update.Validator;

public class UpdateSquadListValidator : AbstractValidator<UpdateSquadListEvent>
{

  public UpdateSquadListValidator(IRepository<Entities.Player> playersRepository, IRepository<Entities.Match> matchRepository)
  {
    RuleFor(updateEvent => updateEvent.PlayersIds)
    .MustAsync(async (playersIds, cancellationToken) =>
    {
      var players = await playersRepository.ListAsync(new CheckPlayersExist(playersIds), cancellationToken);
      return players.Count == playersIds.Count;
    }).WithMessage("A Player is not found");

    RuleFor(updateEvent => updateEvent.MatchId)
    .MustAsync(async (matchId, cancellationToken) =>
    {
      var match = await matchRepository.GetByIdAsync(matchId, cancellationToken);
      return match != null;
    })
    .WithMessage("Match isn't found")
    .DependentRules(() =>
    {
      RuleFor(updateEvent => updateEvent.MatchId)
      .MustAsync(async (matchId, cancellationToken) =>
      {
        var match = await matchRepository.GetByIdAsync(matchId, cancellationToken);
        return match!.MatchType == MatchTypes.Upcoming;
      })
      .WithMessage("Match has already started or ended");
    });

  }
}
