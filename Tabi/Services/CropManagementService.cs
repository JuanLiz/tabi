using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface ICropManagementService
    {
        Task<IEnumerable<CropManagement>> GetCropManagements();
        Task<CropManagement?> GetCropManagement(int id);
        Task<CropManagement> CreateCropManagement(
            int CropID,
            int CropManagementTypeID,
            DateOnly Date,
            string Description
            );
        Task<CropManagement> UpdateCropManagement(
            int CropManagementID,
            int? CropID,
            int? CropManagementTypeID,
            DateOnly? Date,
            string? Description
            );
        Task<CropManagement?> DeleteCropManagement(int id);

    }

    public class CropManagementService(ICropManagementRepository cropManagementRepository) : ICropManagementService
    {
        public async Task<IEnumerable<CropManagement>> GetCropManagements()
        {
            return await cropManagementRepository.GetCropManagements();
        }

        public async Task<CropManagement?> GetCropManagement(int id)
        {
            return await cropManagementRepository.GetCropManagement(id);
        }

        public async Task<CropManagement> CreateCropManagement(
            int CropID,
            int CropManagementTypeID,
            DateOnly Date,
            string Description
        )
        {
            CropManagement cropManagement = new()
            {
                CropID = CropID,
                CropManagementTypeID = CropManagementTypeID,
                Date = Date,
                Description = Description
            };
            return await cropManagementRepository.CreateCropManagement(cropManagement);
        }

        public async Task<CropManagement> UpdateCropManagement(
            int CropManagementID,
            int? CropID,
            int? CropManagementTypeID,
            DateOnly? Date,
            string? Description
        )
        {
            CropManagement? cropManagement = await cropManagementRepository.GetCropManagement(CropManagementID);
            if (cropManagement == null) throw new Exception("CropManagement not found");
            cropManagement.CropID = CropID ?? cropManagement.CropID;
            cropManagement.CropManagementTypeID = CropManagementTypeID ?? cropManagement.CropManagementTypeID;
            cropManagement.Date = Date ?? cropManagement.Date;
            cropManagement.Description = Description ?? cropManagement.Description;
            return await cropManagementRepository.UpdateCropManagement(cropManagement);

        }

        public async Task<CropManagement?> DeleteCropManagement(int id)
        {
            return await cropManagementRepository.DeleteCropManagement(id);
        }
    }
}
