using AhliFans.Core.Feature.Admin.Stadium.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Stadium;

public class AddStadiumEndPoint : EndpointBaseAsync
  .WithRequest<AddStadiumRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddStadiumEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddStadiumRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add New Stadium",
    Description = "Admin Add New Stadium",
    OperationId = "Admin.AddStadium",
    Tags = new[] {"Stadium Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddStadiumRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddStadiumEvent(request.Name, request.NameAr, request.RegionId, request.Location),cancellationToken);
}
