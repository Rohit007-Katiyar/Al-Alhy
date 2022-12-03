using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment.Add.Events;

public class AddMomentEventHandler : IRequestHandler<AddMomentEvent,ActionResult>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Entities.Moment> _momentRepository;
  private readonly IFileManager _fileManager;

  public AddMomentEventHandler(IMapper mapper,IRepository<Entities.Moment> momentRepository, IFileManager fileManager)
  {
    _mapper = mapper;
    _momentRepository = momentRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(AddMomentEvent request, CancellationToken cancellationToken)
  {
    var moment = _mapper.Map<Entities.Moment>(request);
    await _momentRepository.AddAsync(moment, cancellationToken);
    await _momentRepository.SaveChangesAsync(cancellationToken);

    bool saveVideo = await SaveVideo(request.MomentVideo, moment.Id);
    if (!saveVideo) return new OkObjectResult(new AdminResponse("New moment has been added successfully,but saving video failure .", ResponseStatus.Warning));

    return new OkObjectResult(new AdminResponse("Operation done successfully",ResponseStatus.Success));
  }
  private async Task<bool> SaveVideo(IFormFile? request, int momentId)
  {
    if (request is null)
    {
      return true;
    }
    bool saveProfile = await _fileManager.SaveFileAsync<Entities.Moment>(request,
      request.FileName, momentId.ToString());
    return saveProfile;
  }
}
