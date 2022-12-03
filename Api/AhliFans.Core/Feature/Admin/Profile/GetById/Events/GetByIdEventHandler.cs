using AhliFans.Core.Feature.Admin.Profile.GetById.DTO;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Admin.Profile.GetById.Events;
internal class GetByIdEventHandler : IRequestHandler<GetByIdEvent,ActionResult>
{
  private readonly ILogger<GetByIdEventHandler> _logger;
  private readonly string _userId;
  private readonly UserManager<Security.Entities.Admin> _userManager;

  public GetByIdEventHandler(ILogger<GetByIdEventHandler> logger, IHttpContextAccessor context, UserManager<Security.Entities.Admin> userManager)
  {
    _logger = logger;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value; 
    _userManager = userManager;
  }
  public async Task<ActionResult> Handle(GetByIdEvent request, CancellationToken cancellationToken)
  {
    var admin = await _userManager.FindByIdAsync(_userId);
    if (admin == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    _logger.LogInformation($"User{admin.Id} get his profile information");
    return new OkObjectResult(new AdminDetailsDto(admin.FullName, admin.Email, admin.PhoneNumber,
       admin.CreatedOn.ToString("dd-MM-yyyy")));
  }
}
