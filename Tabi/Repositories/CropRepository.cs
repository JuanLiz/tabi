using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface ICropRepository
    {
        Task<IEnumerable<Crop>> GetCrops();
        Task<Crop> GetCrop(int id);
        Task<Crop> PostCrop(Crop crop);
        Task<Crop> PutCrop(int id, Crop crop);
        Task<Crop> DeleteCrop(int id);

    }

    public class CropRepository : ICropRepository
    {
        private readonly TabiContext _context;

        public CropRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Crop>> GetCrops()
        {
            return await _context.Crops.ToListAsync();
        }

        public async Task<Crop> GetCrop(int id)
        {
            return await _context.Crops.FindAsync(id);
        }

        // TODO Class creation
        public async Task<Crop> PostCrop(Crop crop)
        {
            _context.Crops.Add(crop);
            await _context.SaveChangesAsync();
            return crop;
        }

        public async Task<Crop> PutCrop(int id, Crop crop)
        {
            _context.Entry(crop).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return crop;
        }

        public async Task<Crop> DeleteCrop(int id)
        {
            var crop = await _context.Crops.FindAsync(id);
            if (crop == null)
            {
                return null;
            }

            _context.Crops.Remove(crop);
            await _context.SaveChangesAsync();
            return crop;
        }
    }
}
