using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics.GetByMatchId.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics;

public class GetByMatchIdEventHandler : IRequestHandler<GetByMatchIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchStatistic> _repository;

  private readonly IRepository<Entities.MatchCard> _cardsRepository;

  private readonly IValidator<GetByMatchIdEvent> _validator;

  public GetByMatchIdEventHandler(IRepository<MatchStatistic> repository, IValidator<GetByMatchIdEvent> validator, IRepository<MatchCard> cardsRepository)
  {
    _repository = repository;
    _validator = validator;
    _cardsRepository = cardsRepository;
  }

  public async Task<ActionResult> Handle(GetByMatchIdEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new FanResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var isArabic = request.Language == Languages.Ar;
    var statistics = await _repository.ListAsync(new GetByMatchIdWithCoefficient(request.MatchId), cancellationToken);

    var dtos = statistics.Select(stat =>
    {
      var name = isArabic ? stat.StatisticsCoefficient.NameAr : stat.StatisticsCoefficient.Name;
      return new MatchStatisticDto(name, stat.Value, stat.StatisticsCoefficient.IsPercentage);
    }).ToList();

    var cards = await _cardsRepository.ListAsync(new GetMatchCards(request.MatchId), cancellationToken);
    var yellowCardsCount = cards.Count(c => !c.IsRed);
    var redCardsCount = cards.Count(c => c.IsRed);

    var statisticsDto = new MatchStatisticsDto()
    {
      Statistics = dtos,
      RedCards = redCardsCount,
      YellowCards = yellowCardsCount
    };

    return new OkObjectResult(statisticsDto);
  }
}