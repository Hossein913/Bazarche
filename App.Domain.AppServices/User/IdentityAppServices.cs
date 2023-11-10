using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Dtos.Authenticate;
using App.Domain.Core._User.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App.Domain.AppServices.User
{
    public class IdentityAppServices : IIdentityAppServices
    {

        protected readonly UserManager<AppUser> _userManager;
        protected readonly SignInManager<AppUser> _signInManager;

        public IdentityAppServices(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AppUser> GetAppUser(UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(userLoginDto.Email);
            if (user != null)
            {

                return user;
            }

            return null;
        }

        public async Task<SignInResult> Login(AppUser appUser, UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser, userLoginDto.Password, userLoginDto.IsPersistent, true);
            return result;
        }


        public async Task<IList<string>> GetRoles(AppUser user, CancellationToken cancellationToken)
        {
           var roles = await _userManager.GetRolesAsync(user);
            if (roles != null)
            {
                return roles;
            }
            return null;
        }


        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
