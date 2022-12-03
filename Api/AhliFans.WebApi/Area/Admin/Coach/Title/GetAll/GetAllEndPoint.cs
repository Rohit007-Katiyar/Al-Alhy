using AhliFans.Core.Feature.Admin.Coach.Title.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Coach.Title.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.Title;

public class GetAllEndPoint : EndpointBaseAsync
  .WithRequest<GetAllRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetAllRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<TitlesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Coach Title",
    Description = "Admin Get Coach Title",
    OperationId = "Admin.GetTitle",
    Tags = new[] { "Coach Titles Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllTitlesEvent(request.SearchWord,request.Lang,request.PageIndex,request.PageSize,request.IsDeleted),
      cancellationToken);
}
