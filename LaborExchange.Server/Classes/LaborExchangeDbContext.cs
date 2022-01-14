using LaborExchange.Server.DBModel;
using Microsoft.EntityFrameworkCore;

namespace LaborExchange.Server
{
    public class LaborExchangeDbContext : DbContext
    {
        public LaborExchangeDbContext(DbContextOptions
            <LaborExchangeDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<EMPLOYEE> EMPLOYEES { get; set; }
        public virtual DbSet<EMPLOYER> EMPLOYERS { get; set; }
        public virtual DbSet<JOB_EMPLOYMENT> JOB_EMPLOYMENTS { get; set; }
        public virtual DbSet<JOB_OFFER> JOB_OFFERS { get; set; }
        public virtual DbSet<JOB_VACANCY> JOB_VACANCIES { get; set; }
        public virtual DbSet<LEGAL_ENTITY> LEGAL_ENTITIES { get; set; }
        public virtual DbSet<PASSPORT> PASSPORT { get; set; }
        public virtual DbSet<SOLE_PROPRITEOR> SOLE_PROPRITEORS { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
    }
}