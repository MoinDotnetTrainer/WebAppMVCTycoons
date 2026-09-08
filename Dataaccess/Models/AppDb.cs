using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Models
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }
        // Initiate a conn with db
        // db value will be noe passed dynamically
        public DbSet<Users> users { get; set; } // table
        public DbSet<Validate> validate { get; set; } // table
        public DbSet<Dept> dept { get; set; } // table
        public DbSet<Dept1> dept1 { get; set; } // table
        public DbSet<Emp> emp { get; set; } // table
        public DbSet<Emp1> emp1 { get; set; } // table


        public DbSet<Aadhar> Aadhar { get; set; } // table
        public DbSet<Pan> Pan { get; set; } // table
        public DbSet<Dept2> Dept2 { get; set; } // table
        public DbSet<Emp2> Emp2 { get; set; } // table

        public DbSet<Customer> Customer { get; set; } // table
        public DbSet<Orders> Orders { get; set; } // table
    }
}
