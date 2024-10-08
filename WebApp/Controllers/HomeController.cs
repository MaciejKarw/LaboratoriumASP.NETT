using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /*
        zad 1
        Zdefiniuj metodę z widokiem calculator,
        dodaj link nawigacji do tej metody
        zad 2
        dodaj do kalkulatora
        operator pow, który podnosi x do potęgi y
        funkcje sin, ktora oblicza sin(x), y jet zbędne
     */
    public IActionResult Calculator(Operator? op, double? x, double? y)
    {
        /*var op = Request.Query["op"];
        var x = double.Parse(Request.Query["x"]);
        var y = double.Parse(Request.Query["y"]);
        */
        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby parametrze x lub y";
            return View("CalculatorError");
        }
        
        
        switch (op)
        {
            case Operator.Add:
                ViewBag.Result = x + y;
                break;
            case Operator.Sub:
                ViewBag.Result = x - y;
                break;
            case Operator.Mul:
                ViewBag.Result = x * y;
                break;
            case Operator.Div:
                ViewBag.Result = x / y;
                break;
            case Operator.Pow:
                ViewBag.Result = Math.Pow(x.Value, y.Value);
                break;
            case Operator.Sin:
                ViewBag.Result = Math.Sin(x.Value);
                break;
            default:
                ViewBag.ErrorMessage = "Nieznany operator";
                return View("CalculatorError");

        }
        
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operator
{
    Add, Sub, Mul, Div, Pow, Sin
}