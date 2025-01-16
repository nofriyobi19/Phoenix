using Phoenix.Data.Models;
using Phoenix.Models.RoomTypeViewModels;

namespace Phoenix.Helpers;

public static class RoomTypeMapper {
    public static RoomTypeViewModel ToRoomTypeViewModel(this RoomType roomType) {
        return new RoomTypeViewModel {
            RoomTypeId = roomType.RoomTypeId,
            Code = roomType.Code,
            Description = roomType.Description,
            GuestLimit = roomType.GuestLimit,
            Cost = roomType.Cost
        };
    }

    public static RoomType ToRoomType(this RoomTypeViewModel roomTypeViewModel) {
        return new RoomType {
            RoomTypeId = roomTypeViewModel.RoomTypeId,
            Code = roomTypeViewModel.Code,
            Description = roomTypeViewModel.Description,
            GuestLimit = roomTypeViewModel.GuestLimit,
            Cost = roomTypeViewModel.Cost
        };
    }
}