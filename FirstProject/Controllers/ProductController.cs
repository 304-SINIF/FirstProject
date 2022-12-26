using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
        //    List<Product> products = new List<Product>()
        //{
        //    new Product{Id=1, Name="Elma",Stock=15,Price=25},
        //    new Product{Id=2, Name="Armut",Stock=20,Price=18},
        //    new Product{Id=3, Name="Kavun",Stock=40,Price=30},
        //    new Product{Id=4, Name="Karpuz",Stock=55,Price=36},
        //    new Product{Id=5, Name="Çilek",Stock=65,Price=17},
        //    new Product{Id=6, Name="Muz",Stock=10,Price=28}
        //};


            IEnumerable<Product> products = DBContext.productlist.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Product product)
        {
            DBContext.productlist.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var urun = DBContext.productlist.Where(x => x.Id == id).FirstOrDefault();
            DBContext.productlist.Remove(urun);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product=DBContext.productlist.Where(x=>x.Id == id).FirstOrDefault();
            return View(product);

        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var edproduct=DBContext.productlist.Where(x=>x.Id == product.Id).FirstOrDefault();
            if (edproduct != null)
            {
                edproduct.Name = product.Name;
                edproduct.Price = product.Price;
                edproduct.Stock = product.Stock;
                ViewBag.mesaj = "Ürün başarılı bir şekilde güncellenmiştir.";
                return View(edproduct);
            }
            else
            {
                return View("Not found Product");
              
            }
        }

    }
}
