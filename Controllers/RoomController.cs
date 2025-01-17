using Microsoft.AspNetCore.Mvc;
using Phoenix.Models.RoomTypeViewModels;
using Phoenix.Services;

namespace Phoenix.Controllers;

public class RoomController(RoomService roomService) : Controller {
    private readonly RoomService service = roomService;

    [Route("room")]
    public IActionResult Index() {
        return View();
    }

    [Route("room/type", Name = "roomTypes")]
    public async Task<IActionResult> GetAllRoomType() {
        var roomTypes = await service.GetAllRoomTypeAsync();
        return View("./RoomType/Index", roomTypes);
    }

    [Route("room/type/upsert/{id?}", Name = "upsertRoomType")]
    public async Task<IActionResult> UpsertRoomType(long? id) {
        RoomTypeViewModel model = id is null ? new() : await service.GetRoomTypeByIdAsync(id.Value);
        return View("./RoomType/Upsert", model);
    }

    [Route("room/type/save", Name = "saveRoomType")]
    public async Task<IActionResult> SaveRoomType(RoomTypeViewModel roomTypeViewModel) {
        var roomType = await service.SaveAsync(roomTypeViewModel);
        return RedirectToAction("GetAllRoomType");
    }
}