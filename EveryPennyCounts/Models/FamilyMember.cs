using System.ComponentModel.DataAnnotations;

namespace EveryPennyCounts.Models
{
    public class FamilyMember
    {
        [Key]
        public int FamilyMemberId { get; set; }
        public string Name { get; set; }
    }
}
