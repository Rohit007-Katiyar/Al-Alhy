using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class EditStatisticGroupEventHandler : IRequestHandler<EditStatisticGroupEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchStatisticsType> _statsGroupsRepository;

  private readonly IMapper _mapper;

  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IValidator<EditStatisticGroupEvent> _validator;

  public EditStatisticGroupEventHandler(IValidator<EditStatisticGroupEvent> validator, IHttpContextAccessor httpContextAccessor, IMapper mapper, IRepository<Entities.MatchStatisticsType> statsGroupsRepository)
  {
    _validator = validator;
    _httpContextAccessor = httpContextAccessor;
    _mapper = mapper;
    _statsGroupsRepository = statsGroupsRepository;
  }

  public async Task<ActionResult> Handle(EditStatisticGroupEvent request, CancellationToken cancellationToken)
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

    var statisticGroup = await _statsGroupsRepository.GetByIdAsync(request.Id, cancellationToken);

    _mapper.Map<EditStatisticGroupEvent, Entities.MatchStatisticsType>(request, statisticGroup!);
    statisticGroup!.ModifiedBy = adminIdGuid;

    await _statsGroupsRepository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Statistic group updated successfully", ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}
