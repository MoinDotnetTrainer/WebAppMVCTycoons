using System.ComponentModel.DataAnnotations;

namespace WEBAPISQLITE.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
