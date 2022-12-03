using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Preferences.Get.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Preferences.Add.Events;

public class AddPreferencesEventHandler : IRequestHandler<AddPreferencesEvent,ActionResult>
{
  private readonly IMapper _mapper;
  private readonly IRepository<FanPreference> _preferencesRepo;
  private readonly IHttpContextAccessor _context;
  public AddPreferencesEventHandler(IMapper mapper, IRepository<FanPreference> preferencesRepo, IHttpContextAccessor context)
  {
    _mapper = mapper;
    _preferencesRepo = preferencesRepo;
    _context = context;
  }
  public async Task<ActionResult> Handle(AddPreferencesEvent request, CancellationToken cancellationToken)
  {
    var idClaim = _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "User Id");
    var userId = idClaim == default ? request.UserId! : Guid.Parse(idClaim.Value); 
    var validateUser = await _preferencesRepo.GetBySpecAsync(new GetPreferenceByUser(userId ?? Guid.Empty), cancellationToken);
    if (validateUser is not null)
      return new BadRequestObjectResult(new FanResponse("Sorry but you already had selected your preferences before!",ResponseStatus.Error));

    var preference = _mapper.Map<FanPreference>(request);
    preference.FanId = userId;

    await _preferencesRepo.AddAsync(preference, cancellationToken);
    await _preferencesRepo.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new FanResponse("Operation done successfully", ResponseStatus.Success));
  }
}
