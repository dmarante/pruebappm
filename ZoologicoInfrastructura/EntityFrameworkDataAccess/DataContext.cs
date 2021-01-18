using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zoo.Infrastructure.EntityFrameworkDataAccess.Entities;
using Zoo.Infrastructure.EntityFrameworkDataAccess.Repositories;

namespace Zoo.Infrastructure.EntityFrameworkDataAccess
{
    public partial class DataContext : IdentityDbContext<ApplicationUser>
    {
        private string ConectionString;

        public DataContext(string conectionSetring)
        {
            this.ConectionString = conectionSetring ;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConectionString);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Animal> Animal { get; set; }

    }
}
