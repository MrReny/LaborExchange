using FirebirdSql.Data.FirebirdClient;
using LaborExchange.Commons;
using Microsoft.EntityFrameworkCore;

namespace LaborExchange.Server
{
    public class LaborExchangeDbContext : DbContext
    {

        public LaborExchangeDbContext(DbContextOptions
            <LaborExchangeDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne(e=> e.Passport);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EMPLOYEE> Employees { get; set; }

        public DbSet<EMPLOYER> Employers { get; set; }

        public DbSet<JOB> Jobs { get; set; }

        public DbSet<JOBOFFER> JobOffers { get; set; }
    }
}