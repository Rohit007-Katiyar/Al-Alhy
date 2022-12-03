using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.Login.Fan.DTO;
using AhliFans.Core.Feature.Security.Login.Fan.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.Login;

public class LoginEndPoint : EndpointBaseAsync
  .WithRequest<LoginRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public LoginEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpPost(LoginRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanTokenDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client get token",
    Description = "Client get token from on Al-Ahly ",
    OperationId = "Client.Individual.Login",
    Tags = new[] {"Client Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(LoginRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new LoginEvent(request.EmailOrPhoneNumber, request.Password), cancellationToken);
}
