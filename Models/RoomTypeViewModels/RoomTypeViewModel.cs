namespace Phoenix.Models.RoomTypeViewModels;

public class RoomTypeViewModel {
    public long RoomTypeId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int GuestLimit { get; set; }

    public decimal Cost { get; set; }
}