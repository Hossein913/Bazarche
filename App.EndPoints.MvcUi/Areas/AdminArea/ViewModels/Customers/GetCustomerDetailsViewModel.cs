using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using App.Domain.Core._User.Enums;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Customers
{
    public class GetCustomerDetailsViewModel
    {
        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public CustomerSexuality Sexuality { get; set; }

        public string ProfilePicFile { get; set; }

        //public int? ProfilePicId { get; set; }

        public int? AddressId { get; set; }

        public int? CartOrderId { get; set; }

        public DateTime? Birthdate { get; set; }

        public int? Wallet { get; set; }

        public int AppUserId { get; set; }

        public int OrdersCount { get; set; }


        #region Navigation properties

        public virtual Address? Address { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual Picture? ProfilePic { get; set; }

        public virtual AppUser AppUser { get; set; }

        #endregion
    }
}

//Id { get; set; }
//Firstname { get; set; }
//Lastname { get; set; }
//Sexuality { get; set; }
//ProfilePicFile { get; set; }
//AddressId { get; set; }
//CartOrderId { get; set; }
//Birthdate { get; set; }
//Wallet { get; set; }
//AppUserId { get; set; }
//OrdersCount { get; set; }
//Address { get; set; }
//Auctions { get; set; }
//Bids { get; set; } 
//Comments { get; set; } 
//Orders { get; set; } 
//ProfilePic { get; set; }
//AppUser { get; set; }
