using Microsoft.EntityFrameworkCore;
using sneakers_api_.net.models;

namespace sneakers_api_.net.data
{
	public class ApiDbContext : DbContext
	{

		public DbSet<Sneaker> Sneakers { get; set; }
		public DbSet<Size> Size { get; set; }
		public DbSet<Color> Color { get; set; }
		public DbSet<ImageUrl> ImageUrl { get; set; }

		public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
		{

		}
	}
}
