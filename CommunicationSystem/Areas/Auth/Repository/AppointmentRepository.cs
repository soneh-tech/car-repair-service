namespace CommunicationSystem.Repository
{
    public interface IAppointment { }
    public class AppointmentRepository: IAppointment
    {
        private readonly AppDBContext context;

        public AppointmentRepository(AppDBContext context)
        {
            this.context = context;
        }
    }
}
