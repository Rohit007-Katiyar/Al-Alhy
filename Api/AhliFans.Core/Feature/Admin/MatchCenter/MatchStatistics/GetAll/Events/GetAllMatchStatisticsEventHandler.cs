using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class GetAllMatchStatisticsEventHandler : IRequestHandler<GetAllMatchStatisticsEvent, ActionResult>
{
  private readonly IRepository<MatchStatistic> _repository;

  private readonly IValidator<GetAllMatchStatisticsEvent> _validator;

  public GetAllMatchStatisticsEventHandler(IRepository<MatchStatistic> repository, IValidator<GetAllMatchStatisticsEvent> validator)
  {
    _repository = repository;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(GetAllMatchStatisticsEvent request, CancellationToken cancellationToken)
  {
    var isArabic = request.Language == Languages.Ar;
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
        var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
        return new BadRequestObjectResult(errorResponse);
    }
    var statistics = await _repository.ListAsync(new GetAllMatchStatistics(request.MatchId, request.PageIndex, request.PageSize), cancellationToken);
    var dtos = statistics.Select(s => {
      var name = isArabic ? s.StatisticsCoefficient.NameAr : s.StatisticsCoefficient.Name;
      return new MatchStatisticDto(s.Id, name, s.Value, s.StatisticsCoefficient.IsPercentage);
      }).ToList();

    return new OkObjectResult(dtos);
  }
}