using AhliFans.Core.Feature.Admin.Match;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match;

public class AddVideoEndPoint : EndpointBaseAsync
  .WithRequest<AddVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Match Highlights Videos",
    Description = "Admin Add Match Highlights Videos",
    OperationId = "Admin.AddMatchVideos",
    Tags = new[] { "Match Media Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddVideoRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddMatchMediaVideoEvent(request.Videos, request.MatchId), cancellationToken);
}
