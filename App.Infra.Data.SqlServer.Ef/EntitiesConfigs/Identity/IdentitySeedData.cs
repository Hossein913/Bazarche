using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using App.Domain.Core._User.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs.Identity
{
    public class RoleSeedData : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> entity)
        {
            entity.HasData(
                new AppRole{
                Id = 1,
                Name = "Admin",
                PermissionName = "SuperAdmin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = null
                },
                new AppRole
                {
                    Id = 2,
                    Name = "Seller",
                    PermissionName = "DefaultSeller",
                    NormalizedName = "SELLER",
                    ConcurrencyStamp = null
                },
                new AppRole
                {
                    Id = 3,
                    Name = "Customer",
                    PermissionName = "DefaultCustomer",
                    NormalizedName = "CUSTOMER",
                    ConcurrencyStamp = null
                }
            );

        }

    }

    public class UserSeedData : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            var adminUser = new AppUser
            {
                Id = 1,
                Email = "Admin@mail.com",
                EmailConfirmed = true,
                UserName = "Admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                CreatedAt = DateTime.Now,
                IsActive = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var sellerUser1 = new AppUser
            {
                Id = 2,
                Email = "Seller1@mail.com",
                EmailConfirmed = true,
                UserName = "Seller1@mail.com",
                NormalizedUserName = "SELLER1@MAIL.COM",
                CreatedAt = DateTime.Now,
                IsActive = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var sellerUser2 = new AppUser
            {
                Id = 3,
                Email = "Seller2@mail.com",
                EmailConfirmed = true,
                UserName = "Seller2@mail.com",
                NormalizedUserName = "SELLER2@MAIL.COM",
                CreatedAt = DateTime.Now,
                IsActive = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var customerUser1 = new AppUser
            {
                Id = 4,
                Email = "customer1@mail.com",
                EmailConfirmed = true,
                UserName = "customer1@mail.com",
                NormalizedUserName = "CUSTOMER1@MAIL.COM",
                CreatedAt = DateTime.Now,
                IsActive = true,
                SecurityStamp = Guid.NewGuid().ToString()
            }; 

            var customerUser2 = new AppUser
            {
                Id = 5,
                Email = "customer2@mail.com",
                EmailConfirmed = true,
                UserName = "customer2@mail.com",
                NormalizedUserName = "CUSTOMER2@MAIL.COM",
                CreatedAt = DateTime.Now,
                IsActive = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //set user password
            PasswordHasher<AppUser> ph1 = new PasswordHasher<AppUser>();

            adminUser.PasswordHash = ph1.HashPassword(adminUser, "1111@Admin");

            sellerUser1.PasswordHash = ph1.HashPassword(sellerUser1, "1111@Seller");

            sellerUser2.PasswordHash = ph1.HashPassword(sellerUser2, "1111@Seller");

            customerUser1.PasswordHash = ph1.HashPassword(customerUser1, "1111@Customer");

            customerUser2.PasswordHash = ph1.HashPassword(customerUser2, "1111@Customer");

            //seed user
            entity.HasData(adminUser, sellerUser1, sellerUser2, customerUser1, customerUser2);
        }
    }

    public class UsertoRoleSeedData : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> entity)
        {

            entity.HasData(
                new IdentityUserRole<int>{RoleId = 1,UserId = 1},
                new IdentityUserRole<int>{RoleId = 2,UserId = 2},
                new IdentityUserRole<int>{RoleId = 2,UserId = 3},
                new IdentityUserRole<int>{RoleId = 3,UserId = 4},
                new IdentityUserRole<int>{RoleId = 3,UserId = 5}
                );
        }
    }

    public class UserClaimsSeedData : IEntityTypeConfiguration<IdentityUserClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> entity)
        {

            entity.HasData(
                new IdentityUserClaim<int> { UserId= 1, ClaimType = "UserId", ClaimValue = "1"},

                new IdentityUserClaim<int> { UserId= 2, ClaimType = "UserId", ClaimValue = "2"},
                new IdentityUserClaim<int> { UserId= 2, ClaimType = "SellerId", ClaimValue = "1"},
                new IdentityUserClaim<int> { UserId= 2, ClaimType = "BoothId", ClaimValue = "1"},

                new IdentityUserClaim<int> { UserId= 3, ClaimType = "UserId", ClaimValue = "3"},
                new IdentityUserClaim<int> { UserId= 3, ClaimType = "SellerId", ClaimValue = "2"},
                new IdentityUserClaim<int> { UserId= 3, ClaimType = "BoothId", ClaimValue = "2"},

                new IdentityUserClaim<int> { UserId= 4, ClaimType = "UserId", ClaimValue = "1"},
                new IdentityUserClaim<int> { UserId= 4, ClaimType = "CustomerId", ClaimValue = "1"},
                new IdentityUserClaim<int> { UserId= 4, ClaimType = "CartId", ClaimValue = "1"},

                new IdentityUserClaim<int> { UserId= 5, ClaimType = "UserId", ClaimValue = "5"},
                new IdentityUserClaim<int> { UserId= 5, ClaimType = "CustomerId", ClaimValue = "2"},
                new IdentityUserClaim<int> { UserId= 5, ClaimType = "CartId", ClaimValue = "2"}


                );
        }
    }
}


