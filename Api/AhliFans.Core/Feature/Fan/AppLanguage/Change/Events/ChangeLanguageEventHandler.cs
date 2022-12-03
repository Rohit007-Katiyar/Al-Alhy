using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Fan.AppLanguage.Change.Events;
public class ChangeLanguageEventHandler : IRequestHandler<ChangeLanguageEvent,ActionResult>
{
  private readonly ILogger<ChangeLanguageEventHandler> _logger;
  private readonly string _userId;
  private readonly UserManager<Security.Entities.Fan> _userManager;
  public ChangeLanguageEventHandler(ILogger<ChangeLanguageEventHandler> logger, IHttpContextAccessor context, UserManager<Security.Entities.Fan> userManager)
  {
    _logger = logger;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
    _userManager = userManager;
  }
  public async Task<ActionResult> Handle(ChangeLanguageEvent request, CancellationToken cancellationToken)
  {
    var fan = await _userManager.FindByIdAsync(_userId);
    if (fan == null) return new BadRequestObjectResult(new FanResponse("Not found",ResponseStatus.Error));

    fan.Language = request.Language;
    await _userManager.UpdateAsync(fan);

    _logger.LogInformation($"User{_userId} changed his app language to {request.Language}");
    return new OkObjectResult(new FanResponse("Operation done successfully",ResponseStatus.Error));
  }
}
