using AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.Add.Events;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Add.Events;

public class AddCoachEventHandler : IRequestHandler<AddCoachEvent,ActionResult>
{
  private readonly IMediator _mediator;
  private readonly IRepository<Entities.Coach> _coachRepository;
  private readonly IFileManager _fileManager;
  private readonly IMapper _mapper;
  public AddCoachEventHandler(IMediator mediator,IRepository<Entities.Coach> coachRepository, IFileManager fileManager, IMapper mapper)
  {
    _mediator = mediator;
    _coachRepository = coachRepository;
    _fileManager = fileManager;
    _mapper = mapper;
  }
  public async Task<ActionResult> Handle(AddCoachEvent request, CancellationToken cancellationToken)
  {
    var coach = _mapper.Map<Entities.Coach>(request);
    if (coach.DateSigned > DateTime.Now)
    {
      return new BadRequestObjectResult(new AdminResponse("Bad Signed Date", ResponseStatus.Error));
    }
    coach = await _coachRepository.AddAsync(coach, cancellationToken);
    await _coachRepository.SaveChangesAsync(cancellationToken);

    bool saveProfile = await SavePic(request.Pic, coach.Id);
    if (!saveProfile) return new OkObjectResult(new AdminResponse("New coach has been added successfully,but saving Pic failure .", ResponseStatus.Warning));
    await _mediator.Send(new AddCoachAccountsEvent(coach.Id, request.FaceBookAccount, request.InstaAccount,
      request.TwitterAccount),cancellationToken);
    return new OkObjectResult(new AdminResponse("New coach has been added successfully", ResponseStatus.Success));
  }
  private async Task<bool> SavePic(IFormFile? request, int coachId)
  {
    if (request is null)
    {
      return true;
    }
    bool saveProfile = await _fileManager.SaveFileAsync<Entities.Coach>(request,
      request.FileName, coachId.ToString());
    return saveProfile;
  }
}
