using System;
using System.Collections.Generic;

namespace Phoenix.Data.Models;

public partial class RoomInventory
{
    public long RoomInventoryId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public long InventoryId { get; set; }

    public int Quantity { get; set; }

    public string Uom { get; set; } = null!;

    public virtual Inventory Inventory { get; set; } = null!;

    public virtual Room RoomNumberNavigation { get; set; } = null!;
}
