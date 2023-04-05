using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAppForm.Models.Entities;

public class ProductEntity
{
	public int Id { get; set; }
	public string ProductName { get; set; } = null!;
	public string? ProductDescription { get; set; }

	[Column(TypeName = "money")]
	public decimal ProductPrice { get; set; }

	public static implicit operator ProductModel(ProductEntity productEntity)
	{
		return new ProductModel
		{
			Id = productEntity?.Id,
			ProductName = productEntity?.ProductName,
			ProductDescription = productEntity?.ProductDescription,
			ProductPrice = productEntity?.ProductPrice,
		};
	}
}
