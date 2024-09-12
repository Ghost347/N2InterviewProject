using RouletteAPI.Data;
using RouletteAPI.Interfaces;
using RouletteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RouletteAPI.Repositories
{
	public class Bets: IBetDataSource
	{
		/// <summary>
		/// The Db context providing access to the database:
		/// </summary>
		private readonly AppDbContext _context;

		public Bets(AppDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// A bet is placed by the client application by creating a bet record:
		/// </summary>
		/// <param name="bet"></param>
		/// <returns></returns>
		public async Task<Bet?> PlaceBet(Bet bet)
		{
			if (bet != null)
			{
				_context.Bets.Add(bet);
				await _context.SaveChangesAsync();
				return bet;
			}
			return null;
		}

		/// <summary>
		/// Retrieve the amount payout by retrieving the bet record containing the payout information:
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Bet?> GetPayout(int id)
		{
			return await _context.Bets.FindAsync(id);
		}
	}
}
