using AhliFans.Core.Feature.Admin.Referee.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Referee;

public class EditRefereeEndPoint : EndpointBaseAsync
  .WithRequest<EditRefereeRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditRefereeEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditRefereeRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Referee",
    Description = "Admin Edit Referee",
    OperationId = "Admin.EditReferee",
    Tags = new[] {"Referee Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]EditRefereeRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditRefereeEvent(request.RefereeId, request.NationalityId, request.RegionId, request.Name,
      request.NameAr),cancellationToken);
}
