using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.MediaPhoto.Add.Events;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AhliFans.SharedKernel;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AhliFans.Core.GenerateThumbnail;

namespace AhliFans.Core.Feature.Admin.MomentVideo.Add.Events;
public class AddMomentVideoEventHandler : IRequestHandler<AddMomentVideoEvent, ActionResult>
{
  private readonly IRepository<Entities.MomentVideo> _MomentVideoRepository;
  private readonly IMapper _mapper;

  public AddMomentVideoEventHandler(IRepository<Entities.MomentVideo> MomentVideoRepository, IMapper mapper)
  {
    _MomentVideoRepository = MomentVideoRepository;
    _mapper = mapper;
  }

  public async Task<ActionResult> Handle(AddMomentVideoEvent request, CancellationToken cancellationToken)
  {
    var video = _mapper.Map<Entities.MomentVideo>(request);

    var momentEntity = await _MomentVideoRepository.AddAsync(video, cancellationToken);
    await _MomentVideoRepository.SaveChangesAsync(cancellationToken);

    var fileName = "MomentVideo_" + momentEntity.Id;
    ImageUtility.SaveThumbnail(request.VideoURL, fileName, "MomentVideo");

    return new OkObjectResult(new AdminResponse("New video has been added successfully", ResponseStatus.Success));
  }
}
