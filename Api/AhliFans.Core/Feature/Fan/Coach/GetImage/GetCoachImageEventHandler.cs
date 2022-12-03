using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Coach.GetImage;
public class GetCoachImageEventHandler : IRequestHandler<GetCoachImageEvent,ActionResult>
{
  private readonly IRepository<Entities.Coach> _coachRepository;
  private readonly IFileManager _fileManager;
  public GetCoachImageEventHandler(IRepository<Entities.Coach> coachRepository, IFileManager fileManager)
  {
    _coachRepository = coachRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(GetCoachImageEvent request, CancellationToken cancellationToken)
  {
    var coach = await _coachRepository.GetByIdAsync(request.CoachId,cancellationToken);
    if (coach is null) return new BadRequestObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    var coachImage = string.IsNullOrEmpty(coach.Pic) ?
      await _fileManager.FileProxy<Entities.Coach>("coach.png", "") :
      await _fileManager.FileProxy<Entities.Coach>(coach.Pic, coach.Id.ToString());

    try
    {
      var streamReader = await coachImage.ReadStreamAsync();
      return new FileStreamResult(streamReader, _fileManager.GetContentType(string.IsNullOrEmpty(coach.Pic) ? "coach.png" : coach.Pic));
    }
    catch
    {
      return new BadRequestObjectResult(new FanResponse("Can't get the image", ResponseStatus.Error));
    }
  }
}
