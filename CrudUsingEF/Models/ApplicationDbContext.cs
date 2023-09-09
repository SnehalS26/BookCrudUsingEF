using Microsoft.EntityFrameworkCore;

namespace CrudUsingEF.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        //fetch the date from DB and store at application side
        //Dbset will translate LINQ quries in SQL and fire in DB
        public DbSet<Book> books { get; set; }
    }
}
