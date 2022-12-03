using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class AddMatchCardValidator : AbstractValidator<AddMatchCardEvent>
{
  public AddMatchCardValidator(IRepository<Entities.Match> matchesRepository, IRepository<Entities.Player> playersRepository)
  {
    RuleFor(ev => ev.IsForAhly)
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev.Minute)
    .GreaterThanOrEqualTo(0)
    .WithMessage("{PropertyName} is invalid");

    RuleFor(ev => ev.IsRed)
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev)
    .MustAsync(async (ev, cancellationToken) =>
    {
      if (ev.PlayerId == null && !ev.IsForAhly)
      {
        return true;
      }
      else if (ev.PlayerId == null && ev.IsForAhly)
      {
        return false;
      }
      var player = await playersRepository.GetByIdAsync(ev.PlayerId ?? 0, cancellationToken);
      return player != null;
    })
    .WithMessage("{PropertyName} is invalid");

    RuleFor(ev => ev.MatchId)
    .MustAsync(async (id, cancellationToken) =>
    {
      var match = await matchesRepository.GetByIdAsync(id, cancellationToken);
      return match != null;
    })
    .DependentRules(() =>
    {
      RuleFor(ev => ev.MatchId)
      .MustAsync(async (id, cancellationToken) =>
      {
        var match = await matchesRepository.GetByIdAsync(id, cancellationToken);
        return match!.MatchType == MatchTypes.Live;
      })
      .WithMessage("Match is not live match");
    })
    .WithMessage("Match id is invalid");
  }
}
