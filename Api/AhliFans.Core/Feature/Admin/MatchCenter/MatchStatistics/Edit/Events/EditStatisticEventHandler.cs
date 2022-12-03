using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class EditStatisticEventHandler : IRequestHandler<EditStatisticEvent, ActionResult>
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IRepository<Entities.MatchStatistic> _repository;

  private readonly IMapper _mapper;

  private readonly IValidator<EditStatisticEvent> _validator;

  public EditStatisticEventHandler(IHttpContextAccessor httpContextAccessor, IRepository<Entities.MatchStatistic> repository, IMapper mapper, IValidator<EditStatisticEvent> validator)
  {
    _httpContextAccessor = httpContextAccessor;
    _repository = repository;
    _mapper = mapper;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(EditStatisticEvent request, CancellationToken cancellationToken)
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

    var statistic = await _repository.GetByIdAsync(request.Id, cancellationToken);
    statistic!.ModifiedBy = adminIdGuid;

    _mapper.Map<EditStatisticEvent, Entities.MatchStatistic>(request, statistic);

    await _repository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Statistic updated successfully", ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}
