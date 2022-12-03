using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetImage.Events;
public class GetFanImageEventHandler : IRequestHandler<GetFanImageEvent, ActionResult>
{
  private readonly IRepository<Security.Entities.Fan> _fanRepository;
  private readonly IFileManager _fileManager;
  public GetFanImageEventHandler(IRepository<Security.Entities.Fan> fanRepository, IFileManager fileManager)
  {
    _fanRepository = fanRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(GetFanImageEvent request, CancellationToken cancellationToken)
  {
    var fan = await _fanRepository.GetByIdAsync(request.FanId, cancellationToken);
    if (fan is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    var profileImage = string.IsNullOrEmpty(fan.ProfilePic) ?
      await _fileManager.FileProxy<Security.Entities.Fan>("user.png", "") :
      await _fileManager.FileProxy<Security.Entities.Fan>(fan.ProfilePic, fan.Id.ToString());
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
