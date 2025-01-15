using System;
using System.Collections.Generic;

namespace Phoenix.Data.Models;

public partial class Inventory
{
    public long InventoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Stock { get; set; }

    public string Uom { get; set; } = null!;

    public virtual ICollection<RoomInventory> RoomInventories { get; set; } = new List<RoomInventory>();
}
