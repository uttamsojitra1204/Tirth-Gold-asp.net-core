using System.ComponentModel.DataAnnotations;

namespace Tirth_Gold.Models
{
    public class AddToCartViewModel
    {
        [Key]
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
