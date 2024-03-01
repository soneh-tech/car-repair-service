using Microsoft.AspNetCore.Mvc;

namespace CommunicationSystem.Areas.Auth.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
