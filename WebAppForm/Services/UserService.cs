using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAppForm.Contexts;
using WebAppForm.Models.Entities;
using WebAppForm.ViewModels;

namespace WebAppForm.Services;

public class UserService
{
	private readonly DataContext _context;

	public UserService(DataContext context)
	{
		_context = context;
	}

	public async Task<bool> UserExists(Expression<Func<UserEntity, bool>> predicate)
	{
		if (await _context.Users.AnyAsync(predicate))
			return true;
		return false;
	}

	public async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate)
	{
		var userEntity = await _context.Users.FirstOrDefaultAsync(predicate);
		return userEntity!;
	}


	public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
	{
		try
		{


			// convert to userEntity and profileEntity from registratioform
			UserEntity userEntity = registerViewModel;
			ProfileEntity profileEntity = registerViewModel;

			// Create user
			_context.Users.Add(userEntity);
			await _context.SaveChangesAsync();

			// Create user profile
			profileEntity.UserId = userEntity.Id;
			_context.Profiles.Add(profileEntity);
			await _context.SaveChangesAsync();


			return true;




		} catch
		{
			return false;
		}
	}

	public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
	{
		var userEntity = await GetAsync(x => x.Email == loginViewModel.Email);
		if (userEntity != null) 
			return userEntity.VerifySecurePassword(loginViewModel.Password);
		return false;
	}
}
