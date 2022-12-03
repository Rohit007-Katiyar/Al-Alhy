using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class GetAllStatisticGroupCoefficientsEventHandler : IRequestHandler<GetAllStatisticGroupCoefficientsEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchStatisticsTypeCoefficient> _coefficientsRepository;

  private readonly IValidator<GetAllStatisticGroupCoefficientsEvent> _validator;

  public GetAllStatisticGroupCoefficientsEventHandler(IRepository<MatchStatisticsTypeCoefficient> coefficientsRepository, IValidator<GetAllStatisticGroupCoefficientsEvent> validator)
  {
    _coefficientsRepository = coefficientsRepository;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(GetAllStatisticGroupCoefficientsEvent request, CancellationToken cancellationToken)
  {
    var isArabic = request.Language == Languages.Ar;
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var statisticGroupCoefficients = await _coefficientsRepository.ListAsync(new GetStatisticGroupCoefficients(request.StatisticTypeId, request.PageIndex, request.PageSize, request.Name), cancellationToken);

    var dtos = statisticGroupCoefficients.Select(gc => 
    {
      var name = isArabic ? gc.NameAr : gc.Name;
      var id = gc.Id;
      var isPercentage = gc.IsPercentage;
      var groupId = gc.MatchStatisticsTypeId;
      return new StatisticGroupCoefficientDto(id, name, isPercentage, groupId);
    }).ToList();

    return new OkObjectResult(dtos);
  }
}
