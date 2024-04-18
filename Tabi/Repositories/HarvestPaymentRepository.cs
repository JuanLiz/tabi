using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IHarvestPaymentRepository
    {
        Task<IEnumerable<HarvestPayment>> GetHarvestPayments();
        Task<HarvestPayment?> GetHarvestPayment(int id);
        Task<HarvestPayment> CreateHarvestPayment(HarvestPayment harvestPayment);
        Task<HarvestPayment> UpdateHarvestPayment(HarvestPayment harvestPayment);
        Task<HarvestPayment?> DeleteHarvestPayment(int id);

    }

    public class HarvestPaymentRepository(TabiContext db) : IHarvestPaymentRepository
    {
        public async Task<IEnumerable<HarvestPayment>> GetHarvestPayments()
        {
            return await db.HarvestPayments.ToListAsync();
        }

        public async Task<HarvestPayment?> GetHarvestPayment(int id)
        {
            return await db.HarvestPayments.FindAsync(id);
        }

        public async Task<HarvestPayment> CreateHarvestPayment(HarvestPayment harvestPayment)
        {
            db.HarvestPayments.Add(harvestPayment);
            await db.SaveChangesAsync();
            return harvestPayment;
        }

        public async Task<HarvestPayment> UpdateHarvestPayment(HarvestPayment harvestPayment)
        {
            db.Entry(harvestPayment).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return harvestPayment;
        }

        public async Task<HarvestPayment?> DeleteHarvestPayment(int id)
        {
            HarvestPayment? harvestPayment = await db.HarvestPayments.FindAsync(id);
            if (harvestPayment == null) return harvestPayment;
            harvestPayment.IsActive = false;
            db.Entry(harvestPayment).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return harvestPayment;
        }

    }
}
