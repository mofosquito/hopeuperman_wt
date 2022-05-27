using hopeuperman_wt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hopeuperman_wt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly hopeuperman_db_context database;

        public HomeController(ILogger<HomeController> logger, hopeuperman_db_context database)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var items = database.MapMarkers.ToList();
            return View();
        }

        public IActionResult More()
        {
            return View();
        }

        public IActionResult Tutorial()
        {
            return View();
        }
        public IActionResult InteractiveMap()
        {
            return View();
        }

        public IActionResult UserAccount()
        {
            return View();
        }

        public IActionResult userInput()
        {
            return View();
        }
        public IActionResult Dialeclopedia()
        {
            return View();
        }
        public IActionResult Policies()
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