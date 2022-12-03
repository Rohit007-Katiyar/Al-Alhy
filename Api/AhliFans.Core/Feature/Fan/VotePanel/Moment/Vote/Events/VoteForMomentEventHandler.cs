using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.VotePanel.Moment.Vote.Events;

public class VoteForMomentEventHandler : IRequestHandler<VoteForMomentEvent,ActionResult>
{
  private readonly IRepository<MomentVote> _voteRepository;
  private readonly IRepository<Entities.Moment> _momentRepository;
  private readonly string _userId;
  public VoteForMomentEventHandler(IHttpContextAccessor context,IRepository<MomentVote> voteRepository,IRepository<Entities.Moment> momentRepository)
  {
    _voteRepository = voteRepository;
    _momentRepository = momentRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(VoteForMomentEvent request, CancellationToken cancellationToken)
  {
    var moment = await _momentRepository.GetByIdAsync(request.MomentId, cancellationToken);
    if (moment == null) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    await _voteRepository.AddAsync(new MomentVote()
    {
      Date = DateTime.Now,FanId = Guid.Parse(_userId),MomentId = request.MomentId
    },cancellationToken);
    await _voteRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully",ResponseStatus.Success));
  }
}
