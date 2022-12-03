using AhliFans.Core.Feature.Admin.Preferences.Get.DTO;
using AhliFans.Core.Feature.Admin.Preferences.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Preferences;

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
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PreferenceDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Preferences",
    Description = "Admin Get Preferences",
    OperationId = "Admin.GetPreferences",
    Tags = new[] {"Fan Preferences Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetPreferenceRequest request, CancellationToken cancellationToken = default)
    => await _mediator.Send(new GetPreferenceEvent(request.FanId,request.Lang), cancellationToken);
}
