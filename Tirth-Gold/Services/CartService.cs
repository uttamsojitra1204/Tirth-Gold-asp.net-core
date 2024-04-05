﻿using Tirth_Gold.Data;
using Tirth_Gold.Models;
using Newtonsoft.Json;

namespace Tirth_Gold.Services
{
    public class CartService : ICartService
    {
        private readonly dbcontext  db;
        private readonly IHttpContextAccessor? _httpContextAccessor;
        private Cart _cart = new Cart();
        public CartService(dbcontext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            _httpContextAccessor = httpContextAccessor;
            _cart = GetCartFromSession();

        }
        public Cart GetCart()
        {
            return _cart;
        }
        public void AddItem(Product product, int quantity)
        {
            var item = _cart.Items.FirstOrDefault(i => i.Product.Id == product.Id);

            if (item == null)
            {
                item = new Item { Product = product, Quantity = quantity };
                _cart.Items.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
            UpdateCartInSession();
        }

        private void UpdateCartInSession()
        {
            _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(_cart));
        }
        public void AddToCart(string productId, int quantity)
        {
            var product = db.Products.Find(productId);

            if (product != null)
            {
                var newItem = new Item { Product = product, Quantity = quantity };
                _cart.Items.Add(newItem);
            }
        }
        public void UpdateCart(Cart cart)
        {
            _cart = cart;
            SaveCartToSession(_cart);
        }

        private void SaveCartToSession(Cart cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            _httpContextAccessor.HttpContext.Session.SetString("Cart", cartJson);
        }

        private Cart GetCartFromSession()
        {
            var cartJson = _httpContextAccessor.HttpContext.Session.GetString("Cart");

            if (!string.IsNullOrEmpty(cartJson))
            {
                return JsonConvert.DeserializeObject<Cart>(cartJson);
            }

            var cart = new Cart();
            _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            return cart;
        }

        public void RemoveItem(string productId)
        {
            var cart = GetCart();
            var itemToRemove = cart.Items.FirstOrDefault(item => item.Product.Id == productId);

            if (itemToRemove != null)
            {
                cart.Items.Remove(itemToRemove);
                UpdateCartInSession();

            }
        }
        public void ClearCart()
        {
            _httpContextAccessor.HttpContext.Session.Remove("Cart");
        }


    }
}