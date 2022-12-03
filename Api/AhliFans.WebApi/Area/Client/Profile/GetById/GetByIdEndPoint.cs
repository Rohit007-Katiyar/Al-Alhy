using AhliFans.Core.Feature.Fan.Profile.GetById.DTO;
using AhliFans.Core.Feature.Fan.Profile.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Profile;

public class GetByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetByIdRequest>
  .WithActionResult
{

  private readonly IMediator _mediator;

  public GetByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanInfoDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Fan View his Profile Data",
    Description = "Fan View his Profile Data in Al-Ahly",
    OperationId = "Client.ViewProfile",
    Tags = new[] { "Fan Profile Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetByIdRequest request, CancellationToken cancellationToken = default)
    => await _mediator.Send(new GetByIdEvent(request.Lang), cancellationToken);
}
