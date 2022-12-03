using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.Create.Events;

public class CreateEventHandler : IRequestHandler<CreateEvent,ActionResult>
{
  readonly CreateEventValidator _validator;
  readonly ILogger<CreateEventHandler> _logger;
  private readonly UserManager<Security.Entities.Admin> _userManager;
  private readonly IMapper _mapper;
  private readonly string _userId;
  public CreateEventHandler(CreateEventValidator validator, ILogger<CreateEventHandler> logger, UserManager<Security.Entities.Admin> userManager, IMapper mapper, IHttpContextAccessor context)
  {
    _validator = validator;
    _logger = logger;
    _userManager = userManager;
    _mapper = mapper;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value; 
  }
  public async Task<ActionResult> Handle(CreateEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validator.ValidateAsync(request, cancellationToken);
    if (!validation.IsValid)
    {
      _logger.LogError(request.ToString());
      return new BadRequestObjectResult(new AdminResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));
    }

    var admin = _mapper.Map<Security.Entities.Admin>(request);
    admin.CreatedBy = Guid.Parse(_userId);
    admin.CreatedOn = DateTime.Now;
    var result = await _userManager.CreateAsync(admin, request.Password);
    var addToResult = await _userManager.AddToRoleAsync(admin, Roles.Admin.ToString());

    if (!result.Succeeded || !addToResult.Succeeded)
    {
      var errors = result.Errors.Select(x => x.Description).Distinct();

      var enumerable = errors.ToList();
      _logger.LogError($"{request} Failed to register {string.Join(',', enumerable)}.");
      return new BadRequestObjectResult(new AdminResponse(string.Join(",", enumerable), ResponseStatus.Error));
    }

    _logger.LogInformation($"Admin {request.Email} New Admin Has Been Added Successfully.");
    return new OkObjectResult(new AdminResponse("New Admin Has Been Added Successfully.", ResponseStatus.Success));
  }
}
