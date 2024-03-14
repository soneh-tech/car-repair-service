
using CommunicationSystem.Areas.Auth.Models;
using NuGet.Configuration;

namespace CommunicationSystem.Repository
{
    public interface IOwner
    {
        Task<Owner> ModifyOwner(Owner owner_info);
        Task<Owner> GetOwner(string id);

    }
    public class OwnerRepository:IOwner
    {
        private readonly AppDBContext context;

        public OwnerRepository(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<Owner> ModifyOwner(Owner owner_info)
        {
            context.Owners.UpdateRange(owner_info);
            await context.SaveChangesAsync();
            return owner_info;
        }
        public async Task<Owner> GetOwner(string id)
        {
            var result = await context.Owners.Where(x => x.Id == id).Include(a=>a.AppUser).SingleOrDefaultAsync();
            return result;
        }
    }
}
