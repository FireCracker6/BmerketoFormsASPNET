using System.ComponentModel.DataAnnotations;
using WebAppForm.Models.Entities;

namespace WebAppForm.ViewModels;

public class ProductRegistrationViewModel
{

	//public Guid ProductId { get; set; } = Guid.NewGuid();

	[Required(ErrorMessage = "Du måste ange ett produktnamn")]
	[Display(Name = "Produktnamn *")]
	public string ProductName { get; set; } = null!;

	[Display(Name = "Productbeskrivning (valfritt")]
	public string? ProductDescription { get; set; } = null!;

	// public Guid ProductCategoryId { get; set; }
	public string? ProductType { get; set; } = null!;
	public string? ProductCode { get; set; } = null!;

	[Required(ErrorMessage = "Du måste ange ett produktpris")]
	[Display(Name = "Productpris *")]
	[DataType(DataType.Currency)]
	public decimal ProductPrice { get; set; }
	public decimal? ProductDiscount { get; set; }
	public decimal? ProductDiscountPrice { get; set;}

	public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
	{
		return new ProductEntity
		{
			ProductName = productRegistrationViewModel.ProductName,
			ProductDescription = productRegistrationViewModel.ProductDescription,
			ProductPrice = productRegistrationViewModel.ProductPrice,
		};
	}

}
