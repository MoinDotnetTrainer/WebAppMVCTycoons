using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Models
{
    [Table("UsersTbl")]
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        //[DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime? Dob { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }  // dropdown 
    }

    public class Login
    {

        public string Email { get; set; }
        public string Password { get; set; }

    }
}
