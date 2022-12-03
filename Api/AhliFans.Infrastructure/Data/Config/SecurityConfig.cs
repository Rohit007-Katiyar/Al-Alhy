using AhliFans.Core.Feature.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AhliFans.Infrastructure.Data.Config;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder)
  {

    builder.HasMany(e => e.UserRoles)
            .WithOne()
            .HasForeignKey(uc => uc.RoleId)
            .IsRequired();
  }
}
public class UserConfig : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasMany(e => e.Claims)
            .WithOne()
            .HasForeignKey(uc => uc.UserId)
            .IsRequired();

    builder.HasMany(e => e.Logins)
            .WithOne()
            .HasForeignKey(uc => uc.UserId)
            .IsRequired();

    builder.HasMany(e => e.Tokens)
            .WithOne()
            .HasForeignKey(ut => ut.UserId)
            .IsRequired();

    builder.HasMany(e => e.UserRoles)
            .WithOne()
            .HasForeignKey(uc => uc.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
  }
}
public class AdminConfig : IEntityTypeConfiguration<Admin>
{
  public void Configure(EntityTypeBuilder<Admin> builder) => builder
           .ToTable(nameof(Admin));
}
