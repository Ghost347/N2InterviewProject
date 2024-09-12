using Microsoft.EntityFrameworkCore;
using RouletteAPI.Models;

namespace RouletteAPI.Data
{
	/// <summary>
	/// This is the database context class that will be used to interact with the database.
	/// </summary>
	public class AppDbContext: DbContext
	{
		/// <summary>
		/// The constructor of the database context class.
		/// This is used to set the options on the database context.
		/// </summary>
		/// <param name="options"></param>
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Bet> Bets { get; set; }
		public DbSet<Spin> Spins { get; set; }
	}
}
