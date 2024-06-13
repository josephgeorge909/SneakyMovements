using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SneakyMovements.Models;
using SneakyMovements.ViewModels;

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

    public IActionResult ProductDetails(int id)
    {
        var productDetails = _context.Products
            .Where(x => x.Id.Equals(id))
            .Include(x => x.ProductDetails)
            .Select(x => new
            {
                Name = x.Name,
                Description = x.ProductDetails.Description,
                Price = x.ProductDetails.Price,
                ImageName = x.ImageName
            })
            .FirstOrDefault();

        var productDetailVm = new ProductDetailVm()
        {
            Name = productDetails.Name,
            Description = productDetails.Description,
            Price = Math.Round(productDetails.Price, 2),
            ImageName = productDetails.ImageName
        };
        
        return View(productDetailVm);
    }
}