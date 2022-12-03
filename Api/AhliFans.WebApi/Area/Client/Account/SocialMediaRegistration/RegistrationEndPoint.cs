using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.Login.Fan.DTO;
using AhliFans.Core.Feature.Security.SocialMediaRegistration.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.SocialMediaRegistration;

public class RegistrationEndPoint : EndpointBaseAsync
  .WithRequest<RegistrationRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public RegistrationEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(RegistrationRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanTokenDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Sign Up with social media account",
    Description = "Client Sign Up with social media account in Al-Ahly",
    OperationId = "Client.SocialMediaSignUp",
    Tags = new[] { "Client Account Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromBody] RegistrationRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(new SocialMediaRegistrationEvent(request.FullName,request.Email,
      request.PhoneNumber, request.BirthDate, request.Country, request.City, request.Gender),cancellationToken);
}
