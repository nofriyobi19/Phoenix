using System;
using System.Collections.Generic;

namespace Phoenix.Data.Models;

public partial class Guest
{
    public long GuestId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public string Citizenship { get; set; } = null!;

    public string IdNumber { get; set; } = null!;

    public string Username { get; set; } = null!;

    public virtual Account UsernameNavigation { get; set; } = null!;
}
