using Microsoft.AspNetCore.Mvc;

namespace LabWebApp.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (username == "student" && password == "123456")
        {
            ViewBag.Message = "Login successful";
            ViewBag.Success = true;
        }
        else
        {
            ViewBag.Message = "Invalid username or password";
            ViewBag.Success = false;
        }
        return View();
    }
}
