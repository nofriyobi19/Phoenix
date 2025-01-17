using Phoenix.Data.Interfaces;
using Phoenix.Helpers;
using Phoenix.Models.RoomTypeViewModels;

namespace Phoenix.Services;

public class RoomService(IRoomTypeRepository roomTypeRepository) {
    private readonly IRoomTypeRepository _roomTypeRepository = roomTypeRepository;

    public async Task<List<RoomTypeViewModel>> GetAllRoomTypeAsync() {
        var roomTypes = await _roomTypeRepository.GetAllAsync();
        return [.. roomTypes.Select(e => e.ToRoomTypeViewModel())];
    }

    public async Task<RoomTypeViewModel> SaveAsync(RoomTypeViewModel roomTypeViewModel) {
        var roomType = await _roomTypeRepository.SaveAsync(roomTypeViewModel.ToRoomType());
        return roomType.ToRoomTypeViewModel();
    }

    public async Task<RoomTypeViewModel> GetRoomTypeByIdAsync(long roomTypeId) {
        var roomType = await _roomTypeRepository.GetByIdAsync(roomTypeId);
        return roomType.ToRoomTypeViewModel();
    }
}