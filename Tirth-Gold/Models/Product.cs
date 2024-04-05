using System.ComponentModel.DataAnnotations;

namespace Tirth_Gold.Models
{
    public class Product
    {
        [Key]
        public required string Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public required string Photo { get; set; }
        public int Quantity { get; set; }
    }
}
