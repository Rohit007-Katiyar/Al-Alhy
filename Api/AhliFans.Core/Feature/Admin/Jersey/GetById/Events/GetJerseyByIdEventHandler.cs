using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.Jersey.GetById.DTO;
using AhliFans.Core.Feature.Admin.Jersey.GetById.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.GetById.Events;
public class GetJerseyByIdEventHandler : IRequestHandler<GetJerseyByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.Jersey> _jerseyRepository;

  public GetJerseyByIdEventHandler(IRepository<Entities.Jersey> jerseyRepository)
  {
    _jerseyRepository = jerseyRepository;
  }

  public async Task<ActionResult> Handle(GetJerseyByIdEvent request, CancellationToken cancellationToken)
  {
    var jersey = await _jerseyRepository.GetBySpecAsync(new GetJerseyById(request.JerseyId), cancellationToken);
    if (jersey is null)
      return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new JerseyDto(jersey.Id, jersey.IsHome, jersey.CreatedOn, jersey.ModifiedOn, jersey.IsEnabled, jersey.CreatedBy.FullName, jersey.CreatedById, jersey.ModifiedBy?.FullName, jersey.ModifiedById));
  }
}
