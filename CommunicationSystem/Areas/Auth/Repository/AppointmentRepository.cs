
namespace CommunicationSystem.Repository
{
    public interface IAppointment
    {
        Task<bool> BookAppointment(int engineerID, int ownerID, int carID);
        Task<IEnumerable<Appointment>> GetAppointments(int engineerID);
    }
    public class AppointmentRepository : IAppointment
    {
        private readonly AppDBContext context;

        public AppointmentRepository(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> BookAppointment(int engineerID, int ownerID, int carID)
        {
            var appointment = new Appointment
            {
                EngineerID = engineerID,
                OwnerID = ownerID,
                AppointmentDateTime = DateTime.Now,
                Status = "pending",
                CarID = carID,
                Notes = "I need your service"
            };
            await context.Appointments.AddAsync(appointment);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments(int engineerID)
        {
            var apointments = await context.Appointments.Where(x => x.EngineerID == engineerID &&
            x.Status == "pending").Include(e=>e.Engineer).Include(c=>c.Car)
            .Include(c=>c.Car).Include(o=>o.Owner).ToListAsync();
            return apointments;
        }
    }
}
