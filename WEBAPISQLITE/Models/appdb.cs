using Microsoft.EntityFrameworkCore;

namespace WEBAPISQLITE.Models
{
    public class appdb : DbContext
    {
        public appdb(DbContextOptions<appdb> options):base(options)
        {

        }

        public DbSet<Users> users { get; set; }
    }
}
