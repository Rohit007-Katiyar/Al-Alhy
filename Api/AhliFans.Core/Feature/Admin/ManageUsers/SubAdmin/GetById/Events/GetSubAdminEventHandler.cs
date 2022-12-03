using AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetById.DTO;
using AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetById.Specifications;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetById.Events;

public class GetSubAdminEventHandler : IRequestHandler<GetSubAdminByIdEvent,ActionResult>
{
  private readonly IRepository<Security.Entities.Admin> _adminRepository;
  public GetSubAdminEventHandler(IRepository<Security.Entities.Admin> adminRepository)
  {
    _adminRepository = adminRepository;
  }
  public async Task<ActionResult> Handle(GetSubAdminByIdEvent request, CancellationToken cancellationToken)
  {
    var admin = await _adminRepository.GetBySpecAsync(new GetAdminById(request.AdminId),cancellationToken);
    if (admin is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new SubAdminDto(admin.Id, admin.FullName, admin.Email == admin.PhoneNumber+RootAdmin.TempEmail? null:admin.Email, admin.PhoneNumber, admin.IsBlocked,
      admin.IsActive, admin.UserCreate?.FullName!, admin.CreatedOn, admin.UserModify?.FullName!, admin.ModifiedOn));
  }
}
