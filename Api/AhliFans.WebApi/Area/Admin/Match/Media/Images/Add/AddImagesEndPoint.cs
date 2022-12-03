using AhliFans.Core.Feature.Admin.Match.Media.Images.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match.Media.Images;

public class AddImagesEndPoint : EndpointBaseAsync
  .WithRequest<AddImagesRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddImagesEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddImagesRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Match Highlights Images",
    Description = "Admin Add Match Highlights Images",
    OperationId = "Admin.AddMatchImages",
    Tags = new[] { "Match Media Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddImagesRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddMatchMediaImageEvent(request.Images,request.MatchId), cancellationToken);
}
