using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodespacesBlank.Models;
using CodespacesBlank.Services;

namespace CodespacesBlank.Controllers;

public class HomeController : Controller
{

      private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    //create controller
     public IActionResult Create()
    {
        return View();
    }

    //POST METHOD TO SUBMIT THE FORM DATA
    [HttpPost]
    public IActionResult Create(ProductDto productDto)
    {
      if(productDto.ImageFile == null)
        {
            ModelState.AddModelError("ImageFile", "Please select an image file.");
           
        }
        if(!ModelState.IsValid)
        {
            return View(productDto);
        }
        return RedirectToAction("Index", "Home");
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
