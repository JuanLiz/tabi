using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface ICropManagementTypeService
    {
        Task<IEnumerable<CropManagementType>> GetCropManagementTypes();
        Task<CropManagementType?> GetCropManagementType(int id);
        Task<CropManagementType> CreateCropManagementType(string Name);
        Task<CropManagementType> UpdateCropManagementType(int CropManagementTypeID, string? Name);
        Task<CropManagementType?> DeleteCropManagementType(int id);

    }

    public class CropManagementTypeService(ICropManagementTypeRepository cropManagementTypeRepository)
        : ICropManagementTypeService
    {
        public async Task<IEnumerable<CropManagementType>> GetCropManagementTypes()
        {
            return await cropManagementTypeRepository.GetCropManagementTypes();
        }

        public async Task<CropManagementType?> GetCropManagementType(int id)
        {
            return await cropManagementTypeRepository.GetCropManagementType(id);
        }

        public async Task<CropManagementType> CreateCropManagementType(string Name)
        {
            CropManagementType cropManagementType = new()
            {
                Name = Name
            };
            return await cropManagementTypeRepository.CreateCropManagementType(cropManagementType);
        }

        public async Task<CropManagementType> UpdateCropManagementType(int CropManagementTypeID, string? Name)
        {
            CropManagementType? cropManagementType = await cropManagementTypeRepository.GetCropManagementType(CropManagementTypeID);
            if (cropManagementType == null) throw new Exception("CropManagementType not found");
            cropManagementType.Name = Name ?? cropManagementType.Name;
            return await cropManagementTypeRepository.UpdateCropManagementType(cropManagementType);
        }

        public async Task<CropManagementType?> DeleteCropManagementType(int id)
        {
            return await cropManagementTypeRepository.DeleteCropManagementType(id);
        }
    }
}
