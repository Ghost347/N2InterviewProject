using Microsoft.AspNetCore.Mvc;
using RouletteAPI.Interfaces;
using RouletteAPI.Models;

namespace RouletteAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BetsController : ControllerBase
	{
		/// <summary>
		/// The data source of the bets:
		/// </summary>
		private IBetDataSource _betDataSource;

		public BetsController(IBetDataSource bets)
		{
			_betDataSource = bets;
		}

		/// <summary>
		/// Retrieve the amount payout by retrieving the bet:
		/// </summary>
		/// <param name="id">
		/// The id of the bet having the payout:
		/// </param>
		/// <returns>
		/// The bet record.
		/// </returns>
		[HttpGet]
		public IActionResult GetPayout(int id)
		{
			//Retrieve a bet record that contains the payout information:
			return Ok(_betDataSource.GetPayout(id));
		}

		/// <summary>
		/// Create a bet record:
		/// </summary>
		/// <param name="bet">
		/// A bet is placed by the client application by 
		/// doing a post on PlaceBet:
		/// </param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<Bet>> PlaceBet([FromBody] Bet bet)
		{
			//If the bet is not set, return a bad request:
			if (bet == null)
			{
				return BadRequest("Object instance not set");
			}

			// The bet is valid, so create a Bet record:
			var createdBet = await _betDataSource.PlaceBet(bet);
			return Ok(createdBet);
		}
	}
}
