using AhliFans.Core.Feature.Admin.Match.Media.Images.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Match.Media.Images.GetAll.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.Media.Images.GetAll.Events;

public class GetAllEventHandler :IRequestHandler<GetAllMatchImagesEvent, ActionResult>
{
  private readonly IRepository<MatchMedia> _mediaRepository;

  public GetAllEventHandler(IRepository<MatchMedia> mediaRepository)
  {
    _mediaRepository = mediaRepository;
  }
  public async Task<ActionResult> Handle(GetAllMatchImagesEvent request, CancellationToken cancellationToken)
  {
    var images = await _mediaRepository.ListAsync(new GetMediaByMatch(request.MatchId), cancellationToken);
    if (images.Count == 0) return new BadRequestObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));
    return new OkObjectResult(images.Select(m=>new MediaVideoDto(m.Id,m.MatchId,request.ImageUrl+m.Id)));
  }
}
