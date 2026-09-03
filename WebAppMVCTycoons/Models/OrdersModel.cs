using System.ComponentModel.DataAnnotations;

namespace WebAppMVCTycoons.Models
{
    public class OrdersModel
    {
        [Key]
        public int OrderID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
