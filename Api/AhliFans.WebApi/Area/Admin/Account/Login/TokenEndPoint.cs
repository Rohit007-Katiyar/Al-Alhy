using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.Login.Admin.DTO;
using AhliFans.Core.Feature.Security.Login.Admin.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Account;

public class TokenEndPoint : EndpointBaseAsync
  .WithRequest<TokenRequest>
  .WithActionResult
{
  readonly IMediator _mediator;
  public TokenEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpPost(TokenRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin get token",
    Description = "Admin get token from on Al-Ahly Admin",
    OperationId = "Admin.Token",
    Tags = new[] {"Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(TokenRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(new LoginEvent(request.EmailOrPhoneNumber, request.Password),
      cancellationToken);
}
