using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IPaymentTypeRepository
    {
        Task<IEnumerable<PaymentType>> GetPaymentTypes();
        Task<PaymentType?> GetPaymentType(int id);
        Task<PaymentType> CreatePaymentType(PaymentType paymentType);
        Task<PaymentType> UpdatePaymentType(PaymentType paymentType);
        Task<PaymentType?> DeletePaymentType(int id);

    }

    public class PaymentTypeRepository(TabiContext db) : IPaymentTypeRepository
    {
        public async Task<IEnumerable<PaymentType>> GetPaymentTypes()
        {
            return await db.PaymentTypes.ToListAsync();
        }

        public async Task<PaymentType?> GetPaymentType(int id)
        {
            return await db.PaymentTypes.FindAsync(id);
        }

        public async Task<PaymentType> CreatePaymentType(PaymentType paymentType)
        {
            db.PaymentTypes.Add(paymentType);
            await db.SaveChangesAsync();
            return paymentType;
        }

        public async Task<PaymentType> UpdatePaymentType(PaymentType paymentType)
        {
            db.Entry(paymentType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return paymentType;
        }

        public async Task<PaymentType?> DeletePaymentType(int id)
        {
            PaymentType? paymentType = await db.PaymentTypes.FindAsync(id);
            if (paymentType == null) return paymentType;
            paymentType.IsActive = false;
            db.Entry(paymentType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return paymentType;
        }
    }
}
