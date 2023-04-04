using Microsoft.AspNetCore.Mvc;
using WebAppForm.Models.Entities;
using WebAppForm.ViewModels;

namespace WebAppForm.Controllers;

public class AccountController : Controller
{

	public IActionResult Register()
	{

		return View();
	}

	[HttpPost]
	public IActionResult Register(RegisterViewModel registerViewModel)
	{
		if (ModelState.IsValid)
		{
			UserEntity userEntity = registerViewModel;
			ProfileEntity profileEntity = registerViewModel;
			profileEntity.UserId = userEntity.Id;
		}
		else
		{
			// Clear model state errors if they exist
			ModelState.Clear();
		}

		return View(registerViewModel);
	}




























	public IActionResult Index()
	{
		return View();
	}
}
