using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{
    public interface ILotRepository
    {
        Task<IEnumerable<Lot>> GetLots();
        Task<Lot> GetLot(int id);
        Task<Lot> PostLot(Lot lot);
        Task<Lot> PutLot(int id, Lot lot);
        Task<Lot> DeleteLot(int id);
    }
    public class LotRepository : ILotRepository
    {
        private readonly TabiContext _context;

        public LotRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lot>> GetLots()
        {
            return await _context.Lots.ToListAsync();
        }

        public async Task<Lot> GetLot(int id)
        {
            return await _context.Lots.FindAsync(id);
        }

        public async Task<Lot> PostLot(Lot lot)
        {
            _context.Lots.Add(lot);
            await _context.SaveChangesAsync();
            return lot;
        }

        public async Task<Lot> PutLot(int id, Lot lot)
        {
            _context.Entry(lot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return lot;
        }

        public async Task<Lot> DeleteLot(int id)
        {
            var lot = await _context.Lots.FindAsync(id);
            if (lot == null)
            {
                return null;
            }

            _context.Lots.Remove(lot);
            await _context.SaveChangesAsync();
            return lot;
        }
    }
}
