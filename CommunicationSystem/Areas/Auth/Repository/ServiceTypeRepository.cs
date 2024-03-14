
namespace CommunicationSystem.Repository
{
    public interface IServiceType
    {
        public Task<IEnumerable<Engineer>> FindSpecialists(string carmodel, string servicetype);
        public Task<ServiceType?> GetService(string servicetype);
        public Task<IEnumerable<ServiceType>> GetServiceTypes();
        public Task<bool> ModifyEngineerProfile(int engineerID, string image_url, ServiceType? selected_service, Car selected_car);
    }
    public class ServiceTypeRepository : IServiceType
    {
        private readonly AppDBContext context;
        public ServiceTypeRepository(AppDBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Engineer>> FindSpecialists(string carModel, string serviceType)
        {
            var specialists = await context.Engineers
                .Where(engineer => engineer.Speciality.TypeOfService == serviceType
               &&
                engineer.Car.Model == carModel)
                .ToListAsync();
            return specialists;
        }

        public async Task<ServiceType?> GetService(string servicetype)
        {
            return await context.ServiceTypes.Where(x => x.TypeOfService == servicetype).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ServiceType>> GetServiceTypes()
        {
            return await context.ServiceTypes.ToListAsync();
        }

        public async Task<bool> ModifyEngineerProfile(int engineerID,string image_url, ServiceType? selected_service, Car selected_car)
        {
            bool status;
            try
            {
                var engineer = await context.Engineers.FindAsync(engineerID);
                var speciality = await context.ServiceTypes.Where(x => x.TypeOfService == selected_service.TypeOfService).FirstOrDefaultAsync();
                var car = await context.Cars.Where(x => x.Model == selected_car.Model).FirstOrDefaultAsync();
                engineer.CarID = car.CarID;
                engineer.ServiceTypeID = speciality.ServiceTypeID;
                engineer.ImageURL = image_url;
                context.Engineers.Update(engineer);
                await context.SaveChangesAsync();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
    }
}
