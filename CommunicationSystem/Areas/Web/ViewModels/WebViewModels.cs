namespace CommunicationSystem.Areas.Web.ViewModels
{
    public class WebViewModels
    {
    }
    public class BookingViewModel
    {
        public IEnumerable<Car>? Cars { get; set; }
        public IEnumerable<ServiceType>? ServiceTypes { get; set; }
        public IEnumerable<IEnumerable<Engineer>>?  Specialists { get; set; }
    }
}
