using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Data;
using Data.Models;

namespace hopeuperman_web.Controllers
{
    public class MapMarkersController : Controller
    {
        private readonly ILogger<MapMarkersController> _logger;
        private readonly hopeupermanDbContext _context;
        public MapMarkersController(ILogger<MapMarkersController> logger, hopeupermanDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Maps    
        public ActionResult Index()
        {

            return View(_context.MapMarkers.ToList());
        }

        #region [Location]    
        public JsonResult GetLocation()
        {
            return Json(Location());
        }
        public IEnumerable<MapMarkers> Location()
        {
            return (from p in _context.MapMarkers
                    select new MapMarkers
                    {
                        MarkerId = p.MarkerId,
                        Longitude = p.Longitude,
                        Latitude = p.Latitude,
                        LocationName = p.LocationName,
                        MainLangauge = p.MainLangauge,
                        Dialect = p.Dialect,
                        AudioFile = p.AudioFile,
                        Translation = p.Translation,
                        Tag = p.Tag,
                        AddedbyAdmin = p.AddedbyAdmin,                        
                    }).ToList();
        }
        #endregion
    }
}
