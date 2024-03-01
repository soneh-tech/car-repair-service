
using CommunicationSystem.Areas.Auth.Models;

namespace CommunicationSystem.Repository
{
    public interface IEngineer
    {
        Task<Engineer> GetEngineer(string id);
        Task<Engineer> ModifyEngineer(Engineer engineer_info);
    }
    public class EngineerRepository : IEngineer
    {
        private readonly AppDBContext context;

        public EngineerRepository(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<Engineer> GetEngineer(string id)
        {
            var result = await context.Engineers.Where(x => x.Id == id).Include(a=>a.Appuser).SingleOrDefaultAsync();
            return result;
        }

        public async Task<Engineer> ModifyEngineer(Engineer engineer_info)
        {
            context.Engineers.UpdateRange(engineer_info);
            await context.SaveChangesAsync();
            return engineer_info;

        }
    }
}
