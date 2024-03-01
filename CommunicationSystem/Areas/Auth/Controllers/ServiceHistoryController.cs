using Microsoft.AspNetCore.Mvc;

namespace CommunicationSystem.Areas.Auth.Controllers
{
    public class ServiceHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
