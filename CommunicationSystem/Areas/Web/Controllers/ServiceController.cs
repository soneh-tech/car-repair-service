namespace CommunicationSystem.Controllers
{
    public class ServiceController : Controller
    {
        public ServiceController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
