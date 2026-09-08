using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Models
{

    public class Dept
    {
        [Key]
        public int DeptID { get; set; }

        [Required]
        public string DeptName { get; set; }

        public Emp Emp { get; set; }
    }
    public class Emp
    {
        [Key]
        public int EID { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int DeptID { get; set; } // fk 

        // navigation prop
        public Dept Dept { get; set; }
    }
    public class Dept1
    {
        [Key]
        public int DeptID { get; set; }

        [Required]
        public string DeptName { get; set; }
    }
    public class Emp1
    {
        [Key]
        public int EID { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int DeptID { get; set; } // fk 

    }


    public class Aadhar
    {
        [Key]
        public int AadharID { get; set; }
        public string userName { get; set; }
    }
    public class Pan
    {
        [Key]
        public int PanNO { get; set; }
        public string PanuserName { get; set; }

        //fk

        public int AAdharRefID { get; set; }  // fk

        [ForeignKey("AAdharRefID")]
        public Aadhar Aadhar { get; set; }
    }

    public class Dept2
    {
        [Key]
        public int DeptID { get; set; }

        [Required]
        public string DeptName { get; set; }
    }
    public class Emp2
    {
        [Key]
        public int EID { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int xyz { get; set; } // fk not

        // navigation prop
        public Dept2 Dept { get; set; }
    }

    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
    }


    [Table("MyOrders")]
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public string OrderName { get; set; }

        public Customer Customer { get; set; } // navigtion
    }

    // one to one 
    // one to many

    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public ICollection<State> state { get; set; }


    }

    public class State
    {
        [Key]
        public int StateID { get; set; }
        public string StateName { get; set; }
        public Country Country { get; set; }
    }
}
