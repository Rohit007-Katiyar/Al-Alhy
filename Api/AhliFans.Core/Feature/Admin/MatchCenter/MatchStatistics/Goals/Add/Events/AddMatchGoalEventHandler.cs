using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class AddMatchGoalEventHandler : IRequestHandler<AddMatchGoalEvent, ActionResult>
{
  private readonly IValidator<AddMatchGoalEvent> _validator;

  private readonly IRepository<Entities.MatchGoal> _repository;

  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IMapper _mapper;

  private readonly IRepository<Entities.Match> _matchesRepository;

  public AddMatchGoalEventHandler(IValidator<AddMatchGoalEvent> validator, IRepository<Entities.MatchGoal> repository, IHttpContextAccessor httpContextAccessor, IMapper mapper, IRepository<Entities.Match> matchesRepository)
  {
    _validator = validator;
    _repository = repository;
    _httpContextAccessor = httpContextAccessor;
    _mapper = mapper;
    _matchesRepository = matchesRepository;
  }

  public async Task<ActionResult> Handle(AddMatchGoalEvent request, CancellationToken cancellationToken)
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

    var matchGoal = _mapper.Map<Entities.MatchGoal>(request);
    matchGoal.CreatedBy = adminIdGuid;
    matchGoal.ModifiedBy = adminIdGuid;

    var match = await _matchesRepository.GetByIdAsync(matchGoal.MatchId, cancellationToken);
    if (request.IsForAhly)
    {
      match!.Score += 1;
    }
    else
    {
      match!.OpponentScore += 1;
    }

    await _repository.AddAsync(matchGoal, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Goal added successfully", ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}