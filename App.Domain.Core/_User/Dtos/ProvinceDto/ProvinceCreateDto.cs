using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._User.Dtos.ProvinceDto
{
    public class ProvinceCreateDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        #region Navigation properties
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        #endregion
    }
}
