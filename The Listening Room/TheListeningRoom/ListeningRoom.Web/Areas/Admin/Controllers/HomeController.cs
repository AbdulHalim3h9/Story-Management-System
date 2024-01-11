using Microsoft.AspNetCore.Mvc;

namespace ListeningRoom.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
