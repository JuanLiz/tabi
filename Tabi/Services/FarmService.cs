using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface IFarmService
    {
        Task<IEnumerable<Farm>> GetFarms();
        Task<Farm?> GetFarm(int id);
        Task<Farm> CreateFarm(
            int UserID,
            string Name,
            string? Address,
            float Hectares);
        Task<Farm> UpdateFarm(
            int FarmID,
            int? UserID,
            string? Name,
            string? Address,
            float? Hectares);
        Task<Farm?> DeleteFarm(int id);
    }

    public class FarmService(IFarmRepository farmRepository) : IFarmService
    {
        public async Task<IEnumerable<Farm>> GetFarms()
        {
            return await farmRepository.GetFarms();
        }

        public async Task<Farm?> GetFarm(int id)
        {
            return await farmRepository.GetFarm(id);
        }

        public async Task<Farm> CreateFarm(
            int UserID,
            string Name,
            string? Address,
            float Hectares)
        {
            Farm farm = new()
            {
                UserID = UserID,
                Name = Name,
                Address = Address,
                Hectares = Hectares
            };
            return await farmRepository.CreateFarm(farm);
        }

        public async Task<Farm> UpdateFarm(
            int FarmID,
            int? UserID,
            string? Name,
            string? Address,
            float? Hectares)
        {
            Farm? farm = await farmRepository.GetFarm(FarmID);
            if (farm == null) throw new Exception("Farm not found");
            farm.UserID = UserID ?? farm.UserID;
            farm.Name = Name ?? farm.Name;
            farm.Address = Address ?? farm.Address;
            farm.Hectares = Hectares ?? farm.Hectares;
            return await farmRepository.UpdateFarm(farm);
        }

        public async Task<Farm?> DeleteFarm(int id)
        {
            return await farmRepository.DeleteFarm(id);
        }
    }
}
