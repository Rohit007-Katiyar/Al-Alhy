using AhliFans.Core.Feature.Fan.Profile.Modify.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Profile;

public class ModifyEndPoint : EndpointBaseAsync
  .WithRequest<ModifyRequest>
  .WithActionResult
{

  private readonly IMediator _mediator;

  public ModifyEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(ModifyRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Fan Modify his Profile Data",
    Description = "Fan Modify hi Profile Data in Al-Ahly",
    OperationId = "Client.ModifyProfile",
    Tags = new[] { "Fan Profile Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromBody] ModifyRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(
      new ModifyEvent(request.FullName, request.EmailAddress, request.MobileNumber,
        request.DateOfBirth, request.Gender, request.CityId), cancellationToken);
}
