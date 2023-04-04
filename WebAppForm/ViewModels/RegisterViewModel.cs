using System.ComponentModel.DataAnnotations;
using WebAppForm.Models.Entities;

namespace WebAppForm.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage ="Du måste ange ett förnamn")]
		[Display(Name = "Förnamn")]
	[RegularExpression(@"^[a-zA-Z\u00C0-\u017F]+([ -][a-zA-Z\u00C0-\u017F]+)*$", ErrorMessage = "Du måste ange ett giltigt förnamn")]
		public string FirstName { get; set; } = null!;


		[Required(ErrorMessage = "Du måste ange ett efternamn")]
		[RegularExpression(@"^[a-zA-Z\u00C0-\u017F]+([ -][a-zA-Z\u00C0-\u017F]+)*$", ErrorMessage = "Du måste ange ett giltigt efternamn")]
		[Display(Name = "Efternamn")]
		public string LastName { get; set; } = null!;

		[Required(ErrorMessage = "Du måste ange en e-postadress")]
		[RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Du måste ange en giltig e-postadress")]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "E-postadress")]
		public string Email { get; set; } = null!;



		[Required(ErrorMessage = "Du måste ange ett lösenord")]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Du måste ange ett giltigt lösenord")]
		[DataType(DataType.Password)]
		[Display(Name = "Lösenord")]
		public string Password { get; set; } = null!;



		[Required(ErrorMessage = "Du måste bekfräfta lösenordet")]
		[Compare(nameof(Password), ErrorMessage = "Lösenordet matchar inte")]
		[DataType(DataType.Password)]
		[Display(Name = "Bekräfta lösenord")]
		public string ConfirmPassword { get; set; } = null!;




		[Display(Name = "Gatunamn")]
		public string? StreetName { get; set; }



		[Display(Name = "Postnummer")]
		public string? PostalCode { get; set; }



		[Display(Name = "Stad")]
		public string? City { get; set; }


		public static implicit operator UserEntity(RegisterViewModel reqisterViewModel)
		{
			var userEntity = new UserEntity { Email = reqisterViewModel.Email };
			userEntity.GenerateSecurePassword(reqisterViewModel.Password);
			return userEntity;

		}

		public static implicit operator ProfileEntity(RegisterViewModel reqisterViewModel)
		{
			return new ProfileEntity
			{
				FirstName = reqisterViewModel.FirstName,
				LastName = reqisterViewModel.LastName,
				StreetName = reqisterViewModel.StreetName,
				PostalCode = reqisterViewModel.PostalCode,
				City = reqisterViewModel.City
			};
			
		}

	}
}
