using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Cours.Models;
using Cours.Controllers;
using Cours.Service;
public class RegisterController : Controller
{
    private readonly ILogger<RegisterController> _logger;

    public RegisterController(ILogger<RegisterController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        var  vis = new IUserViewModel();
        return View(vis);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(IUserViewModel vis){
        Console.WriteLine("ca marceh");
        var userTest = new AuthService().ListUsers();
        var user = new IUserViewModel();
        string name =Request.Form["Name"],email=Request.Form["Email"],password=Request.Form["Password"];
        user.Name = name;
        user.Email=email;
        user.Password=password;
        Console.WriteLine("{0} {1} {2}",name,email,password);
        bool test =true;
        test = userTest.Any<IUserViewModel>((IUserViewModel item)=>item.Email==user.Email);    
        ViewBag.tester =test;   
        if(test){
            ViewBag.message="User is already register";
            return View("Index",user);
        }else{
            ViewBag.message="User is creted successfully";
            return View("Index",user);
        }
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
