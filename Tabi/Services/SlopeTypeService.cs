using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface ISlopeTypeService
    {
        Task<IEnumerable<SlopeType>> GetSlopeTypes();
        Task<SlopeType?> GetSlopeType(int id);
        Task<SlopeType> CreateSlopeType(string Name);
        Task<SlopeType> UpdateSlopeType(int SlopeTypeID, string? Name);
        Task<SlopeType?> DeleteSlopeType(int id);

    }

    public class SlopeTypeService(ISlopeTypeRepository slopeTypeRepository) : ISlopeTypeService
    {
        public async Task<IEnumerable<SlopeType>> GetSlopeTypes()
        {
            return await slopeTypeRepository.GetSlopeTypes();
        }

        public async Task<SlopeType?> GetSlopeType(int id)
        {
            return await slopeTypeRepository.GetSlopeType(id);
        }

        public async Task<SlopeType> CreateSlopeType(string Name)
        {
            SlopeType slopeType = new()
            {
                Name = Name
            };
            return await slopeTypeRepository.CreateSlopeType(slopeType);
        }

        public async Task<SlopeType> UpdateSlopeType(int SlopeTypeID, string? Name)
        {
            SlopeType? slopeType = await slopeTypeRepository.GetSlopeType(SlopeTypeID);
            if (slopeType == null) throw new Exception("SlopeType not found");
            slopeType.Name = Name ?? slopeType.Name;
            return await slopeTypeRepository.UpdateSlopeType(slopeType);
        }

        public async Task<SlopeType?> DeleteSlopeType(int id)
        {
            return await slopeTypeRepository.DeleteSlopeType(id);
        }
    }
}
