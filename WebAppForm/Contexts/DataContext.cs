using Microsoft.EntityFrameworkCore;
using WebAppForm.Models.Entities;

namespace WebAppForm.Contexts;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}
	public DbSet<UserEntity> Users { get; set; }
	public DbSet<ProfileEntity> Profiles { get; set; }
}
