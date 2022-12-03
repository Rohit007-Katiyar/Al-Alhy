using AhliFans.Core.Feature.Admin.Moment.GetById.DTO;
using AhliFans.Core.Feature.Admin.Moment.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Moment.GetById;

public class GetMomentByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetMomentByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetMomentByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetMomentByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MomentDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Moment By Id",
    Description = "Admin Get Moment By Id",
    OperationId = "Admin.GetMoment",
    Tags = new[] { "Moment Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetMomentByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetMomentByIdEvent(request.MomentId, request.Lang), cancellationToken);
}
