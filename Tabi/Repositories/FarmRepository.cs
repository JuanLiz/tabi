using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IFarmRepository
    {
        Task<IEnumerable<Farm>> GetFarms();
        Task<Farm?> GetFarm(int id);
        Task<Farm> CreateFarm(Farm farm);
        Task<Farm> UpdateFarm(Farm farm);
        Task<Farm?> DeleteFarm(int id);

    }

    public class FarmRepository(TabiContext db)
    {
        public async Task<IEnumerable<Farm>> GetFarms()
        {
            return await db.Farms.ToListAsync();
        }

        public async Task<Farm?> GetFarm(int id)
        {
            return await db.Farms.FindAsync(id);
        }

        public async Task<Farm> CreateFarm(Farm farm)
        {
            db.Farms.Add(farm);
            await db.SaveChangesAsync();
            return farm;
        }

        public async Task<Farm> UpdateFarm(Farm farm)
        {
            db.Entry(farm).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return farm;
        }

        public async Task<Farm?> DeleteFarm(int id)
        {
            Farm? farm = await db.Farms.FindAsync(id);
            if (farm == null) return farm;
            farm.IsActive = false;
            db.Entry(farm).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return farm;
        }
    }
}
