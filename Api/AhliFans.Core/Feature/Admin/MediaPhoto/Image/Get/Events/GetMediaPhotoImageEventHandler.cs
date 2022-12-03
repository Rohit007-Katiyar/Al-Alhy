using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.Image.Get.Events;
public class GetMediaPhotoImageEventHandler : IRequestHandler<GetMediaPhotoImageEvent, ActionResult>
{
  private readonly IRepository<Entities.MediaPhoto> _photoRepository;
  private readonly IFileManager _fileManager;
  public GetMediaPhotoImageEventHandler(IRepository<Entities.MediaPhoto> photoRepository, IFileManager fileManager)
  {
    _photoRepository = photoRepository;
    _fileManager = fileManager;
  }

  public async Task<ActionResult> Handle(GetMediaPhotoImageEvent request, CancellationToken cancellationToken)
  {
    var photo = await _photoRepository.GetByIdAsync(request.PhotoId, cancellationToken);
    if (photo is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    var photoImage = string.IsNullOrEmpty(photo.Photo) ?
      await _fileManager.FileProxy<Entities.MediaPhoto>("coach.png", "") :
      await _fileManager.FileProxy<Entities.MediaPhoto>(photo.Photo, photo.Id.ToString());

    try
    {
      var streamReader = await photoImage.ReadStreamAsync();
      return new FileStreamResult(streamReader, _fileManager.GetContentType(string.IsNullOrEmpty(photo.Photo) ? "coach.png" : photo.Photo));
    }
    catch
    {
      return new BadRequestObjectResult(new AdminResponse("Can't get the image", ResponseStatus.Error));
    }
  }
}
