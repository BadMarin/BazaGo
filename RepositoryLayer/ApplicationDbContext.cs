using DomainLayer.EntityMapper;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{  
    public partial class ApplicationDbContext : DbContext
    {  
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {  
        }  
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.ApplyConfiguration(new CustomerMap());
  
            base.OnModelCreating(modelBuilder);
        }  
    }  
}  