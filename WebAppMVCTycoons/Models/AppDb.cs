using Microsoft.EntityFrameworkCore;

namespace WebAppMVCTycoons.Models
{
    public class AppDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HDC3-L-94S8B54;Initial Catalog=db_mvcTycoons;Integrated Security=true;TrustServerCertificate=true");

           // optionsBuilder.UseSqlServer("Data Source=;Initial Catalog=db_mvcTycoons;User id=sa;password=sa1234;TrustServerCertificate=true");
        }

        public DbSet<BooksModel> books { get; set; }
        public DbSet<OrdersModel> orders { get; set; }

          //  Table name  fields

        // Methods called add , update delete , tolist
    }
}
