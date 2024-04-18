using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface IHarvestStateService
    {
        Task<IEnumerable<HarvestState>> GetHarvestStates();
        Task<HarvestState?> GetHarvestState(int id);
        Task<HarvestState> CreateHarvestState(string Name);
        Task<HarvestState> UpdateHarvestState(int HarvestStateID, string? Name);
        Task<HarvestState?> DeleteHarvestState(int id);
    }

    public class HarvestStateService(IHarvestStateRepository harvestStateRepository) : IHarvestStateService
    {
        public async Task<IEnumerable<HarvestState>> GetHarvestStates()
        {
            return await harvestStateRepository.GetHarvestStates();
        }

        public async Task<HarvestState?> GetHarvestState(int id)
        {
            return await harvestStateRepository.GetHarvestState(id);
        }

        public async Task<HarvestState> CreateHarvestState(string Name)
        {
            HarvestState harvestState = new()
            {
                Name = Name
            };
            return await harvestStateRepository.CreateHarvestState(harvestState);
        }

        public async Task<HarvestState> UpdateHarvestState(int HarvestStateID, string? Name)
        {
            HarvestState? harvestState = await harvestStateRepository.GetHarvestState(HarvestStateID);
            if (harvestState == null) throw new Exception("HarvestState not found");
            harvestState.Name = Name ?? harvestState.Name;
            return await harvestStateRepository.UpdateHarvestState(harvestState);
        }

        public async Task<HarvestState?> DeleteHarvestState(int id)
        {
            return await harvestStateRepository.DeleteHarvestState(id);
        }
    }
}
