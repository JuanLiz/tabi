using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IHarvestRepository
    {
        Task<IEnumerable<Harvest>> GetHarvests();
        Task<Harvest?> GetHarvest(int id);
        Task<Harvest> CreateHarvest(Harvest harvest);
        Task<Harvest> UpdateHarvest(Harvest harvest);
        Task<Harvest?> DeleteHarvest(int id);

    }

    public class HarvestRepository(TabiContext db) : IHarvestRepository
    {
        public async Task<IEnumerable<Harvest>> GetHarvests()
        {
            return await db.Harvests.ToListAsync();
        }

        public async Task<Harvest?> GetHarvest(int id)
        {
            return await db.Harvests.FindAsync(id);
        }

        public async Task<Harvest> CreateHarvest(Harvest harvest)
        {
            db.Harvests.Add(harvest);
            await db.SaveChangesAsync();
            return harvest;
        }

        public async Task<Harvest> UpdateHarvest(Harvest harvest)
        {
            db.Entry(harvest).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return harvest;
        }

        public async Task<Harvest?> DeleteHarvest(int id)
        {
            Harvest? harvest = await db.Harvests.FindAsync(id);
            if (harvest == null) return harvest;
            harvest.IsActive = false;
            db.Entry(harvest).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return harvest;
        }


    }
}
