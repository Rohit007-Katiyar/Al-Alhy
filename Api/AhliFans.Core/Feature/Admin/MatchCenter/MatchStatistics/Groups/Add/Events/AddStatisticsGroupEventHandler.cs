using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class AddStatisticsGroupEventHandler : IRequestHandler<AddStatisticsGroupEvent, ActionResult>
{
  private readonly IValidator<AddStatisticsGroupEvent> _validator;

  private readonly IRepository<Entities.MatchStatisticsType> _statsGroupsRepository;

  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IMapper _mapper;

  public AddStatisticsGroupEventHandler(IValidator<AddStatisticsGroupEvent> validator, IRepository<Entities.MatchStatisticsType> statsGroupsRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
  {
    _validator = validator;
    _statsGroupsRepository = statsGroupsRepository;
    _httpContextAccessor = httpContextAccessor;
    _mapper = mapper;
  }

  public async Task<ActionResult> Handle(AddStatisticsGroupEvent request, CancellationToken cancellationToken)
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

    var statisticGroup = _mapper.Map<Entities.MatchStatisticsType>(request);
    var adminIdGuid = Guid.Parse(adminId);
    statisticGroup.CreatedBy = adminIdGuid;
    statisticGroup.ModifiedBy = adminIdGuid;

    await _statsGroupsRepository.AddAsync(statisticGroup, cancellationToken);
    await _statsGroupsRepository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Statistic group added successfully", ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}
