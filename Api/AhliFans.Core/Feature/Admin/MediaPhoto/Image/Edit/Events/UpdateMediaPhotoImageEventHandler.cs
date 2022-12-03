using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.Image.Edit.Events;
public class UpdateMediaPhotoImageEventHandler : IRequestHandler<UpdateMediaPhotoImageEvent, ActionResult>
{
  private readonly IFileManager _fileManager;
  private readonly IRepository<Entities.MediaPhoto> _photoRepository;
  public UpdateMediaPhotoImageEventHandler(IFileManager fileManager, IRepository<Entities.MediaPhoto> photoRepository)
  {
    _fileManager = fileManager;
    _photoRepository = photoRepository;
  }
  public async Task<ActionResult> Handle(UpdateMediaPhotoImageEvent request, CancellationToken cancellationToken)
  {
    var photo = await _photoRepository.GetByIdAsync(request.PhotoId, cancellationToken);
    if (photo is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    bool image = await UpdateImageAsync(request, photo);
    if (!image)
    {
      return new OkObjectResult(new AdminResponse("Failed to upload image to server", ResponseStatus.Warning));
    }
    photo.Photo = request.PhotoImage.FileName;
    await _photoRepository.UpdateAsync(photo, cancellationToken);
    await _photoRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private Task<bool> UpdateImageAsync(UpdateMediaPhotoImageEvent request, Entities.MediaPhoto photo)
  {
    return _fileManager.UpdateFileAsync<Entities.Coach>(request.PhotoImage, photo.Photo!, request.PhotoImage.FileName,
      photo.Id.ToString());
  }
}
