using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.APIServices.FaceBook.IRepository;
using AhliFans.SharedKernel.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.LinkSocialMedia.Fan.FaceBook;

public class LinkFaceBookAccountEventHandler : IRequestHandler<LinkFaceBookAccountEvent,ActionResult>
{
  private readonly IFaceBookAuthService _faceBookAuthService;
  private readonly UserManager<Entities.Fan> _userManager;
  private readonly string _userId;
  public LinkFaceBookAccountEventHandler(IHttpContextAccessor context,IFaceBookAuthService faceBookAuthService, UserManager<Entities.Fan> userManager)
  {
    _faceBookAuthService = faceBookAuthService;
    _userManager = userManager;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(LinkFaceBookAccountEvent request, CancellationToken cancellationToken)
  {
    var validationTokenResult = await _faceBookAuthService.ValidationAccessToken(request.Token);

    if (!validationTokenResult.ValidationData.Isvalid)
      return new BadRequestObjectResult(new FanResponse("Token isn't valid", ResponseStatus.Error));

    var faceBookUserInfo = await _faceBookAuthService.GetUserInfo(request.Token);
    var fan = await _userManager.FindByIdAsync(_userId);
    if (fan is null)
      return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));
    
    fan.Email = faceBookUserInfo.Email;
    fan.LinkedWith = SocialMediaLink.Facebook;
    await _userManager.UpdateAsync(fan);
    return new OkObjectResult(new FanResponse("Operation done successfully", ResponseStatus.Success));
  }
}
