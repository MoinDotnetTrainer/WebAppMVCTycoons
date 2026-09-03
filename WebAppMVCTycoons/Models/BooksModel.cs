using System.ComponentModel.DataAnnotations;

namespace WebAppMVCTycoons.Models
{
    public class BooksModel
    {
        // one pk 
        [Key]
        public int BookID { get; set; } // pk and auto incre
        public string Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
}
