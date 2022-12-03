using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.ChangeStatus.Events;
public class ChangeStatusEventHandler : IRequestHandler<ChangeAdminStatusEvent, ActionResult>
{
  private readonly AvailabilityValidator _validator;
  private readonly ILogger<ChangeStatusEventHandler> _logger;
  private readonly IRepository<Security.Entities.Admin> _adminRepository;
  private readonly string _userId;
  public ChangeStatusEventHandler(AvailabilityValidator validator, ILogger<ChangeStatusEventHandler> logger, IRepository<Security.Entities.Admin> adminRepository, IHttpContextAccessor context)
  {
    _validator = validator;
    _logger = logger;
    _adminRepository = adminRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value; 
  }
  public async Task<ActionResult> Handle(ChangeAdminStatusEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validator.ValidateAsync(request, cancellationToken);
    if (!validation.IsValid)
    {
      _logger.LogError(request.ToString());
      return new BadRequestObjectResult(new AdminResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));
    }

    var subAdmin = await _adminRepository.GetByIdAsync(request.AdminId, cancellationToken);
    if (subAdmin is null) return new BadRequestObjectResult(new AdminResponse("Can't get this admin", ResponseStatus.Info));

    if (!subAdmin.IsBlocked)
    {
      return await Block(subAdmin,cancellationToken);
    }
    return await Activate(subAdmin, cancellationToken);
  }

  private async Task<ActionResult> Block(Security.Entities.Admin subAdmin, CancellationToken cancellationToken)
  {
    subAdmin.IsActive = false;
    subAdmin.IsBlocked = true;
    subAdmin.ModifiedBy = Guid.Parse(_userId);
    subAdmin.ModifiedOn = DateTime.Now;
    await _adminRepository.UpdateAsync(subAdmin, cancellationToken);
    await _adminRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Deactivate sub-admin done, You can activate him at any time.",
      ResponseStatus.Success));
  } 
  private async Task<ActionResult> Activate(Security.Entities.Admin subAdmin, CancellationToken cancellationToken)
  {
    subAdmin.IsActive = false;
    subAdmin.IsBlocked = false;
    subAdmin.ModifiedBy = Guid.Parse(_userId);
    subAdmin.ModifiedOn = DateTime.Now;
    await _adminRepository.UpdateAsync(subAdmin, cancellationToken);
    await _adminRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Activate sub-admin done, You can deactivate him at any time.",
      ResponseStatus.Success));
  }
}
