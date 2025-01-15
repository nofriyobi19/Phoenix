using System;
using System.Collections.Generic;

namespace Phoenix.Data.Models;

public partial class RoomType
{
    public long RoomTypeId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int GuestLimit { get; set; }

    public decimal Cost { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
