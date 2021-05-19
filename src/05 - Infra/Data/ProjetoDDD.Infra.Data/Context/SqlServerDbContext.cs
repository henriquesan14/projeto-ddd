using Microsoft.EntityFrameworkCore;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Infra.Data.Mapping;

namespace ProjetoDDD.Infra.Data.Context
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }


    }
}
