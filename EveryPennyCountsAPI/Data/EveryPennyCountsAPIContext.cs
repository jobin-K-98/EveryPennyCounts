using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EveryPennyCounts.Models;

namespace EveryPennyCountsAPI.Data
{
    public class EveryPennyCountsAPIContext : DbContext
    {
        public EveryPennyCountsAPIContext (DbContextOptions<EveryPennyCountsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<FamilyMember> FamilyMembers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
