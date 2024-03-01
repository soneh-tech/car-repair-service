using Microsoft.AspNetCore.Mvc;

namespace CommunicationSystem.Areas.Auth.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
