using AhliFans.Core.Feature.Admin.Jersey.GetById.DTO;
using AhliFans.Core.Feature.Admin.Jersey.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Jersey;

public class GetJerseyByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetJerseyByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetJerseyByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetJerseyByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JerseyDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Jersey By Id",
    Description = "Admin Get Jersey By Id",
    OperationId = "Admin.GetJersey",
    Tags = new[] { "Jersey Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetJerseyByIdRequest request,
    CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new GetJerseyByIdEvent(request.JerseyId),
      cancellationToken);
  }
}
