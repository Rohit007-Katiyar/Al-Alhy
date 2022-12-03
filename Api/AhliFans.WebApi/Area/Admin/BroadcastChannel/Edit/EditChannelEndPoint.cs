using AhliFans.Core.Feature.Admin.BroadcastChannel.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.BroadcastChannel.Edit;

public class EditChannelEndPoint : EndpointBaseAsync
  .WithRequest<EditChannelRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditChannelEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditChannelRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Broadcast Channel",
    Description = "Admin Edit Broadcast Channel",
    OperationId = "Admin.EditBroadcastChannel",
    Tags = new[] {"Broadcast Channel Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(EditChannelRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditChannelEvent(request.ChannelId, request.Name, request.NameAr), cancellationToken);
}
