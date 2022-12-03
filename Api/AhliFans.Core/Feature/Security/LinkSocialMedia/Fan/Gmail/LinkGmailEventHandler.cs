using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.LinkSocialMedia.Fan.Gmail;

public class LinkGmailEventHandler : IRequestHandler<LinkGmailEvent,ActionResult>
{
  private readonly UserManager<Entities.Fan> _userManager;
  private readonly string _userId;
  public LinkGmailEventHandler(IHttpContextAccessor context, UserManager<Entities.Fan> userManager)
  {
    _userManager = userManager;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(LinkGmailEvent request, CancellationToken cancellationToken)
  {
    var fan = await _userManager.FindByIdAsync(_userId);
    if (fan == null) return new NotFoundObjectResult(new FanResponse("Not found",ResponseStatus.Error));

    fan.Email = request.Email;
    fan.LinkedWith = SocialMediaLink.Gmail;
    await _userManager.UpdateAsync(fan);
    return new OkObjectResult(new FanResponse("Operation done successfully", ResponseStatus.Success));
  }
}
