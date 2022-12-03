using AhliFans.Core.Feature.Admin.Trophy.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Trophy;

public class EditEndPoint :EndpointBaseAsync
  .WithRequest<EditRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(EditRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Trophy",
    Description = "Admin Edit Trophy",
    OperationId = "Admin.EditTrophy",
    Tags = new[] { "Trophy Endpoints" })
  ] 
  public override async Task<ActionResult> HandleAsync([FromForm]EditRequest request,
    CancellationToken cancellationToken = default) => 
    await _mediator.Send(new EditTrophyEvent(request.TrophyId, request.TrophyTypeId, request.Name, request.NameAr,request.HistoryYears),
      cancellationToken);
}
