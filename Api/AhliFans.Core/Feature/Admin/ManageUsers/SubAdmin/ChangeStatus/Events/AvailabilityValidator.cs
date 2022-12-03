using FluentValidation;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.ChangeStatus.Events;
public class AvailabilityValidator : AbstractValidator<ChangeAdminStatusEvent>
{
  public AvailabilityValidator()
  {
    RuleFor(admin => admin.AdminId).NotEmpty().WithMessage("Id is required");
  }
}
