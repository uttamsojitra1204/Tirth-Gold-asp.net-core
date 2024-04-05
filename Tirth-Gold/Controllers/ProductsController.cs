using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tirth_Gold.Data;
using Tirth_Gold.Models;
using Tirth_Gold.Services;
//using Tirth_Gold.Services;
//using Tirth_Gold.Services;

namespace Tirth_Gold.Controllers
{
    public class ProductsController : Controller
    {
        private readonly dbcontext db;
        private readonly CartService _cartService;

        public ProductsController(dbcontext db, CartService cartService)
        {
            this.db = db;
            _cartService = cartService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await db.Products.ToListAsync();

            var cart = _cartService.GetCart();
            foreach (var item in cart.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.Product.Id);
                if (product != null)
                {
                    product.Quantity = item.Quantity;
                }
            }

            return View(products);
        }

        public IActionResult product()
        {
            IEnumerable<Product> pro = db.Products;
            return View(pro);
            //return db.Products != null ? View(await db.Products.ToListAsync()) :
            //Problem("Entity set 'ProductContext.Products' is null");
        }



    }
}
