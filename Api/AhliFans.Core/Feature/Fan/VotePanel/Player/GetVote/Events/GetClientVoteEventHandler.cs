using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.VotePanel.Player;

public class GetClientVoteEventHandler : IRequestHandler<GetClientVoteEvent, ActionResult>
{
  private readonly IRepository<Entities.PlayerVote> _playerVotesRepository;

  private readonly IHttpContextAccessor _httpContextAccessor;

  public GetClientVoteEventHandler(IRepository<PlayerVote> playerVotesRepository, IHttpContextAccessor httpContextAccessor)
  {
    _playerVotesRepository = playerVotesRepository;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<ActionResult> Handle(GetClientVoteEvent request, CancellationToken cancellationToken)
  {
    var claims = _httpContextAccessor.HttpContext.User.Claims;
    var fanId = Guid.Parse(claims.First(c => c.Type == "User Id").Value);

    var clientVote = await _playerVotesRepository.GetBySpecAsync(new GetClientVoteWithPlayer(fanId), cancellationToken);
    if (clientVote == null)
    {
      var errorResponse = new FanResponse("You haven't voted", ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var name = request.Language == Languages.Ar ? clientVote.Player.NameAr : clientVote.Player.Name;
    var clientVoteDto = new ClientVoteDetailsDto(clientVote.PlayerId, name!);

    return new OkObjectResult(clientVoteDto);
  }
}
