using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IPaymentTypeRepository
    {
        Task<IEnumerable<PaymentType>> GetPaymentTypes();
        Task<PaymentType> GetPaymentType(int id);
        Task<PaymentType> PostPaymentType(PaymentType paymentType);
        Task<PaymentType> PutPaymentType(int id, PaymentType paymentType);
        Task<PaymentType> DeletePaymentType(int id);

    }

    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly TabiContext _context;

        public PaymentTypeRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentType>> GetPaymentTypes()
        {
            return await _context.PaymentTypes.ToListAsync();
        }

        public async Task<PaymentType> GetPaymentType(int id)
        {
            return await _context.PaymentTypes.FindAsync(id);
        }

        public async Task<PaymentType> PostPaymentType(PaymentType paymentType)
        {
            _context.PaymentTypes.Add(paymentType);
            await _context.SaveChangesAsync();
            return paymentType;
        }

        public async Task<PaymentType> PutPaymentType(int id, PaymentType paymentType)
        {
            _context.Entry(paymentType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return paymentType;
        }

        public async Task<PaymentType> DeletePaymentType(int id)
        {
            var paymentType = await _context.PaymentTypes.FindAsync(id);
            if (paymentType == null)
            {
                return null;
            }

            _context.PaymentTypes.Remove(paymentType);
            await _context.SaveChangesAsync();
            return paymentType;
        }
    }
}
