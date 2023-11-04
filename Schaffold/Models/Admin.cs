using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? ProfilePicId { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? Wallet { get; set; }

    public string? ShabaNumber { get; set; }

    public virtual Picture? ProfilePic { get; set; }
}
