using System.ComponentModel.DataAnnotations;

namespace WebAppForm.ViewModels;

public class LoginViewModel
{
	[Required(ErrorMessage = "Du måste ange en e-postadress")]
	[RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Du måste ange en giltig e-postadress")]
	[DataType(DataType.EmailAddress)]
	[Display(Name = "E-postadress")]
	public string Email { get; set; } = null!;



	[Required(ErrorMessage = "Du måste ange ett lösenord")]

	[DataType(DataType.Password)]
	[Display(Name = "Lösenord")]
	public string Password { get; set; } = null!;

}
