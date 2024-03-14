using CommunicationSystem.Areas.Web.ViewModels;

namespace CommunicationSystem.Controllers
{
    public class BookingController : Controller
    {
        public IServiceType serviceType;
        public IEngineer engineer;
        IOwner owner;
        public IAppointment appointment;
        public ICar car;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public BookingController(IServiceType serviceType,
            IOwner owner,
            IAppointment appointment,
            IEngineer engineer,
            ICar car,
             UserManager<AppUser> userManager,
             RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager)
        {
            this.car = car;
            this.owner = owner;
            this.appointment = appointment;
            this.serviceType = serviceType;
            this.engineer = engineer;
            this.appointment = appointment;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var _car = await car.GetAllCars();
            var _service = await serviceType.GetServiceTypes();
            var model = new BookingViewModel { Cars = _car, ServiceTypes = _service };
            return View(model);
        }

        public async Task<IActionResult> FindSpecialists(string carmodel, string servicetype)
        {
            var specialists = await serviceType.FindSpecialists(carmodel, servicetype);
            var groupedSpecialists = (IEnumerable<IEnumerable<Engineer>>)specialists
                .Select((value, index) => new { Index = index, Value = value })
                .GroupBy(x => x.Index / 4)
                .Select(g => g.Select(x => x.Value).ToList())
                .ToList();
            var model = new BookingViewModel { Specialists = groupedSpecialists };
            return PartialView("_SpecialistPartialView", model);

        }

        public async Task<IActionResult> ViewDetails(string id)
        {
            var model = await engineer.GetEngineer(id);
            ViewBag.CarID = model.CarID;
            return View(model);
        }
        public async Task<IActionResult> BookAppointment(string id,int carID)
        {
           var engr = await engineer.GetEngineer(id);
            if (signInManager.IsSignedIn(User))
            {
                var user = await userManager.FindByEmailAsync(User.Identity.Name);
                var car_owner = await owner.GetOwner(user.Id);
                var model = await appointment.BookAppointment(engr.EngineerID, car_owner.OwnerID,carID);

                return RedirectToAction("index");
            }
            return Redirect("/auth/account/index");
        }
    }
}
