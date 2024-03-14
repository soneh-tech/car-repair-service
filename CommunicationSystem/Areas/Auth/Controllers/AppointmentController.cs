using CommunicationSystem.Areas.Auth.Models;
using CommunicationSystem.Areas.Auth.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationSystem.Areas.Auth.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IAppointment appointment;
        private readonly ICar car;
        private readonly IServiceType serviceType;
        private readonly IEngineer engineer;
        private readonly IOwner owner;

        public AppointmentController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IAppointment appointment,
            ICar car,
            IServiceType serviceType,
            IEngineer engineer,IOwner owner)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.appointment = appointment;
            this.car = car;
            this.serviceType = serviceType;
            this.engineer = engineer;
            this.owner = owner;
        }
        public async Task<IActionResult> Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                var user = await userManager.FindByEmailAsync(User.Identity.Name);
                var engr = await engineer.GetEngineer(user.Id);
                var ownr = await owner.GetOwner(user.Id);
                if(engr is not null)
                {
                    var appointments = await appointment.GetAppointments(engr.EngineerID);
                }
                return View();
            }
            else
            {
                return Redirect("account/index");
            }
        }
    }
}
