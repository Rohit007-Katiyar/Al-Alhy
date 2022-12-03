using AhliFans.Core.Feature.Admin.Match.Media.Images.Add.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.Media.Images.Add.Events;

public class AddMatchMediaEventHandler : IRequestHandler<AddMatchMediaImageEvent,ActionResult>
{
  private readonly IRepository<MatchMedia> _mediaRepository;
  private readonly IRepository<Entities.Match> _matchRepository;
  private readonly IFileManager _fileManager;

  public AddMatchMediaEventHandler(IRepository<MatchMedia> mediaRepository,IFileManager fileManager, IRepository<Entities.Match> matchRepository)
  {
    _mediaRepository = mediaRepository;
    _fileManager = fileManager;
    _matchRepository = matchRepository;
  }
  public async Task<ActionResult> Handle(AddMatchMediaImageEvent request, CancellationToken cancellationToken)
  {
    if (!await _matchRepository.AnyAsync(new IsMatchExist(request.MatchId), cancellationToken))
      return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
        
    foreach (var file in request.Images)
    {
      var image = new MatchMedia() {MatchId = request.MatchId, FileName = file.FileName, IsDeleted = false,MediaType = MediaType.Photo};
      await _mediaRepository.AddAsync(image,cancellationToken);
      await _mediaRepository.SaveChangesAsync(cancellationToken);
      bool done = await SaveMediaImage(file, image.Id);
      if (!done)
      {
        return new BadRequestObjectResult(new AdminResponse("Error while uploading", ResponseStatus.Error));
      }
    }
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
  private async Task<bool> SaveMediaImage(IFormFile? request, int mediaId)
  {
    if (request is null)
    {
      return true;
    }
    bool saveProfile = await _fileManager.SaveFileAsync<MatchMedia>(request,
      request.FileName, mediaId.ToString());
    return saveProfile;
  }
}
