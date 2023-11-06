using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffold.Models
{
    public class AppRole : IdentityRole<int>
    {
        public string PermissionName { get; set; }
    }
}
