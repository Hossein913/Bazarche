﻿using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._User.Entities;

public partial class Seller
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? AddressId { get; set; }

    public int? ProfilePicId { get; set; }

    public DateTime? Birthdate { get; set; }

    public bool? IsActive { get; set; }

    public string? ShabaNumber { get; set; }

    public int? BoothId { get; set; }

    public int AppuserId { get; set; }


    #region Navigation properties
    public virtual Address? Address { get; set; }

    public virtual Booth? Booth { get; set; }

    public virtual Picture? ProfilePic { get; set; }

    public virtual AppUser AppUser { get; set; }

    #endregion

}
