using AhliFans.Core.Feature.Admin.Region.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Region;

public class EditRegionEndPoint : EndpointBaseAsync
  .WithRequest<EditRegionRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditRegionEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(EditRegionRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Region",
    Description = "Admin Edit Region",
    OperationId = "Admin.EditRegion",
    Tags = new[] { "Region Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(EditRegionRequest request,
    CancellationToken cancellationToken = default) =>
  await _mediator.Send(new EditRegionEvent(request.Id,request.Name,request.NameAr), cancellationToken);
}
