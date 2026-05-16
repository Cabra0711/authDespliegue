using Microsoft.AspNetCore.Mvc;

namespace PracticaAuth.Controllers;

public class LoginController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}