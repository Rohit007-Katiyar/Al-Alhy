using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Fan.Profile.Image.Update.Events;
public class UpdateImageEventHandler : IRequestHandler<UpdateImageEvent,ActionResult>
{
  private readonly UpdateImageValidator _imageValidator;
  private readonly ILogger<UpdateImageEventHandler> _logger;
  private readonly string _userId;
  private readonly UserManager<Security.Entities.Fan> _userManager;
  private readonly IFileManager _fileManager;

  public UpdateImageEventHandler(UpdateImageValidator imageValidator,ILogger<UpdateImageEventHandler> logger, IHttpContextAccessor context, UserManager<Security.Entities.Fan> userManager, IFileManager fileManager)
  {
    _imageValidator = imageValidator;
    _logger = logger;
    _userManager = userManager;
    _fileManager = fileManager;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(UpdateImageEvent request, CancellationToken cancellationToken)
  {
    var validation = await _imageValidator.ValidateAsync(request, cancellationToken);

    if (!validation.IsValid)
    {
      _logger.LogError(request.ToString());
      return new BadRequestObjectResult(new FanResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));
    }

    var fan = await _userManager.FindByIdAsync(_userId);
    if (fan == null) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    var saveProfile = await _fileManager.UpdateFileAsync<Security.Entities.Fan>(request.ProfileImage, fan.ProfilePic!,
      request.ProfileImage.FileName, _userId);
    if (!saveProfile) return new BadRequestObjectResult(new FanResponse("Error while uploading", ResponseStatus.Error));
    
    fan.ProfilePic = request.ProfileImage.FileName;
    await _userManager.UpdateAsync(fan);
    
    return new OkObjectResult(new FanResponse("Operation done successfully.", ResponseStatus.Error));
  }
}
