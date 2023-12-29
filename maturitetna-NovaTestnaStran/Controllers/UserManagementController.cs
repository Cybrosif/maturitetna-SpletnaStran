using Microsoft.AspNetCore.Mvc;

namespace maturitetna_NovaTestnaStran.Controllers
{
    public class UserManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
