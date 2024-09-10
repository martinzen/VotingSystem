using Microsoft.AspNetCore.Mvc;

namespace VotingSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
