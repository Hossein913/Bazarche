using App.Domain.Core.Booths.Entities;
using App.Domain.Core.Common.Entities;
using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.User.Dtos.Sellers;

public partial class SellerOutputDto
{
    public int Id { get; set; }

    public string Firestname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public bool Sexuality { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int ProfilePictureId { get; set; }

    public int AddressId { get; set; }

    public string Phonenumber { get; set; } = null!;

    public string Homenumber { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public string ShabaNumber { get; set; } = null!;

    public int BoothId { get; set; }

    public int LicenseNumber { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Booth Booth { get; set; } = null!;

    public virtual Picture ProfilePicture { get; set; } = null!;
}
