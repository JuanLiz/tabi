using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IHarvestPaymentRepository
    {
        Task<IEnumerable<HarvestPayment>> GetHarvestPayments();
        Task<HarvestPayment> GetHarvestPayment(int id);
        Task<HarvestPayment> PostHarvestPayment(HarvestPayment harvestPayment);
        Task<HarvestPayment> PutHarvestPayment(int id, HarvestPayment harvestPayment);
        Task<HarvestPayment> DeleteHarvestPayment(int id);

    }

    public class HarvestPaymentRepository: IHarvestRepository
    {
        private readonly TabiContext _context;

        public HarvestPaymentRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HarvestPayment>> GetHarvestPayments()
        {
            return await _context.HarvestPayments.ToListAsync();
        }

        public async Task<HarvestPayment> GetHarvestPayment(int id)
        {
            return await _context.HarvestPayments.FindAsync(id);
        }

        public async Task<HarvestPayment> PostHarvestPayment(HarvestPayment harvestPayment)
        {
            _context.HarvestPayments.Add(harvestPayment);
            await _context.SaveChangesAsync();
            return harvestPayment;
        }

        public async Task<HarvestPayment> PutHarvestPayment(int id, HarvestPayment harvestPayment)
        {
            _context.Entry(harvestPayment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return harvestPayment;
        }

        public async Task<HarvestPayment> DeleteHarvestPayment(int id)
        {
            var harvestPayment = await _context.HarvestPayments.FindAsync(id);
            if (harvestPayment == null)
            {
                return null;
            }

            _context.HarvestPayments.Remove(harvestPayment);
            await _context.SaveChangesAsync();
            return harvestPayment;
        }

    }
}
