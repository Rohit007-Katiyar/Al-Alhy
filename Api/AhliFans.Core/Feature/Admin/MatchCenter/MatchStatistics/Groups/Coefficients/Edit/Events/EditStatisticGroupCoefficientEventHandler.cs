using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class EditStatisticGroupCoefficientEventHandler : IRequestHandler<EditStatisticGroupCoefficientEvent, ActionResult>
{
  private readonly IValidator<EditStatisticGroupCoefficientEvent> _validator;

  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IRepository<Entities.MatchStatisticsTypeCoefficient> _coefficientsRepository;

  private readonly IMapper _mapper;

  public EditStatisticGroupCoefficientEventHandler(IMapper mapper, IRepository<MatchStatisticsTypeCoefficient> coefficientsRepository, IHttpContextAccessor httpContextAccessor, IValidator<EditStatisticGroupCoefficientEvent> validator)
  {
    _mapper = mapper;
    _coefficientsRepository = coefficientsRepository;
    _httpContextAccessor = httpContextAccessor;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(EditStatisticGroupCoefficientEvent request, CancellationToken cancellationToken)
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

    var coefficient = await _coefficientsRepository.GetByIdAsync(request.Id, cancellationToken);

    _mapper.Map<EditStatisticGroupCoefficientEvent, Entities.MatchStatisticsTypeCoefficient>(request, coefficient!);

    coefficient!.ModifiedBy = adminIdGuid;

    await _coefficientsRepository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Operation successfull", ResponseStatus.Success);

    return new OkObjectResult(response);
  }
}
