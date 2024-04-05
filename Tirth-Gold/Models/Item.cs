using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Tirth_Gold.Models
{

    public class Item
    {

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Cost
        {
            get { return (Product.Price) * Quantity; }
        }
    }
}
