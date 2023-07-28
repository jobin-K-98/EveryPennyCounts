using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EveryPennyCounts.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        //CategoryId
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public String? Note { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
