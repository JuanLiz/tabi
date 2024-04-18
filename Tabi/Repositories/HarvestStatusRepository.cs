using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IHarvestStatusRepository
    {
        Task<IEnumerable<HarvestStatus>> GetHarvestStatuses();
        Task<HarvestStatus> GetHarvestStatus(int id);
        Task<HarvestStatus> PostHarvestStatus(HarvestStatus harvestStatus);
        Task<HarvestStatus> PutHarvestStatus(int id, HarvestStatus harvestStatus);
        Task<HarvestStatus> DeleteHarvestStatus(int id);

    }

    public class HarvestStatusRepository : IHarvestStatusRepository
    {
        private readonly TabiContext _context;

        public HarvestStatusRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HarvestStatus>> GetHarvestStatuses()
        {
            return await _context.HarvestStatuses.ToListAsync();
        }

        public async Task<HarvestStatus> GetHarvestStatus(int id)
        {
            return await _context.HarvestStatuses.FindAsync(id);
        }

        public async Task<HarvestStatus> PostHarvestStatus(HarvestStatus harvestStatus)
        {
            _context.HarvestStatuses.Add(harvestStatus);
            await _context.SaveChangesAsync();
            return harvestStatus;
        }

        public async Task<HarvestStatus> PutHarvestStatus(int id, HarvestStatus harvestStatus)
        {
            _context.Entry(harvestStatus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return harvestStatus;
        }

        public async Task<HarvestStatus> DeleteHarvestStatus(int id)
        {
            var harvestStatus = await _context.HarvestStatuses.FindAsync(id);
            if (harvestStatus == null)
            {
                return null;
            }

            _context.HarvestStatuses.Remove(harvestStatus);
            await _context.SaveChangesAsync();
            return harvestStatus;
        }
    }
}
