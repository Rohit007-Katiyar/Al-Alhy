using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class AddMatchCardEventHandler : IRequestHandler<AddMatchCardEvent, ActionResult>
{
  private readonly IValidator<AddMatchCardEvent> _validator;
  private readonly IRepository<MatchCard> _repository;

  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IMapper _mapper;

  public AddMatchCardEventHandler(IHttpContextAccessor httpContextAccessor, IRepository<MatchCard> repository, IValidator<AddMatchCardEvent> validator, IMapper mapper)
  {
    _httpContextAccessor = httpContextAccessor;
    _repository = repository;
    _validator = validator;
    _mapper = mapper;
  }

  public async Task<ActionResult> Handle(AddMatchCardEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), SharedKernel.Enum.ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var claims = _httpContextAccessor.HttpContext.User.Claims;
    var adminId = claims.First(c => c.Type == "User Id").Value;
    var adminIdGuid = Guid.Parse(adminId);

    var matchCard = _mapper.Map<MatchCard>(request);
    matchCard.CreatedBy = adminIdGuid;
    matchCard.ModifiedBy = adminIdGuid;

    await _repository.AddAsync(matchCard, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Match card added successfully", ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}