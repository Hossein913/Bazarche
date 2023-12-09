using App.Domain.Core._User.Dtos.Authenticate;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._User.Contracts.AppServices
{
    public interface IIdentityAppServices
    {
        Task<List<IdentityError>> CustomerRegister(CustomerRegisterDto command, CancellationToken cancellationToken);
        Task<AppUser> GetAppUser(UserLoginDto userLoginDto, CancellationToken cancellationToken);
        Task<SignInResult> Login(AppUser appUser, UserLoginDto userLoginDto, CancellationToken cancellationToken);
        Task<IList<string>> GetRoles(AppUser user, CancellationToken cancellationToken);
        Task LogOut();
    }
}
