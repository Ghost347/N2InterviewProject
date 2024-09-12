using RouletteAPI.Models;

namespace RouletteAPI.Interfaces
{
	public interface ISpinDataSource
	{
		/// <summary>
		/// Execute a spin, and on success, store the spin in the database by calling this method:
		/// </summary>
		/// <param name="spin"></param>
		/// <returns></returns>
		Task<Spin?> Spin(Spin spin);

		/// <summary>
		/// Retrieve all the spins already made:
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Spin>> ShowPreviousSpins();

	}
}
