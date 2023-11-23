using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class EstoqueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
