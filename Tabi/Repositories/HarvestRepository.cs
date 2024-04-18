using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IHarvestRepository
    {
        Task<IEnumerable<Harvest>> GetHarvests();
        Task<Harvest> GetHarvest(int id);
        Task<Harvest> PostHarvest(Harvest harvest);
        Task<Harvest> PutHarvest(int id, Harvest harvest);
        Task<Harvest> DeleteHarvest(int id);

    }

    public class HarvestRepository : IHarvestRepository
    {
        private readonly TabiContext _context;

        public HarvestRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Harvest>> GetHarvests()
        {
            return await _context.Harvests.ToListAsync();
        }

        public async Task<Harvest> GetHarvest(int id)
        {
            return await _context.Harvests.FindAsync(id);
        }

        public async Task<Harvest> PostHarvest(Harvest harvest)
        {
            _context.Harvests.Add(harvest);
            await _context.SaveChangesAsync();
            return harvest;
        }

        public async Task<Harvest> PutHarvest(int id, Harvest harvest)
        {
            _context.Entry(harvest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return harvest;
        }

        public async Task<Harvest> DeleteHarvest(int id)
        {
            var harvest = await _context.Harvests.FindAsync(id);
            if (harvest == null)
            {
                return null;
            }

            _context.Harvests.Remove(harvest);
            await _context.SaveChangesAsync();
            return harvest;
        }


    }
}
