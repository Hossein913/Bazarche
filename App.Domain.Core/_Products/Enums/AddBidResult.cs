using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._Products.Enums
{
    public enum AddBidResult
    {
        Succeeded,
        LessThanBasePrice,
        LessThanMaxBid
    }
}
