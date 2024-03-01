namespace CommunicationSystem.Repository
{
    public interface IServiceHistory { }
    public class ServiceHistoryRepository:IServiceHistory
    {
        private readonly AppDBContext context;

        public ServiceHistoryRepository(AppDBContext context)
        {
            this.context = context;
        }
    }
}
