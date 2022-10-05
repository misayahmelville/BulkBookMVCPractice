using BulkBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        // This will create a table called Categories with the data members as columns created in the Category class
        public DbSet<Category> Categories { get; set; }
    }
}
