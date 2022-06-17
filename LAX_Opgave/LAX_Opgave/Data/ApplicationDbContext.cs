using LAX_Opgave.Models;
using Microsoft.EntityFrameworkCore;

namespace LAX_Opgave.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
    }
}
