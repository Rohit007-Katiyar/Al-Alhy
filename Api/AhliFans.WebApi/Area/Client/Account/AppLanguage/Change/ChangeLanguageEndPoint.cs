using AhliFans.Core.Feature.Fan.AppLanguage.Change.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.AppLanguage.Change;

public class ChangeLanguageEndPoint : EndpointBaseAsync
  .WithRequest<ChangeLanguageRequest>
  .WithActionResult
{

  private readonly IMediator _mediator;

  public ChangeLanguageEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeLanguageRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Change Language",
    Description = "Client change his Language",
    OperationId = "Client.ChangeLanguage",
    Tags = new[] {"Client Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] ChangeLanguageRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(new ChangeLanguageEvent(request.Language), cancellationToken);
}
