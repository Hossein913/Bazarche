using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Entities;
using App.Domain.Core._User.Dtos.ProvinceDto;
using App.Domain.Core._User.Entities;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Sellers
{
    public class GetSellerDetailsViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Birthdate { get; set; }

        public string? ShabaNumber { get; set; }

        public string? ProfilePicUrl { get; set; }

       // public int? ProfilePicId { get; set; }

        public virtual Address? Address { get; set; }

        public virtual Booth? Booth { get; set; }

        public virtual AppUser AppUser { get; set; }

    }
}

//Id { get; set; }
//FirstName { get; set; }
//LastName { get; set; }
//Birthdate { get; set; }
//ShabaNumber { get; set; }
//Province { get; set; }
//City { get; set; }
//FullAddress { get; set; }
//PostalCode { get; set; }
//ProfilePicUrl { get; set; }
//Address { get; set; }
//Booth { get; set; }
//AppUser { get; set; }