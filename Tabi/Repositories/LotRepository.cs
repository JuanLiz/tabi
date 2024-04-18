using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{
    public interface ILotRepository
    {
        Task<IEnumerable<Lot>> GetLots();
        Task<Lot?> GetLot(int id);
        Task<Lot> CreateLot(Lot lot);
        Task<Lot> UpdateLot(Lot lot);
        Task<Lot?> DeleteLot(int id);
    }
    public class LotRepository(TabiContext db) : ILotRepository
    {
        public async Task<IEnumerable<Lot>> GetLots()
        {
            return await db.Lots.ToListAsync();
        }

        public async Task<Lot?> GetLot(int id)
        {
            return await db.Lots.FindAsync(id);
        }

        public async Task<Lot> CreateLot(Lot lot)
        {
            db.Lots.Add(lot);
            await db.SaveChangesAsync();
            return lot;
        }

        public async Task<Lot> UpdateLot(Lot lot)
        {
            db.Entry(lot).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return lot;
        }

        public async Task<Lot?> DeleteLot(int id)
        {
            Lot? lot = await db.Lots.FindAsync(id);
            if (lot == null) return lot;
            lot.IsActive = false;
            db.Entry(lot).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return lot;
        }
    }
}
