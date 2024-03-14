
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
        private readonly UserManager<AppUser> userManager;

        public EngineerRepository(AppDBContext context,UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<Engineer> GetEngineer(string id)
        {
            var result = await context.Engineers.Where(x => x.Id == id).Include(a=>a.AppUser)
                .Include(s=>s.Speciality)
                .SingleOrDefaultAsync();
            var app_user = await userManager.FindByIdAsync(id);
            result.AppUser = app_user;
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
