using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.ChangeStatus.Events;
public class ChangeJerseyStatusEventHandler : IRequestHandler<ChangeJerseyStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Jersey> _jerseyRepository;

  public ChangeJerseyStatusEventHandler(IRepository<Entities.Jersey> jerseyRepository)
  {
    _jerseyRepository = jerseyRepository;
  }

  public async Task<ActionResult> Handle(ChangeJerseyStatusEvent request, CancellationToken cancellationToken)
  {
    var jersey = await _jerseyRepository.GetByIdAsync(request.JerseyId, cancellationToken);
    if (jersey is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    jersey.IsEnabled = !jersey.IsEnabled;
    jersey.ModifiedById = Guid.Parse(request.AdminId);
    jersey.ModifiedOn = DateTime.Now;
    await _jerseyRepository.UpdateAsync(jersey, cancellationToken);
    await _jerseyRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(jersey.IsEnabled ? "Enable Jersey Done. You Can Disable It Any Time" : "Disable Jersey Done. You Can Enable It Any Time", ResponseStatus.Success));
  }
}
