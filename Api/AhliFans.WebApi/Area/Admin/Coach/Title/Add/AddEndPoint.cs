using AhliFans.Core.Feature.Admin.Coach.Title.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.Title;

public class AddEndPoint : EndpointBaseAsync
  .WithRequest<AddRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPost(AddRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Coach Title",
    Description = "Admin Add Coach Title",
    OperationId = "Admin.AddTitle",
    Tags = new[] { "Coach Titles Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddTitleEvent(request.Text,request.TextAr),cancellationToken);
}
