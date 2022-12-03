using System.Text;
using AhliFans.Core.Feature.Admin.Jersey.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Jersey.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using AhliFans.WebApi.Area.Admin.Jersey.Image;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Jersey;

public class GetAllJerseysEndPoint : EndpointBaseAsync
  .WithRequest<GetAllJerseysRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllJerseysEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetAllJerseysRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<JerseysDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Jerseys",
    Description = "Admin Get All Jerseys",
    OperationId = "Admin.AllJerseys",
    Tags = new[] { "Jersey Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllJerseysRequest request,
    CancellationToken cancellationToken = default)
  {
    var imageBaseUrl = new StringBuilder(Request.Scheme).Append("://")
	  .Append(Request.Host)
	  .Append(Request.PathBase.ToString()).Append("/")
	  .Append(GetImageRequest.Route.Replace("{JerseyId}",""))
	  .ToString();
		

	return await _mediator.Send(new GetAllJerseysEvent(request.PageIndex, request.PageSize, request.IsEnabled, request.IsHome, imageBaseUrl),
        cancellationToken);
  }
}
