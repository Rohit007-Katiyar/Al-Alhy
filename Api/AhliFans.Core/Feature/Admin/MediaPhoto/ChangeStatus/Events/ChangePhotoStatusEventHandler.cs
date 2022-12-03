using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.Coach.ChangeStatus.Events;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AhliFans.Core.Feature.Admin.MediaPhoto.ChangeStatus.Events;
using AhliFans.Core.Feature.Entities;

namespace AhliFans.Core.Feature.Admin.Category.ChangeStatus.Events;
public class ChangePhotoStatusEventHandler : IRequestHandler<ChangePhotoStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.MediaPhoto> _photoRepository;

  public ChangePhotoStatusEventHandler(IRepository<Entities.MediaPhoto> photoRepository)
  {
    _photoRepository = photoRepository;
  }
  public async Task<ActionResult> Handle(ChangePhotoStatusEvent request, CancellationToken cancellationToken)
  {
    var photo = await _photoRepository.GetByIdAsync(request.photoId, cancellationToken);
    if (photo is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    photo.IsDeleted = !photo.IsDeleted;
    photo.ModifiedById = Guid.Parse(request.AdminId);
    photo.ModifiedOn = DateTime.Now;
    await _photoRepository.UpdateAsync(photo, cancellationToken);
    await _photoRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(photo.IsDeleted ? "Delete Photo Done You Can Retrieve It Any Time" : "Retrieve Photo Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
