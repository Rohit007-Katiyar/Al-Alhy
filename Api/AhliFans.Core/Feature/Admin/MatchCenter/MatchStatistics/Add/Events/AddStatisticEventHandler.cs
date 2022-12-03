using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class AddStatisticEventHandler : IRequestHandler<AddStatisticEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchStatistic> _repository;

  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IValidator<AddStatisticEvent> _validator;

  private readonly IMapper _mapper;

  public AddStatisticEventHandler(IRepository<MatchStatistic> repository, IValidator<AddStatisticEvent> validator, IMapper mapper, IHttpContextAccessor httpContextAccessor)
  {
    _repository = repository;
    _validator = validator;
    _mapper = mapper;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<ActionResult> Handle(AddStatisticEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var claims = _httpContextAccessor.HttpContext.User.Claims;
    var adminId = claims.First(c => c.Type == "User Id").Value;
    var adminIdGuid = Guid.Parse(adminId);
    var statistic = _mapper.Map<Entities.MatchStatistic>(request);
    statistic.CreatedBy = adminIdGuid;
    statistic.ModifiedBy = adminIdGuid;

    await _repository.AddAsync(statistic, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Statistic added succesfully", ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}
