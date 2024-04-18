using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IHarvestStateRepository
    {
        Task<IEnumerable<HarvestState>> GetHarvestStates();
        Task<HarvestState?> GetHarvestState(int id);
        Task<HarvestState> CreateHarvestState(HarvestState harvestState);
        Task<HarvestState> UpdateHarvestState(HarvestState harvestState);
        Task<HarvestState?> DeleteHarvestState(int id);

    }

    public class HarvestStateRepository(TabiContext db) : IHarvestStateRepository
    {
        public async Task<IEnumerable<HarvestState>> GetHarvestStates()
        {
            return await db.HarvestStates.ToListAsync();
        }

        public async Task<HarvestState?> GetHarvestState(int id)
        {
            return await db.HarvestStates.FindAsync(id);
        }

        public async Task<HarvestState> CreateHarvestState(HarvestState harvestState)
        {
            db.HarvestStates.Add(harvestState);
            await db.SaveChangesAsync();
            return harvestState;
        }

        public async Task<HarvestState> UpdateHarvestState(HarvestState harvestState)
        {
            db.Entry(harvestState).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return harvestState;
        }

        public async Task<HarvestState?> DeleteHarvestState(int id)
        {
            HarvestState? harvestState = await db.HarvestStates.FindAsync(id);
            if (harvestState == null) return harvestState;
            harvestState.IsActive = false;
            db.Entry(harvestState).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return harvestState;
        }
    }
}
