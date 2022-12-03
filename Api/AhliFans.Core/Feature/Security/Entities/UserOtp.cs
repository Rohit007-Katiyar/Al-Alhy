#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AhliFans.Core.Feature.Security.Entities;

public class UserOtp : BaseEntity<int>, IAggregateRoot
{
  public string Code { get; set; }
  public DateTime SendData { get; set; }
  [ForeignKey("User")] public Guid UserId { get; set; }
  public virtual User User { get; set; }
}
