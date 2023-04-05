using Microsoft.AspNetCore.Mvc;
using WebAppForm.Services;
using WebAppForm.ViewModels;

namespace WebAppForm.Controllers;

public class ProductsController : Controller
{
	private readonly ProductService _productService;

	public ProductsController(ProductService productService)
	{
		_productService = productService;
	}

	public IActionResult Index()
	{
		return View();
	}

	
	public IActionResult Register()
	{
		return View();	
	}


	[HttpPost]
	public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel)
	{
		if (ModelState.IsValid) 
		
		{ 
			 if (await _productService.CreateAsync(productRegistrationViewModel) ) 
				return RedirectToAction("Index", "Products");
			ModelState.AddModelError("", "Något gick fel vid skapande av produkten");
			
		
		}
		return View();
		

	}
}
