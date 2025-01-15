using System;
using System.Collections.Generic;

namespace Phoenix.Data.Models;

public partial class Reservation
{
    public long ReservationId { get; set; }

    public string ReservationCode { get; set; } = null!;

    public long ReservationMethodId { get; set; }

    public DateTime BookDate { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public decimal Cost { get; set; }

    public DateTime? PaymentDate { get; set; }

    public long PaymentMethodId { get; set; }

    public string? Remark { get; set; }

    public virtual MasterMethod PaymentMethod { get; set; } = null!;

    public virtual MasterMethod ReservationMethod { get; set; } = null!;
}
