using AhliFans.Core.Feature.Admin.Moment;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Moment;

public class GetVideoEndPoint : EndpointBaseAsync
  .WithRequest<GetVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IFormFile))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Moment Video By Id",
    Description = "Admin Get Moment Video By Id",
    OperationId = "Admin.GetMoment",
    Tags = new[] { "Moment Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetVideoRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetMomentVideoEvent(request.MomentId), cancellationToken);
}
