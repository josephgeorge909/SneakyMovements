using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SneakyMovements.Models;

namespace SneakyMovements.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SneakyMovementsDbContext _context;

    public HomeController(ILogger<HomeController> logger, SneakyMovementsDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var showcaseProducts = new List<Product>();
        var products = _context.Products.ToList();
        foreach (var product in products)
        {
            if (product.OnSite.Equals(true) && product.OnHomePage.Equals(true))
            {
                showcaseProducts.Add(product);
            }
        }
        
        return View(showcaseProducts);
    }

    public IActionResult Vault()
    {
        return View();
    }

    public IActionResult Story()
    {
        return View();
    }

    public IActionResult Contact()
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