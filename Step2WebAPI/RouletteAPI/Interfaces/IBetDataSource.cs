using RouletteAPI.Models;

namespace RouletteAPI.Interfaces
{
	public interface IBetDataSource
	{
		/// <summary>
		/// A bet is placed by the client application by 
		/// doing a post on PlaceBet:
		/// </summary>
		/// <param name="bet"></param>
		/// <returns></returns>
		Task<Bet?> PlaceBet(Bet bet);

		/// <summary>
		/// Retrieve the amount payout by retrieving the bet:
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Bet?> GetPayout(int id);
	}
}
