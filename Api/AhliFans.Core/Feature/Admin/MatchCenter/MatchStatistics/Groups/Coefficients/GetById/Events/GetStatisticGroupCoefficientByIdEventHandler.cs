using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class GetStatisticGroupCoefficientByIdEventHandler : IRequestHandler<GetStatisticGroupCoefficientByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchStatisticsTypeCoefficient> _repository;

  private readonly IMapper _mapper;

  private readonly IValidator<GetStatisticGroupCoefficientByIdEvent> _validator;

  public GetStatisticGroupCoefficientByIdEventHandler(IRepository<MatchStatisticsTypeCoefficient> repository, IMapper mapper, IValidator<GetStatisticGroupCoefficientByIdEvent> validator)
  {
    _repository = repository;
    _mapper = mapper;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(GetStatisticGroupCoefficientByIdEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var statGroupCoefficient = await _repository.GetByIdAsync(request.StatisticGroupCoefficientId, cancellationToken);
    var dto = _mapper.Map<StatisticGroupCoefficientDetailsDto>(statGroupCoefficient);

    return new OkObjectResult(dto);
  }
}
