using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.RefreshFireBaseToken.Events;

public class FireBaseTokenEventHandler : IRequestHandler<FireBaseTokenEvent,ActionResult>
{
  private readonly IRepository<Entities.Fan> _fanRepository;
  private readonly string _userId;
  public FireBaseTokenEventHandler(IHttpContextAccessor context,IRepository<Entities.Fan> fanRepository)
  {
    _fanRepository = fanRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(FireBaseTokenEvent request, CancellationToken cancellationToken)
  {
    var fan = await _fanRepository.GetByIdAsync(Guid.Parse(_userId),cancellationToken);
    if (fan == null) return new NotFoundObjectResult(new FanResponse("Not found",ResponseStatus.Error));
    
    fan.FireBaseToken = request.Token;
    await _fanRepository.UpdateAsync(fan,cancellationToken);
    await _fanRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new FanResponse("Operation done successfully", ResponseStatus.Success));
  }
}
