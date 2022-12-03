using AhliFans.Core.Feature.Admin.Profile.GetById.DTO;
using AhliFans.Core.Feature.Admin.Profile.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Profile;

public class GetByIdEndPoint :EndpointBaseAsync
  .WithoutRequest
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminDetailsDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get his Profile Data",
    Description = "Admin Get his Profile Data in Al-Ahly",
    OperationId = "Admin.GetProfile",
    Tags = new[] { "Account Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetByIdEvent(), cancellationToken);

}
