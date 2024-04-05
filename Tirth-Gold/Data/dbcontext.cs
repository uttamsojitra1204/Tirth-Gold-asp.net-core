using Tirth_Gold.Models;
using Microsoft.EntityFrameworkCore;

namespace Tirth_Gold.Data
{
    public class dbcontext:DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> s):base(s) 
        {
            
        }
        public DbSet<LoginModel> Registers { get; set; }
        public DbSet<Product> Products { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
