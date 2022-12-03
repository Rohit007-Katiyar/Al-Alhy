using AhliFans.Core.Feature.Admin.Match.Media.Images.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match.Media.Images;

public class GetImageByIdEndPoint: EndpointBaseAsync
  .WithRequest<GetImageByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetImageByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetImageByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IFormFile))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Match Media Image By Id",
    Description = "Admin Get Match Media Image By Id",
    OperationId = "Admin.GetMediaImage",
    Tags = new[] {"Match Media Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute]GetImageByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetMatchImageEvent(request.ImageId), cancellationToken);
}
