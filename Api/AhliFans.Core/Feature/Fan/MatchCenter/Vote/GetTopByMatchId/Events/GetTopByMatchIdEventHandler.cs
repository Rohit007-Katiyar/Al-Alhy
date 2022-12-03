using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.MatchCenter.Vote.GetTopByMatchId.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Vote;

public class GetTopByMatchIdEventHandler : IRequestHandler<GetTopByMatchIdEvent, ActionResult>
{
  private readonly IRepository<Entities.PlayerVote> _votesRepository;

  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IValidator<GetTopByMatchIdEvent> _validator;

  private readonly ICustomQueryRepository _customQueryRepository;

  public GetTopByMatchIdEventHandler(IRepository<PlayerVote> votesRepository, IHttpContextAccessor httpContextAccessor, IValidator<GetTopByMatchIdEvent> validator, ICustomQueryRepository customQueryRepository)
  {
    _votesRepository = votesRepository;
    _httpContextAccessor = httpContextAccessor;
    _validator = validator;
    _customQueryRepository = customQueryRepository;
  }

  public async Task<ActionResult> Handle(GetTopByMatchIdEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new FanResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var claims = _httpContextAccessor.HttpContext.User.Claims;
    var fanId = Guid.Parse(claims.First(c => c.Type == "User Id").Value);

    var fanVoted = await _votesRepository.AnyAsync(new CheckFanVoted(fanId, request.MatchId), cancellationToken);
    if (!fanVoted)
    {
      var errorMessage = "Please vote first, then try again";
      var errorResponse = new FanResponse(errorMessage, ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var query = string.Format(@"SELECT TOP {0} COUNT(PlayerId) as Votes, PlayerId, Name, NameAr FROM PlayerVotes INNER JOIN Player as P ON P.Id = PlayerId WHERE MatchId = {1} GROUP BY PlayerId, Name, NameAr ORDER BY Votes DESC", request.Top, request.MatchId);
    using var customQueryRepo = _customQueryRepository;
    var votes = await customQueryRepo.ListAsync<PlayerVoteResult>(query);

    var isArabic = request.Language == Languages.Ar;

    var votesCount = await _votesRepository.CountAsync(new GetVotesByMatchId(request.MatchId), cancellationToken);
    var dtos = votes.Select(v =>
    {
      var percentage = Convert.ToDecimal(v.Votes) / votesCount;
      return new TopVoteDto
      {
        PlayerId = v.PlayerId,
        PlayerName = isArabic ? v.NameAr ?? string.Empty : v.Name ?? string.Empty,
        VotePercentage = percentage
      };
    }).ToList();

    return new OkObjectResult(dtos);
  }
}