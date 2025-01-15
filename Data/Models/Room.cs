using System;
using System.Collections.Generic;

namespace Phoenix.Data.Models;

public partial class Room
{
    public string RoomNumber { get; set; } = null!;

    public int Floor { get; set; }

    public long RoomTypeId { get; set; }

    public virtual ICollection<RoomInventory> RoomInventories { get; set; } = new List<RoomInventory>();

    public virtual RoomType RoomType { get; set; } = null!;
}
