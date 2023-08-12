using System.ComponentModel.DataAnnotations;

namespace EveryPennyCountsAPI.Models
{
    public class FamilyMember
    {
        [Key]
        public int FamilyMemberId { get; set; }
        public string Name { get; set; }
    }
}
