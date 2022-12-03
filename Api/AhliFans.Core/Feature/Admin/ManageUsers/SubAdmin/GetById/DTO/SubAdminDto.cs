
namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetById.DTO;

public record SubAdminDto(Guid Id,string Name, string? Email, string PhoneNumber, bool IsBlocked, bool IsActiveAccount, string CreatedBy,DateTime CreatedAt, string ModifiedBy,DateTime ModifiedAt);
