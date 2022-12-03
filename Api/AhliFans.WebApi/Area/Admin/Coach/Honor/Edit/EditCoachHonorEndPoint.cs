using AhliFans.Core.Feature.Admin.Coach.Honor.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.Honor.Edit;

public class EditCoachHonorEndPoint : EndpointBaseAsync
  .WithRequest<EditHonorRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditCoachHonorEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(EditHonorRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Coach Honor",
    Description = "Admin Edit Coach Honor",
    OperationId = "Admin.EditCoachHonor",
    Tags = new[] { "Coach Honor Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] EditHonorRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditCoachHonorEvent(request.HonorId, request.CoachId, request.TrophyId, request.IsPersonal), cancellationToken);
}
