using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class GetStatisticGroupByIdEventHandler : IRequestHandler<GetStatisticGroupByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchStatisticsType> _repository;

  private readonly IMapper _mapper;

  private readonly IValidator<GetStatisticGroupByIdEvent> _validator;

  public GetStatisticGroupByIdEventHandler(IRepository<Entities.MatchStatisticsType> repository, IMapper mapper, IValidator<GetStatisticGroupByIdEvent> validator)
  {
    _repository = repository;
    _mapper = mapper;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(GetStatisticGroupByIdEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var statGroup = await _repository.GetByIdAsync(request.StatisticGroupId, cancellationToken);
    var dto = _mapper.Map<StatisticGroupDetailsDto>(statGroup);

    return new OkObjectResult(dto);
  }
}
