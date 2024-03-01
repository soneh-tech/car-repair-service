
using Microsoft.Build.Framework.Profiler;

namespace CommunicationSystem.Areas.Auth.Controllers
{
    public class AccountController : Controller
    {
        public IServiceType serviceType;
        public ICar car;
        private readonly IAccount account;
        private readonly SignInManager<AppUser> signInManager;
        private ProfileViewModel profileViewModel = new();

        public AccountController(IAccount account, IServiceType serviceType,
            ICar car, SignInManager<AppUser> signInManager)
        {
            this.car = car;
            this.serviceType = serviceType;
            this.account = account;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var result = await account.AuthenticateUser(user);
                if (result is "engineer" or "owner")
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.Error = result;
                    return View();
                }
            }
            else
            {
                return View(user);
            }

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                if (user.YearOfExperience >= 0)
                    user.IsEngineer = true;
                else
                    user.IsEngineer = false;
                await account.CreateUserAsync(user);
                return View();
            }
            else
            {
                return View(user);
            }

        }
        public async Task<IActionResult> Profile()
        {
            if (signInManager.IsSignedIn(User))
            {
                profileViewModel = await account.GetUserProfile(User.Identity.Name);
                profileViewModel.cars = await car.GetAllCars();
                profileViewModel.services = await serviceType.GetServiceTypes();
                return View(profileViewModel);
            }
            else
            {
                return RedirectToAction("index");
            }

        }
        public async Task<IActionResult> GetCar(string carmodel)
        {
            if (signInManager.IsSignedIn(User))
            {
                profileViewModel.selected_car = await car.GetCar(carmodel);
                return PartialView("_CarPartialView", profileViewModel);
            }
            else
            {
                return RedirectToAction("index");
            }

        }
        public async Task<IActionResult> GetService(string servicetype)
        {
            if (signInManager.IsSignedIn(User))
            {
                profileViewModel.selected_service = await serviceType.GetService(servicetype);
                return PartialView("_ServicePartialView", profileViewModel);
            }
            else
            {
                return RedirectToAction("index");
            }

        }
        public async Task<IActionResult> UpdateProfile(ProfileViewModel model)
        {
            if (signInManager.IsSignedIn(User))
            {
               await serviceType.ModifyEngineerProfile(model.enginner.EngineerID, model.selected_service, model.selected_car);
                return RedirectToAction("profile");
            }
            else
            {
                return RedirectToAction("index");
            }

        }

    }
}
