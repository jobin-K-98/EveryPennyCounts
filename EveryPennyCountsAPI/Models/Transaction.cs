using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EveryPennyCountsAPI.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        //CategoryId
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //CategoryId
        public int FamilyMemberId { get; set; }
        public FamilyMember FamilyMember { get; set; }

        public decimal Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public String? Note { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
