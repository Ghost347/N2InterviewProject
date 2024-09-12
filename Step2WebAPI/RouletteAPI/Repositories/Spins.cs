using Microsoft.EntityFrameworkCore;
using RouletteAPI.Data;
using RouletteAPI.Interfaces;
using RouletteAPI.Models;

namespace RouletteAPI.Repositories
{
	public class Spins : ISpinDataSource
	{
		private readonly AppDbContext _context;

		public Spins(AppDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Retrieve all the previous spins:
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Spin>> ShowPreviousSpins()
		{
			return await _context.Spins.ToListAsync();
		}

		/// <summary>
		/// The client app execute a spin and then submit the spin result by calling this method:
		/// </summary>
		/// <param name="spin"></param>
		/// <returns></returns>
		public async Task<Spin?> Spin(Spin spin)
		{
			if (spin != null)
			{
				_context.Spins.Add(spin);
				await _context.SaveChangesAsync();
				return spin;
			}
			return null;
		}
	}
}
