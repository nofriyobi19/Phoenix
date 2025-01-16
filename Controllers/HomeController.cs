using Microsoft.AspNetCore.Mvc;

namespace Phoenix.Controllers;

public class HomeController : Controller {
    public IActionResult Index() {
        return RedirectToAction("index", "room");
    }
}