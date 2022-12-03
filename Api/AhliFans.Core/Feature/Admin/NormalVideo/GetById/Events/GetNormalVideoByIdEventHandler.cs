using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetById.Events;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetById.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AhliFans.Core.Feature.Admin.NormalVideo.GetById.Specification;
using AhliFans.Core.Feature.Admin.NormalVideo.GetById.DTO;

namespace AhliFans.Core.Feature.Admin.NormalVideo.GetById.Events;
public class GetNormalVideoByIdEventHandler : IRequestHandler<GetNormalVideoByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.NormalVideo> _normalVideoRepository;
  public GetNormalVideoByIdEventHandler(IRepository<Entities.NormalVideo> normalVideoRepository)
  {
    _normalVideoRepository = normalVideoRepository;
  }

  public async Task<ActionResult> Handle(GetNormalVideoByIdEvent request, CancellationToken cancellationToken)
  {
    var video = await _normalVideoRepository.GetBySpecAsync(new GetNormalVideoById(request.NormalVideoId), cancellationToken);
    if (video is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new NormalVideoDto(video.Id, video.Season.Id,
      video.Season.StartDate.Year + "-" + video.Season?.EndDate?.Year,
      video.Month,
      string.IsNullOrEmpty(video.VideoURL) ? String.Empty : video.VideoURL,
      video.Match.Id,
      video.League.Id,
      request.Lang == Languages.En ? video.League.Name : video.League.NameAr,
      video.Description, video.DescriptionAr,
      video?.Player.Id,
      request.Lang == Languages.En ? video?.Player.Name : video?.Player.NameAr,
      video?.Coach.Id,
      request.Lang == Languages.En ? video?.Coach.FirstName + ' ' + video?.Coach.LastName : video?.Coach.FirstNameAr + ' ' + video?.Coach.LastNameAr,
      video.Category.Id,
      request.Lang == Languages.En ? video.Category.Name : video.Category.NameAr,
      video.CreatedOn, video.ModifiedOn, video.IsDeleted,
      video.CreatedBy?.FullName, video.CreatedById, video.ModifiedBy?.FullName, video.ModifiedById
    ));
  }
}
