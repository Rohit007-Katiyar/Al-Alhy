using AhliFans.Core.Feature.Admin.Region.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Region;

public class AddRegionEndPoint : EndpointBaseAsync
  .WithRequest<AddRegionRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddRegionEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddRegionRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Region",
    Description = "Admin Add Region",
    OperationId = "Admin.AddRegion",
    Tags = new[] {"Region Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(AddRegionRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddRegionEvent(request.Name, request.NameAr),cancellationToken);
}
