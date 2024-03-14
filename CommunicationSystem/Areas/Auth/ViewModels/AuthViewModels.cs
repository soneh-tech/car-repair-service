namespace CommunicationSystem.Areas.Auth.ViewModels
{
    public class ProfileViewModel
    {
        public Engineer? enginner { get; set; }
        public Owner? owner { get; set; }
        public IEnumerable<Car>? cars { get; set; }
        public IEnumerable<ServiceType>? services { get; set; }
        public Car? selected_car { get; set; }
        public ServiceType? selected_service { get; set; }
        public IFormFile? Photo { get; set; }
    }

}
