using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using Ardalis.Specification;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class GetStatisticByIdEventHandler : IRequestHandler<GetStatisticByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchStatistic> _repository;
  private readonly IValidator<GetStatisticByIdEvent> _validator;

  public GetStatisticByIdEventHandler(IRepository<MatchStatistic> repository, IValidator<GetStatisticByIdEvent> validator)
  {
    _repository = repository;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(GetStatisticByIdEvent request, CancellationToken cancellationToken)
  {
    var isArabic = request.Language == Languages.Ar;
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var statistic = await _repository.GetBySpecAsync(new GetStatisticByIdWithDetails(request.Id), cancellationToken);
    var name = isArabic ? statistic!.StatisticsCoefficient.NameAr : statistic!.StatisticsCoefficient.Name;
    var groupName = isArabic ? statistic!.StatisticsType.NameAr : statistic!.StatisticsType.Name;
    var dto = new MatchStatisticDetailsDto(statistic!.Id, statistic.StatisticsTypeId, statistic.StatisticsCoefficientId, name, groupName, statistic.Value);
    return new OkObjectResult(dto);
  }
}