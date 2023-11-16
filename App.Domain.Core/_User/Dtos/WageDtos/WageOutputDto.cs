using App.Domain.Core._Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._User.Dtos.WageDtos
{
    public class WageOutputDto
    {
        public int Id { get; set; }

        public string Booth { get; set; }

        public string customerfullName { get; set; }

        public string product { get; set; }

        public int price { get; set; }

        public int OrderitemId { get; set; }

        public int FeePercenteage { get; set; }

        public int WageAmount { get; set; }

        public int Count { get; set; }

        //#region Navigation properties
        //public virtual OrderItem Orderitem { get; set; } = null!;
        //#endregion
    }
}
