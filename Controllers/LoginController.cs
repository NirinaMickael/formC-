using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cours.Models;
using Cours.Service;
namespace Cours.Controllers;
public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        var user = new IUserViewModel();
        try
        {
            return View(user);
        }
        catch (System.Exception ex)
        {
             Console.WriteLine(ex.Message);
             return Redirect("Home");
        }
    }
    [HttpPost]
    public IActionResult Index(IUserViewModel vis){
        var userTest = new AuthService().ListUsers();
        var user = new IUserViewModel();
        string name =Request.Form["name"],email=Request.Form["email"],password=Request.Form["password"];
        user.Name = name;
        user.Email=email;
        user.Password=password;
        bool test = userTest.Any<IUserViewModel>((IUserViewModel item)=>item.Password==user.Password && item.Email==user.Email);
        if(test){
            return Redirect("Home");
        }else{
            ViewBag.Message="User Not Found";
            return View("Index",user);
        }
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
