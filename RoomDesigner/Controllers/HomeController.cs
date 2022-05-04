using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoomDesigner.Enums;
using RoomDesigner.Models;
using System.Diagnostics;

namespace RoomDesigner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new RoomDesignerViewModel()
            {
                AvailableWallColors = Enum.GetNames(typeof(WallColor)).Select(v => new SelectListItem() { Text = v, Value = v}).ToList(),
                AvailableTvSize = Enum.GetNames(typeof(TvSize)).Select(v => new SelectListItem() { Text = v, Value = v }).ToList(),
                AvailableDecorations = Enum.GetNames(typeof(DecorationType)).Select(v => new SelectListItem() { Text = v, Value = v }).ToList(),
                AvailableCarpet = Enum.GetNames(typeof(CarpetType)).Select(v => new SelectListItem() { Text = v, Value = v }).ToList(),
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}