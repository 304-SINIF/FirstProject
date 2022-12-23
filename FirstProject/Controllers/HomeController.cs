using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult users()
        {
            string[] kullanicilar = { "Burçin", "Rafet", "Cihat", "Deniz" };
            return View(kullanicilar);
        }

        public IActionResult kullanicilar()
        {
            User user = new User()
            {
                Id = 1,
                Username = "Ayca_22",
                Password = "1234",
                Name = "Ayça",
                Surname = "Ballı"
            };
            return View(user);
        }

        public IActionResult kullanicilist()
        {

            List<User> users = new List<User>()
            {
                new User{Id=1,Name="Ali",Surname="Veli",Username="AV",Password="1254"},
                new User{Id=2,Name="Ayşe",Surname="Toprak",Username="ayse34",Password="1245"},
                new User{Id=3,Name="Ahmet",Surname="Deli",Username="Aahde",Password="1154"},
                new User{Id=4,Name="Sude",Surname="Göğebakan",Username="sude35",Password="1544"},
                new User{Id=5,Name="Erbakan",Surname="Yolageldi",Username="erb01",Password="14584"},
            };
            return View(users);
        }

        public IActionResult Data()
        {
            //ViewBag.mesaj = "Kayıt işlemi başarılı";
            //ViewData["data"] = DateTime.Now;
            //TempData["Temp"] = "Hata alındı";
            //Session["session"] = DateTime.Now;
            return View();
                

        }
    }
}