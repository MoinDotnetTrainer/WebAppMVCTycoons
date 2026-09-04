using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Appdb : DbContext
    {
        public Appdb(DbContextOptions<Appdb> options) : base(options) { }
        // Initiate a conn with db
        // db value will be noe passed dynamically

        public DbSet<Users> users { get; set; } // table
    }
}
