namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetAll.Dto;
public record AdminsDto(Guid Id, string? Email, string UserName, string PhoneNumber, bool IsBlocked,bool IsActiveAccount,string CreatedBy, string ModifiedBy);
