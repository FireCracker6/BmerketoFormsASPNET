using Microsoft.EntityFrameworkCore;
using WebAppForm.Contexts;
using WebAppForm.Models;
using WebAppForm.Models.Entities;
using WebAppForm.ViewModels;

namespace WebAppForm.Services;


public class ProductService
{
	private readonly DataContext _context;

	public ProductService(DataContext context)
	{
		_context = context;
	}

	public async Task<bool> CreateAsync(ProductRegistrationViewModel productRegistrationViewModel)
	{
		try
		{
			ProductEntity productEntity = productRegistrationViewModel;
			_context.Products.Add(productEntity);
			await _context.SaveChangesAsync();
			return true;
		}
		catch
		{
			return false;
		}

	}

	public async Task<IEnumerable<ProductModel>> GetAllAsync()
	{
		var products = new List<ProductModel>();
		var items = await _context.Products.ToListAsync();
		foreach(var item in items)
		{
			ProductModel productModel = item;
			products.Add(productModel);
		
		}
		return products;
	}
}
