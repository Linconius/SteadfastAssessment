using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadFastAssessment.Server.Entities
{
    public class TimeSheetContext : DbContext
    {
        public TimeSheetContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TimeSheet> TimeSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeSheet>()
                .Property(ts => ts.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<TimeSheet>()
                .Property(ts => ts.Date)
                .HasColumnType("datetime2");
        }
    }
}
