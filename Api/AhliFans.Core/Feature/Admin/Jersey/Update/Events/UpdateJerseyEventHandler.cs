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

namespace AhliFans.Core.Feature.Admin.Jersey.Update.Events;
internal class UpdateJerseyEventHandler : IRequestHandler<UpdateJerseyEvent, ActionResult>
{
  private readonly IRepository<Entities.Jersey> _jerseyRepository;

  public UpdateJerseyEventHandler(IRepository<Entities.Jersey> jerseyRepository)
  {
    _jerseyRepository = jerseyRepository;
  }

  public async Task<ActionResult> Handle(UpdateJerseyEvent request, CancellationToken cancellationToken)
  {
    var jersey = await _jerseyRepository.GetByIdAsync(request.JerseyId, cancellationToken);
    if (jersey is null) return new BadRequestObjectResult(new AdminResponse("Not Found", ResponseStatus.Error));

    MapJersey(request, ref jersey);
    await _jerseyRepository.UpdateAsync(jersey, cancellationToken);
    await _jerseyRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully.", ResponseStatus.Success));
  }

  private static void MapJersey(UpdateJerseyEvent request, ref Entities.Jersey jersey)
  {
    jersey.IsHome = request.IsHome;
    jersey.ModifiedById = Guid.Parse(request.AdminId);
    jersey.ModifiedOn = DateTime.Now;
  }
}
