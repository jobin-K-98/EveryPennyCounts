using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EveryPennyCountsAPI.Models;

namespace EveryPennyCountsAPI.Data
{
    public class EveryPennyCountsAPIContext : DbContext
    {
        public EveryPennyCountsAPIContext (DbContextOptions<EveryPennyCountsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<EveryPennyCountsAPI.Models.Category> Category { get; set; } = default!;

        public DbSet<EveryPennyCountsAPI.Models.FamilyMember>? FamilyMember { get; set; }

        public DbSet<EveryPennyCountsAPI.Models.Transaction>? Transaction { get; set; }
    }
}
