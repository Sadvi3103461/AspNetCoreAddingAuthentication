using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WishList.Controllers
{
    [Authorize]
    public class AccountController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
