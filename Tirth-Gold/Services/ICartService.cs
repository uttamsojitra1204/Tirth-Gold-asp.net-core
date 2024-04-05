using Tirth_Gold.Models;

namespace Tirth_Gold.Services
{
    public interface ICartService
    {
        void AddItem(Product product, int quantity);
        void RemoveItem(string productId);
        void ClearCart();
        Cart GetCart();
    }
}
