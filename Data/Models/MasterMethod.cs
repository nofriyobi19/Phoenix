using System;
using System.Collections.Generic;

namespace Phoenix.Data.Models;

public partial class MasterMethod
{
    public long MethodId { get; set; }

    public string Type { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Reservation> ReservationPaymentMethods { get; set; } = new List<Reservation>();

    public virtual ICollection<Reservation> ReservationReservationMethods { get; set; } = new List<Reservation>();
}
