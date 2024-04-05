using Tirth_Gold.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tirth_Gold.Data
{
    public class DbInitializer
    {
        public static void Initialize(dbcontext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return;
            }
            var products = new Product[]
            {
                new Product()
                  {
                      Id = "1",
                     Name = "Ring",
                      Photo = "one.jpg",
                      Price = 2.80
                  },

                new Product()
                {
                    Id="2",
                    Name = " Kada",
                    Photo = "two.jpg",
                    Price = 3.80
                },
                new Product()
                {
                    Id="3",
                    Name = "Chain",
                    Photo = "three.jpg",
                    Price = 3.80
                },
                  new Product()
                  {
                      Id="4",
                      Name = "Bracelate",
                      Photo = "four.jpg",
                      Price = 3.60
                  },
                new Product()
                {
                    Id="5",
                    Name = "Ring",
                    Photo = "five.jpg",
                    Price = 6.80
                },
                new Product()
                {
                    Id="6",
                    Name = "Tanmaniya",
                    Photo = "six.jpg",
                    Price = 1.68
                },
                  new Product()
                  {
                      Id="7",
                      Name = "Earring",
                      Photo = "seven.jpg",
                      Price = 3.80
                  },
                  new Product()
                  {
                      Id="8",
                      Name = "Silver Chain",
                      Photo = "eight.jpg",
                      Price = 3.45
                  },
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
