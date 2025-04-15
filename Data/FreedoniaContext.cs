using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FreedoniaGovernment.Models;

namespace FreedoniaGovernment.Data
{
    public class FreedoniaContext : DbContext
    {
        public FreedoniaContext (DbContextOptions<FreedoniaContext> options)
            : base(options)
        {
        }

        public DbSet<FreedoniaGovernment.Models.LegislativeSession> LegislativeSession { get; set; } = default!;
    }
}
