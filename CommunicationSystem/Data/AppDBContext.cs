
namespace CommunicationSystem.Data
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ServiceHistory> ServiceHistories { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
    }
}
