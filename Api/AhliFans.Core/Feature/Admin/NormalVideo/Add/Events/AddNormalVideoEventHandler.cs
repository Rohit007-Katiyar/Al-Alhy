using System.Net;
using AhliFans.Core.GenerateThumbnail;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.NormalVideo.Add.Events;
public class AddNormalVideoEventHandler : IRequestHandler<AddNormalVideoEvent, ActionResult>
{
  private readonly IRepository<Entities.NormalVideo> _normalVideoRepository;
  private readonly IMapper _mapper;

  public AddNormalVideoEventHandler(IRepository<Entities.NormalVideo> normalVideoRepository, IMapper mapper)
  {
    _normalVideoRepository = normalVideoRepository;
    _mapper = mapper;
  }

  public async Task<ActionResult> Handle(AddNormalVideoEvent request, CancellationToken cancellationToken)
  {
    var video = _mapper.Map<Entities.NormalVideo>(request);
    var videoEntity = await _normalVideoRepository.AddAsync(video, cancellationToken);
    await _normalVideoRepository.SaveChangesAsync(cancellationToken);
    var fileName = "normalvideo_" + videoEntity.Id;
    
    ImageUtility.SaveThumbnail(request.VideoURL, fileName, "NormalVideo");

    return new OkObjectResult(new AdminResponse("New video has been added successfully", ResponseStatus.Success));
  }
}
