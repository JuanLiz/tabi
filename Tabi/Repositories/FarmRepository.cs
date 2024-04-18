using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IFarmRepository
    {
        Task<IEnumerable<Farm>> GetFarms();
        Task<Farm> GetFarm(int id);
        Task<Farm> PostFarm(Farm farm);
        Task<Farm> PutFarm(int id, Farm farm);
        Task<Farm> DeleteFarm(int id);

    }

    public class FarmRepository
    {
        private readonly TabiContext _context;

        public FarmRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Farm>> GetFarms()
        {
            return await _context.Farms.ToListAsync();
        }

        public async Task<Farm> GetFarm(int id)
        {
            return await _context.Farms.FindAsync(id);
        }

        public async Task<Farm> PostFarm(Farm farm)
        {
            _context.Farms.Add(farm);
            await _context.SaveChangesAsync();
            return farm;
        }

        public async Task<Farm> PutFarm(int id, Farm farm)
        {
            _context.Entry(farm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return farm;
        }

        public async Task<Farm> DeleteFarm(int id)
        {
            var farm = await _context.Farms.FindAsync(id);
            if (farm == null)
            {
                return null;
            }

            _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();
            return farm;
        }
    }
}
