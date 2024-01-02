

using Microsoft.EntityFrameworkCore;
using WebApplication1.data;

namespace WebApiGrey.Server.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //configure dbContext option 
		{

		}
		public DbSet<StudentModel> Courses { get; set; }

	}
}