using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface ICropStatusRepository
    {
        Task<IEnumerable<CropStatus>> GetCropStatuses();
        Task<CropStatus> GetCropStatus(int id);
        Task<CropStatus> PostCropStatus(CropStatus cropStatus);
        Task<CropStatus> PutCropStatus(int id, CropStatus cropStatus);
        Task<CropStatus> DeleteCropStatus(int id);

    }

    public class CropStatusRepository : ICropStatusRepository
    {
        private readonly TabiContext _context;

        public CropStatusRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CropStatus>> GetCropStatuses()
        {
            return await _context.CropStatuses.ToListAsync();
        }

        public async Task<CropStatus> GetCropStatus(int id)
        {
            return await _context.CropStatuses.FindAsync(id);
        }

        public async Task<CropStatus> PostCropStatus(CropStatus cropStatus)
        {
            _context.CropStatuses.Add(cropStatus);
            await _context.SaveChangesAsync();
            return cropStatus;
        }

        public async Task<CropStatus> PutCropStatus(int id, CropStatus cropStatus)
        {
            _context.Entry(cropStatus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cropStatus;
        }

        public async Task<CropStatus> DeleteCropStatus(int id)
        {
            var cropStatus = await _context.CropStatuses.FindAsync(id);
            if (cropStatus == null)
            {
                return null;
            }

            _context.CropStatuses.Remove(cropStatus);
            await _context.SaveChangesAsync();
            return cropStatus;
        }
    }
}
