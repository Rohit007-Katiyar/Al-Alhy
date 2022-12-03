using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class AddStatisticGroupCoefficientEventHandler : IRequestHandler<AddStatisticGroupCoefficientEvent, ActionResult>
{
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IRepository<Entities.MatchStatisticsTypeCoefficient> _coefficientsRepository;
  private readonly IMapper _mapper;

  private readonly IValidator<AddStatisticGroupCoefficientEvent> _validator;
  public AddStatisticGroupCoefficientEventHandler(IHttpContextAccessor httpContextAccessor, IRepository<Entities.MatchStatisticsTypeCoefficient> coefficientsRepository, IMapper mapper, IValidator<AddStatisticGroupCoefficientEvent> validator)
  {
    _httpContextAccessor = httpContextAccessor;
    _coefficientsRepository = coefficientsRepository;
    _mapper = mapper;
    _validator = validator;
  }


  public async Task<ActionResult> Handle(AddStatisticGroupCoefficientEvent request, CancellationToken cancellationToken)
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

    var statisticGroupCoefficient = _mapper.Map<Entities.MatchStatisticsTypeCoefficient>(request);
    statisticGroupCoefficient.CreatedBy = adminIdGuid;
    statisticGroupCoefficient.ModifiedBy = adminIdGuid;

    await _coefficientsRepository.AddAsync(statisticGroupCoefficient, cancellationToken);
    await _coefficientsRepository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Operation successful", ResponseStatus.Success);

    return new OkObjectResult(response);
  }
}
