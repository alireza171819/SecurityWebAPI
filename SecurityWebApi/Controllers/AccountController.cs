using Microsoft.AspNetCore.Mvc;

namespace SecurityWebApi.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
