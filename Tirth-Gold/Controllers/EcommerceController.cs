using Microsoft.AspNetCore.Mvc;
using Tirth_Gold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tirth_Gold.Data;

namespace Tirth_Gold.Controllers
{
    public class EcommerceController : Controller
    {
        private dbcontext s2;

        public EcommerceController(dbcontext dbcontext)
        {
            s2 = dbcontext;
        }

        public IActionResult Index() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel abc)
        {
            var user = s2.Registers.FirstOrDefault(u => u.Email == abc.Email && u.Email == abc.Email);
            if (user != null)
            {
                return RedirectToAction("HomePage");
            }
            else
            {
                ViewBag.Message = "Login Failed";
            }
            return View(abc);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(LoginModel abc)
        {
            s2.Registers.Add(abc);
            s2.SaveChanges();
            return RedirectToAction("Login");
        }

        
        public IActionResult HomePage()
        {
            IEnumerable<Product> products = s2.Products;
            return View(products);
        }
        public IActionResult MenCollection()
        {
            return View();
        }
        public IActionResult WomenCollection()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult ProductCart()
        {
            return View();
        }
        public IActionResult ProductDetails()
        {
            return View();
        }
        public IActionResult DeliveryAddress()
        {
            return View();
        }
        public IActionResult ConfirmOrder()
        {
            return View();
        }

        public IActionResult One()
        {
            return View();
        }

        public IActionResult Two()
        {
            return View();
        }
    }
}
