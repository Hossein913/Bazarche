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
    public int AppuserId { get; set; }

    #region Navigation properties
    public virtual Picture? ProfilePic { get; set; }
    public virtual AppUser AppUser { get; set; }

    #endregion
}
