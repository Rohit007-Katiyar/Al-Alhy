using AhliFans.Core.Feature.Admin.Stadium.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Stadium;

public class EditStadiumEndPoint : EndpointBaseAsync
  .WithRequest<EditStadiumRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditStadiumEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditStadiumRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Stadium",
    Description = "Admin Edit Stadium",
    OperationId = "Admin.EditStadium",
    Tags = new[] {"Stadium Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]EditStadiumRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditStadiumEvent(request.StadiumId,request.RegionId,request.Name,request.NameAr,request.Location), cancellationToken);
}
