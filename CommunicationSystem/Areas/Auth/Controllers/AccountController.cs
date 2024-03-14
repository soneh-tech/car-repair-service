
using Microsoft.Build.Framework.Profiler;
using Microsoft.Extensions.Hosting.Internal;

namespace CommunicationSystem.Areas.Auth.Controllers
{
    public class AccountController : Controller
    {
        public IServiceType serviceType;
        public ICar car;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IAccount account;
        private readonly SignInManager<AppUser> signInManager;
        private ProfileViewModel profileViewModel = new();

        public AccountController(IWebHostEnvironment hostingEnvironment, IAccount account, IServiceType serviceType,
            ICar car, SignInManager<AppUser> signInManager)
        {
            this.car = car;
            this.serviceType = serviceType;
            this.hostingEnvironment = hostingEnvironment;
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
        public async Task<IActionResult> Index(UserDTO user, string? returnUrl)
        {
            if (ModelState.IsValid)
            {

                var result = await account.AuthenticateUser(user);
                if (result is "engineer" or "owner")
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Appointment");
                    }
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
        [HttpPost]
        private async Task<string> ProcessedPhoto(ProfileViewModel model)
        {
            string uniqueFile = string.Empty;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "img");
                uniqueFile = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFile);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                { await model.Photo.CopyToAsync(filestream); }
            }
            return uniqueFile;
        }
        public async Task<IActionResult> UpdateProfile(ProfileViewModel model)
        {
            if (signInManager.IsSignedIn(User))
            {
                var image_url = await ProcessedPhoto(model);
                await serviceType.ModifyEngineerProfile(model.enginner.EngineerID, image_url,model.selected_service, model.selected_car);
                return RedirectToAction("profile");
            }
            else
            {
                return RedirectToAction("index");
            }

        }

    }
}
