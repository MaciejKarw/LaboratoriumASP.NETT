using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Result(Operators? op, double? x, double? y)
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
            case Operators.Add:
                ViewBag.Result = x + y;
                break;
            case Operators.Sub:
                ViewBag.Result = x - y;
                break;
            case Operators.Mul:
                ViewBag.Result = x * y;
                break;
            case Operators.Div:
                ViewBag.Result = x / y;
                break;
            case Operators.Pow:
                ViewBag.Result = Math.Pow(x.Value, y.Value);
                break;
            case Operators.Sin:
                ViewBag.Result = Math.Sin(x.Value);
                break;
            default:
                ViewBag.ErrorMessage = "Nieznany operator";
                return View("CalculatorError");

        }
        
        return View();
    }
    
    public IActionResult Form()
    {
        return View();
    }
}


