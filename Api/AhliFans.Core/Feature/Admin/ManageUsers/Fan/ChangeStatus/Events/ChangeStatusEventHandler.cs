using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.ChangeStatus.Events;
public class ChangeStatusEventHandler : IRequestHandler<ChangeStatusEvent,ActionResult>
{
  private readonly ILogger<ChangeStatusEventHandler> _logger;
  private readonly IRepository<Security.Entities.Fan> _fanRepository;
  public ChangeStatusEventHandler(ILogger<ChangeStatusEventHandler> logger, IRepository<Security.Entities.Fan> fanRepository)
  {
    _logger = logger;
    _fanRepository = fanRepository;
  }
  public async Task<ActionResult> Handle(ChangeStatusEvent request, CancellationToken cancellationToken)
  {
    var fan = await _fanRepository.GetByIdAsync(request.FanId,cancellationToken);
    if (fan == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return await ChangeStatus(fan,fan.IsBlocked);
  }
  private async Task<ActionResult> ChangeStatus(Security.Entities.Fan fan,bool status)
  {
    fan.IsBlocked = !status;
    await _fanRepository.UpdateAsync(fan);
    await _fanRepository.SaveChangesAsync();
    
    _logger.LogInformation(ResponseMessage(status) +"of user-"+fan.Id);
    return new OkObjectResult(new AdminResponse(ResponseMessage(status),
      ResponseStatus.Success));
  }
  private static string ResponseMessage(bool status)
  {
    return status ? "Activate Fan done, You can deactivate him at any time." : "Deactivate Fan done, You can Activate him at any time.";
  }
}
