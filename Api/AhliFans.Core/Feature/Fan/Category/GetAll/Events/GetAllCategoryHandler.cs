using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Category.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Category.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Responses;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace AhliFans.Core.Feature.Fan.Category.GetAll.Events;
internal class GetAllCategoryHandler : IRequestHandler<GetAllCategoryEvent, ActionResult>
{
  private readonly IRepository<Entities.Category> _categoryRepository;
  private readonly IRepository<Entities.MediaPhoto> _photoRepository;
  private readonly IRepository<Entities.NormalVideo> _normalVideoRepository;
  private readonly IRepository<Entities.MomentVideo> _momentVideoRepository;
  private readonly IRepository<Entities.Team> _teamRepository;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public GetAllCategoryHandler(IRepository<Entities.Category> categoryRepository,
    IRepository<Entities.MediaPhoto> photoRepository,
     IRepository<Entities.NormalVideo> normalVideoRepository,
     IRepository<Entities.MomentVideo> momentVideoRepository,
     IRepository<Entities.Team> teamRepository,
     IHttpContextAccessor httpContextAccessor
    )
  {
    _categoryRepository = categoryRepository;
    _photoRepository = photoRepository;
    _normalVideoRepository = normalVideoRepository;
    _momentVideoRepository = momentVideoRepository;
    _teamRepository = teamRepository;
    _httpContextAccessor = httpContextAccessor;
  }
  public async Task<ActionResult> Handle(GetAllCategoryEvent request, CancellationToken cancellationToken)
  {
    List<CategoryFanDto> dto = new List<CategoryFanDto>();
    List<CategoryIDNameListDto> res = new List<CategoryIDNameListDto>();
    try
    {
      var categories = await _categoryRepository.ListAsync(new GetAllCategory(request.PageIndex, request.PageSize, request.IsDeleted), cancellationToken);
      if (categories != null && categories.Count != 0)
      {
        var photoList = await _photoRepository.ListAsync(new GetAllPhoto(), cancellationToken);
        var normalVideoList = await _normalVideoRepository.ListAsync(new GetAllNormalVideo(), cancellationToken);
        var momentVideoList = await _momentVideoRepository.ListAsync(new GetAllMomentVideo(), cancellationToken);
        var teamList = await _teamRepository.ListAsync(new GetAllTeam(), cancellationToken);

        categories.ForEach(item =>
        {
          List<DataDto> data = new List<DataDto>();
          string CategoryName = item.Name;
          if (request.Lang == Languages.Ar)
          {
            CategoryName = item.NameAr;
          }

          photoList.Where(x => x.CategoryId == item.Id).OrderByDescending(m => m.CreatedOn).ToList().ForEach(photo =>
          {
            string LeagueName = photo.League.Name;
            if (request.Lang == Languages.Ar)
            {
              LeagueName = photo.League.NameAr;
            }
            //get match name 
            var team = teamList.Where(x => x.Id == photo.Match.OpponentTeamId).ToList();
            string MatchName = "AI Ahly vs " + team[0].Name;
            if (request.Lang == Languages.Ar)
            {
              MatchName = team[0].NameAr + " الاهلي ضد";
            }
            data.Add(new DataDto(LeagueName, MatchName, 
              team[0]?.Logo, 
              $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/MediaPhoto/{item.Id}/{photo.Photo}", 
              false, 
              photo.IsExclusiveContent, 
              photo.Month, 
              string.Empty, "MediaPhotos", photo.CreatedOn));
          });

          normalVideoList.Where(x => x.CategoryId == item.Id).OrderByDescending(m => m.CreatedOn).ToList().ForEach(video =>
          {
            string LeagueName = video.League.Name;
            if (request.Lang == Languages.Ar)
            {
              LeagueName = video.League.NameAr;
            }
            //get match name 
            var team = teamList.Where(x => x.Id == video.Match.OpponentTeamId).ToList();
            string MatchName = "AI Ahly vs " + team[0].Name;
            if (request.Lang == Languages.Ar)
            {
              MatchName = team[0].NameAr + " الاهلي ضد";
            }
            var fileName = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/NormalVideo/NormalVideo_{video.Id}.png";
            data.Add(new DataDto(LeagueName, MatchName, team[0]?.Logo, video.VideoURL, true, null, video.Month, fileName, "NormalVedio", video.CreatedOn)); ;
          });

          momentVideoList.Where(x => x.CategoryId == item.Id).OrderByDescending(m => m.CreatedOn).ToList().ForEach(video =>
          {
            string LeagueName = video.League.Name;
            if (request.Lang == Languages.Ar)
            {
              LeagueName = video.League.NameAr;
            }
            var team = teamList.Where(x => x.Id == video.Match.OpponentTeamId).ToList();
            string MatchName = "AI Ahly vs " + team[0].Name;
            if (request.Lang == Languages.Ar)
            {
              MatchName = team[0].NameAr + " الاهلي ضد";
            }
            var fileName = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/MomentVideo/MomentVideo_{video.Id}.png";
            data.Add(new DataDto(LeagueName, MatchName, team[0]?.Logo, video.VideoURL, true, null, video.Month, fileName, "MomentVideo", video.CreatedOn));
          });

          if (photoList.Any(p => p.CategoryId == item.Id) || normalVideoList.Any(p => p.CategoryId == item.Id) || momentVideoList.Any(p => p.CategoryId == item.Id))
          {
            //res.Add(new CategoryIDNameListDto(item.Id, CategoryName, data));
            data = data.OrderByDescending(m => m.createdDate).Skip(0).Take(4).ToList();
            res.Add(new CategoryIDNameListDto(item.Id, CategoryName, data));
          }
        });

      }
    }
    catch (Exception ex)
    {
      dto.Add(new CategoryFanDto(2, "Error", res));
    }
    return new OkObjectResult(new APIResponse<CategoryIDNameListDto> { res = res });
  }
}
