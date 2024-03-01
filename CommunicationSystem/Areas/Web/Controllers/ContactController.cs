using Microsoft.AspNetCore.Mvc;

namespace CommunicationSystem.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
