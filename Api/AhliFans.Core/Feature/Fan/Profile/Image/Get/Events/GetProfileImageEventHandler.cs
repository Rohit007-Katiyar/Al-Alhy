using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Fan.Profile.Image.Get.Events;
public class GetProfileImageEventHandler : IRequestHandler<GetProfileImageEvent,ActionResult>
{
  private readonly ILogger<GetProfileImageEventHandler> _logger;
  private readonly string _userId;
  private readonly UserManager<Security.Entities.Fan> _userManager;
  private readonly IFileManager _fileManager;
  public GetProfileImageEventHandler(ILogger<GetProfileImageEventHandler> logger, IHttpContextAccessor context, UserManager<Security.Entities.Fan> userManager, IFileManager fileManager)
  {
    _logger = logger;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value; 
    _userManager = userManager;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(GetProfileImageEvent request, CancellationToken cancellationToken)
  {
    var fan = await _userManager.FindByIdAsync(_userId);
    if (fan == null) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    var profileImage = string.IsNullOrEmpty(fan.ProfilePic) ?
       await _fileManager.FileProxy<Security.Entities.Fan>("user.png", "") :
       await _fileManager.FileProxy<Security.Entities.Fan>(fan.ProfilePic, _userId);

    _logger.LogInformation($"User {fan.Id} get his profile pic");
    try
    {
      var streamReader = await profileImage.ReadStreamAsync();
      return new FileStreamResult(streamReader, _fileManager.GetContentType(string.IsNullOrEmpty(fan.ProfilePic) ? "user.png" : fan.ProfilePic));
    }
    catch 
    {
      return new BadRequestObjectResult(new AdminResponse("Can't get the image", ResponseStatus.Error));
    }
  }
}
