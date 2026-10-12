using CrudOperationWithRepo.Models;
using Microsoft.EntityFrameworkCore;


namespace CrudOperationWithRepo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
