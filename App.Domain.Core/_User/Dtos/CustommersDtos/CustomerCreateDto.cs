﻿using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._User.Dtos.CustommersDtos;

public partial class CustomerCreateDto
{
    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public bool? Sexuality { get; set; }

    public int? ProfilePicId { get; set; }

    public int? AddressId { get; set; }

    public int CartOrderId { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? Wallet { get; set; }

    public int AppUserId { get; set; }


    //#region Navigation properties

    //public virtual Address? Address { get; set; }
    //public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    //public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    //public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    //public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    //public virtual Picture? ProfilePic { get; set; }

    //public virtual AppUser AppUser { get; set; }

    //#endregion
}
