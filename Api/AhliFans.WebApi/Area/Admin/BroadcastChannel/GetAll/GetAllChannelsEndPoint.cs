using AhliFans.Core.Feature.Admin.BroadcastChannel.GetAll.DTO;
using AhliFans.Core.Feature.Admin.BroadcastChannel.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.BroadcastChannel.GetAll;

public class GetAllChannelsEndPoint : EndpointBaseAsync
  .WithRequest<GetAllChannelsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllChannelsEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetAllChannelsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChannelsDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Broadcast Channel",
    Description = "Admin Get All Broadcast Channel",
    OperationId = "Admin.GetAllBroadcastChannel",
    Tags = new[] {"Broadcast Channel Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllChannelsRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllChannelsEvent(request.Lang, request.PageIndex, request.PageSize),cancellationToken);
}
