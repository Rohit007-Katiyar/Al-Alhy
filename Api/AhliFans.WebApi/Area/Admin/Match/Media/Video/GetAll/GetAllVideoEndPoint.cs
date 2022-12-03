using AhliFans.Core.Feature.Admin.Match;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match;

public class GetAllVideoEndPoint : EndpointBaseAsync
  .WithRequest<GetAllVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [AllowAnonymous]
  [HttpGet(GetAllVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MediaVideoDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Match Media Videos",
    Description = "Admin Get Match Media Videos",
    OperationId = "Admin.GetMediaVideos",
    Tags = new[] { "Match Media Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllVideoRequest request, CancellationToken cancellationToken = default)
    => await _mediator.Send(new GetAllMatchVideoEvent(request.MatchId),cancellationToken);
  
}
