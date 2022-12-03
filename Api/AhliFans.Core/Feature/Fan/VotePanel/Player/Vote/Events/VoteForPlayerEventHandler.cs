using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.VotePanel.Player.Vote.Specification;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.VotePanel.Player.Vote.Events;

public class VoteForPlayerEventHandler : IRequestHandler<VoteForPlayerEvent, ActionResult>
{
  private readonly IRepository<PlayerVote> _voteRepository;
  private readonly IRepository<Entities.Match> _matchRepository;
  private readonly string _userId;
  public VoteForPlayerEventHandler(IHttpContextAccessor context, IRepository<PlayerVote> voteRepository, IRepository<Entities.Match> matchRepository)
  {
    _voteRepository = voteRepository;
    _matchRepository = matchRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(VoteForPlayerEvent request, CancellationToken cancellationToken)
  {
    if (await _voteRepository.AnyAsync(new IsUserVoteBefore(Guid.Parse(_userId), request.MatchId), cancellationToken))
      return new BadRequestObjectResult(new FanResponse("User voted before", ResponseStatus.Error));

    var match = await _matchRepository.GetByIdAsync(request.MatchId, cancellationToken);
    if (match == null) return new NotFoundObjectResult(new FanResponse("Error match", ResponseStatus.Error));

    var isMatchToday = match.ActualDate!.Value.Date == DateTime.Now.Date;

    var matchTime = TimeOnly.Parse(match.ActualTime!);
    var matchTimeSpan = new TimeSpan(0, matchTime.Hour, matchTime.Minute, matchTime.Second);

    var timeDifference = DateTime.Now.TimeOfDay - matchTimeSpan;

    var isMatchOverByAnHour = timeDifference == TimeSpan.FromHours(1);

    if (!isMatchToday || isMatchOverByAnHour)
      return new BadRequestObjectResult(new FanResponse("Vote Time Out", ResponseStatus.Error));

    await _voteRepository.AddAsync(new PlayerVote()
    {
      PlayerId = request.PlayerId,
      MatchId = request.MatchId,
      Time = DateTime.Now,
      FanId = Guid.Parse(_userId)
    }, cancellationToken);
    await _voteRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new FanResponse("Operation done successfully", ResponseStatus.Success));
  }
}
