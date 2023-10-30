using App.Domain.Core.Common.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.User.Entities;

public partial class Admin
{
    public int Id { get; set; }

    public string Firestname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int ProfilePictureId { get; set; }

    public string Phonenumber { get; set; } = null!;

    public string Homenumber { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Wallet { get; set; }

    public string ShabaNumber { get; set; } = null!;

    public virtual Picture ProfilePicture { get; set; } = null!;
}
