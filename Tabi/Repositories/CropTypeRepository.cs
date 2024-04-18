using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface ICropTypeRepository
    {
        Task<IEnumerable<CropType>> GetCropTypes();
        Task<CropType> GetCropType(int id);
        Task<CropType> PostCropType(CropType cropType);
        Task<CropType> PutCropType(int id, CropType cropType);
        Task<CropType> DeleteCropType(int id);

    }

    public class CropTypeRepository : ICropTypeRepository
    {
        private readonly TabiContext _context;

        public CropTypeRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CropType>> GetCropTypes()
        {
            return await _context.CropTypes.ToListAsync();
        }

        public async Task<CropType> GetCropType(int id)
        {
            return await _context.CropTypes.FindAsync(id);
        }

        public async Task<CropType> PostCropType(CropType cropType)
        {
            _context.CropTypes.Add(cropType);
            await _context.SaveChangesAsync();
            return cropType;
        }

        public async Task<CropType> PutCropType(int id, CropType cropType)
        {
            _context.Entry(cropType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cropType;
        }

        public async Task<CropType> DeleteCropType(int id)
        {
            var cropType = await _context.CropTypes.FindAsync(id);
            if (cropType == null)
            {
                return null;
            }

            _context.CropTypes.Remove(cropType);
            await _context.SaveChangesAsync();
            return cropType;
        }
    }
}
