using AhliFans.Core.Feature.Fan.AppLanguage.Get.Dto;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.AppLanguage.Get.Events;
public class GetLanguageEventHandler : IRequestHandler<GetLanguageEvent,ActionResult>
{
  private readonly string _userId;
  private readonly UserManager<Security.Entities.Fan> _userManager;
  public GetLanguageEventHandler(IHttpContextAccessor context, UserManager<Security.Entities.Fan> userManager)
  {
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value; 
    _userManager = userManager;
  }
  public async Task<ActionResult> Handle(GetLanguageEvent request, CancellationToken cancellationToken)
  {
    var fan = await _userManager.FindByIdAsync(_userId);
    if (fan == null) return new BadRequestObjectResult(new FanResponse("Not Found", ResponseStatus.Error));
    return new OkObjectResult(new FanLanguageDto(fan.Language.ToString()!));
  }
}
