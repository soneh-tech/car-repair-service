namespace CommunicationSystem.Repository
{
    public interface ICar
    {
        public Task<IEnumerable<Car>> GetAllCars();
        Task<Car?> GetCar(string carmodel);
    }
    public class CarRepository : ICar
    {
        private readonly AppDBContext context;

        public CarRepository(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await context.Cars.ToListAsync();
        }

        public async Task<Car?> GetCar(string carmodel)
        {
            return await context.Cars.Where(x => x.Model == carmodel).FirstOrDefaultAsync();
        }

    }
}
