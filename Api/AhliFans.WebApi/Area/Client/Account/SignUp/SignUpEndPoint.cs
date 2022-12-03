using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.Registration.Fan.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.SignUp;

public class SignUpEndPoint : EndpointBaseAsync
  .WithRequest<SignUpRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public SignUpEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpPost(SignUpRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Sign Up",
    Description = "Client Sign Up in Al-Ahly",
    OperationId = "Client.SignUp",
    Tags = new[] {"Client Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromBody] SignUpRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(new RegistrationEvent(request.FullName, request.Email, request.Password, request.ConfirmPassword,
      request.PhoneNumber, request.Gender, request.BirthDate,request.Country,request.City), cancellationToken);
}
