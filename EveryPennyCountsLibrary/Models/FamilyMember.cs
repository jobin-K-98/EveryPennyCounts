using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EveryPennyCounts.Models
{
    public class FamilyMember
    {
        [Key]
        public int FamilyMemberId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        //UserID Not implemented
        /*
        public int UserId { get; set; }
        public User User { get; set; }
        */
    }
}
