using Microsoft.AspNetCore.Mvc;

namespace CommunicationSystem.Areas.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
