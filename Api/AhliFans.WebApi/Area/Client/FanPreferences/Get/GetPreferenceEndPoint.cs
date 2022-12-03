using AhliFans.Core.Feature.Fan.Preferences.Get.DTO;
using AhliFans.Core.Feature.Fan.Preferences.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.FanPreferences;

public class GetPreferenceEndPoint:EndpointBaseAsync
  .WithRequest<GetPreferenceRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetPreferenceEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetPreferenceRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PreferenceDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Preferences",
    Description = "Client Get Preferences",
    OperationId = "Client.GetPreferences",
    Tags = new[] {"Fan Preferences Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetPreferenceRequest request, CancellationToken cancellationToken = default)
    => await _mediator.Send(new GetPreferenceEvent(request.Lang), cancellationToken);
}
