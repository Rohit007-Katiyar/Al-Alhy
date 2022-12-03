using AhliFans.Core.Feature.Admin.Jersey.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Jersey.GetAll.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.GetAll.Events;

public class GetAllJerseysEventHandler : IRequestHandler<GetAllJerseysEvent, ActionResult>
{
  private readonly IRepository<Entities.Jersey> _jerseyRepository;

  public GetAllJerseysEventHandler(IRepository<Entities.Jersey> jerseyRepository)
  {
    _jerseyRepository = jerseyRepository;
  }

  public async Task<ActionResult> Handle(GetAllJerseysEvent request, CancellationToken cancellationToken)
  {
    var jerseys = await _jerseyRepository.ListAsync(new GetAllJerseys(request.PageIndex, request.PageSize, request.IsEnabled, request.IsHome), cancellationToken);
    if (jerseys.Count == 0) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(jerseys.Select(j => new JerseysDto(j.Id, j.IsHome, j.CreatedOn, j.ModifiedOn, j.IsEnabled, j.CreatedBy?.FullName!, j.CreatedById, j.ModifiedBy?.FullName!, j.ModifiedById, request.ImagePathUrl + j.Id)));
  }
}
