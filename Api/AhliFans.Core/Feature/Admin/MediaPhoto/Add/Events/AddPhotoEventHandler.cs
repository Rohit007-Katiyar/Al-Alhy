using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.Add.Events;
public class AddPhotoEventHandler : IRequestHandler<AddPhotoEvent, ActionResult>
{
  private readonly IRepository<Entities.MediaPhoto> _photoRepository;
  private readonly IFileManager _fileManager;
  private readonly IMapper _mapper;

  public AddPhotoEventHandler(IRepository<Entities.MediaPhoto> photoRepository, IFileManager fileManager, IMapper mapper)
  {
    _photoRepository = photoRepository;
    _fileManager = fileManager;
    _mapper = mapper;
  }

  public async Task<ActionResult> Handle(AddPhotoEvent request, CancellationToken cancellationToken)
  {
    var photo = _mapper.Map<Entities.MediaPhoto>(request);
    
    await _photoRepository.AddAsync(photo, cancellationToken);
    await _photoRepository.SaveChangesAsync(cancellationToken);

    bool saveProfile = await SavePic(request.Photo, photo.Id);
    if (!saveProfile) return new OkObjectResult(new AdminResponse("New photo has been added successfully,but saving Pic failure .", ResponseStatus.Warning));

    return new OkObjectResult(new AdminResponse("New photo has been added successfully", ResponseStatus.Success));
  }
  private async Task<bool> SavePic(IFormFile? request, int photoId)
  {
    if (request is null)
    {
      return true;
    }
    bool saveProfile = await _fileManager.SaveFileAsync<Entities.MediaPhoto>(request,
      request.FileName, photoId.ToString());
    return saveProfile;
  }

}
