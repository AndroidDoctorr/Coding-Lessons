
using Microsoft.AspNetCore.Mvc;

namespace RestaurantRater.Controllers;

[Route("api/[controller]")]
public class RestaurantController : Controller
{
    private readonly ILogger<RestaurantController> _logger;

    public RestaurantController(ILogger<RestaurantController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
