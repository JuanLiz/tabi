using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabi.Model
{
    public class HarvestPayment
    {
        [Key]
        public int HarvestPaymentID { get; set; }
        
        
        [ForeignKey(nameof(Harvest))]
        public int HarvestID { get; set; }
       
        [ForeignKey(nameof(User))]
        public int? UserID { get; set; }
        
        
        public float HarvestedAmount { get; set; }
        
        
        [ForeignKey(nameof(PaymentType))]
        public int PaymentTypeID { get; set; }
        
        
        public float PaymentAmount { get; set; }


        public Harvest Harvest { get; set; }
        public User User { get; set; }
        public PaymentType PaymentType { get; set; }

    }
}
