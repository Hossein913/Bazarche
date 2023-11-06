using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffold.Models
{
    public class AppUser : IdentityUser<int>
    {
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        #region Navigation properties
        public virtual Admin? Admin { get; set; }
        public virtual Seller? Seller { get; set; }
        public virtual Customer? Customer { get; set; }
        #endregion
    }
}
