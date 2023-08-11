using Microsoft.EntityFrameworkCore;

namespace EveryPennyCounts.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) 
        { }

        //Tables are defined in the Db Context
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }

    }
}
