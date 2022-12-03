using System.Web;
using AhliFans.Core.Feature.Admin.Coach.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Coach.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach;

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
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<CoachesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Coach",
    Description = "Admin Get All Coach",
    OperationId = "Admin.AllCoaches",
    Tags = new[] { "Coach Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllRequest request,
    CancellationToken cancellationToken = default)
  {
    var decodedWord = HttpUtility.UrlDecode(request.SearchWord);
    return await _mediator.Send(new GetAllCoachesEvent(decodedWord, request.Lang, request.PageIndex, request.PageSize,request.IsDeleted),
      cancellationToken);
  }
    
}
