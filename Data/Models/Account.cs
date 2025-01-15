using System;
using System.Collections.Generic;

namespace Phoenix.Data.Models;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? IsAdministrator { get; set; }

    public virtual ICollection<Guest> Guests { get; set; } = new List<Guest>();
}
