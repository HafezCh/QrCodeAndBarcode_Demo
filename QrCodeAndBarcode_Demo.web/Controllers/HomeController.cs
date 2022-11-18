using Microsoft.AspNetCore.Mvc;

namespace QrCodeAndBarcode_Demo.web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}