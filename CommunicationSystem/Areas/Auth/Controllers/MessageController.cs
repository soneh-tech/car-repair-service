namespace CommunicationSystem.Controllers
{
    public class MessageController : Controller
    {
        public MessageController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
