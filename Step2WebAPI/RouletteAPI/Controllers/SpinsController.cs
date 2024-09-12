using Microsoft.AspNetCore.Mvc;
using RouletteAPI.Interfaces;
using RouletteAPI.Models;

namespace RouletteAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpinsController : ControllerBase
	{
		/// <summary>
		/// The spin data source:
		/// </summary>
		private ISpinDataSource _spinDataSource;
		public SpinsController(ISpinDataSource spins)
		{
			_spinDataSource = spins;
		}

		/// <summary>
		/// Retrieve all the spins already made:
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Spin>>> ShowPreviousSpins()
		{
			var spins = await _spinDataSource.ShowPreviousSpins();
			return Ok(spins);
		}


		/// <summary>
		/// Execute a spin, and on success, store the spin in the database by calling this method:
		/// </summary>
		/// <param name="spin"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<Spin>> Spin([FromBody] Spin spin)
		{
			if (spin == null)
			{
				return BadRequest("Object instance not set");
			}

			var createdSpin= await _spinDataSource.Spin(spin);
			return Ok(createdSpin);
		}
	}
}
