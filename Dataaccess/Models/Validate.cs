using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Models
{
    [Table("TblValidate")]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Mobile))]
    // table index ,search  btree strcut
    public class Validate
    {
        [Key]
        //   [DatabaseGenerated(DatabaseGeneratedOption.None)]  // manually
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters and numbers.")]

        // No number allowed
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        // state re value Value ==> name is null 

        [Required(ErrorMessage = "EMail Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters and contain uppercase, lowercase, number, and special character."
        )]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; } // User confirmation

        // No Alphabets

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]
        public string Mobile { get; set; }

        [Range(18, 50)]
        public int? Age { get; set; }
        public double? Salary { get; set; }
        public string? Gender { get; set; }

        [StringLength(50)]
        public string? Address { get; set; }


        [NotMapped]
        public string Role { get; set; }
    }
}
