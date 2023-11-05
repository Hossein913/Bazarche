using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using App.Domain.Core._User.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs
{
    public class SuperAdminRoleSeedData : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> entity)
        {
            entity.HasData(new AppRole
            {
                Id = 1,
                Name = "SuperAdmin",
                PermissionName = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                ConcurrencyStamp = null
            });

        }

    }

    public class SuperAdminUserSeedData : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            var appUser = new AppUser
            {
                Id = 1,
                Email = "Admin@mail.com",
                EmailConfirmed = true,
                UserName = "Admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                CreatedAt = DateTime.Now,
                IsActive = true,
            };

            //set user password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Admin@mail.com");

            //seed user
            entity.HasData(appUser);
        }
    }

    public class AdminUserRoleSeedData : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> entity)
        {

            entity.HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            });
        }
    }
}


