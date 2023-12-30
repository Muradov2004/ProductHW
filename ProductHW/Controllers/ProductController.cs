using Microsoft.AspNetCore.Mvc;
using ProductHW.Models;
using System.Reflection;

namespace ProductHW.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new()
        {
            new Product { Name = "Product1", Description = "Product1 description", Price = 10 },
            new Product { Name = "Product2", Description = "Product2 description", Price = 20 },
            new Product { Name = "Product3", Description = "Product3 description", Price = 30 },
            new Product { Name = "Product4", Description = "Product4 description", Price = 40 },
            new Product { Name = "Product5", Description = "Product5 description", Price = 50 },
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult Show(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);

            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);
            }

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            products.Add(product);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product editedProduct)
        {
            if (!ModelState.IsValid)
            {
                return base.View(editedProduct);
            }
            var product = products.FirstOrDefault((Func<Product, bool>)(p => p.Id == editedProduct.Id));

            if (product != null)
            {
                product.Name = editedProduct.Name;
                product.Description = editedProduct.Description;
                product.Price = editedProduct.Price;
            }

            return RedirectToAction("GetAll");
        }
    }
}