using RouletteAPI.Data;
using RouletteAPI.Repositories;
using RouletteAPI.Models;

namespace RouletteTests
{
	[TestClass]
	public class SpinsTest
	{
		public Spins CreateSpins()
		{
			AppDbContext dbContext = DataConnection.CreateMemoryDb();
			Spins spins = new Spins(dbContext);
			return spins;

		}

		public Spin CreateSample()
		{
			Spin spin = new Spin()
			{
				//Id = 1,
				NumberResult = 10
			};
			return spin;
		}

		[TestMethod]
		public void TestDatabaseConnection()
		{
			Spins spins = CreateSpins();
			Assert.IsNotNull(spins);
		}

		[TestMethod]
		public void PlaceBet()
		{
			Spins spins = CreateSpins();
			Spin spin = CreateSample();
			Task<Spin?> spinResult = spins.Spin(spin);
			spinResult.Wait();
			Spin? content = spinResult.Result;
			Assert.IsNotNull(content);
			Assert.IsTrue(content.Id >= 0);
		}

		[TestMethod]
		public void ShowPreviousSpins()
		{
			Spins spins = CreateSpins();
			Spin spin = CreateSample();
			Task<Spin?> spinResult = spins.Spin(spin);
			spinResult.Wait();
			Spin? createdContent = spinResult.Result;
			Assert.IsNotNull(createdContent);
			Assert.IsTrue(createdContent.Id >= 0);


			Task<IEnumerable<Spin>> spinsResult = spins.ShowPreviousSpins();
			spinsResult.Wait();
			IEnumerable<Spin> content = spinsResult.Result;
			Assert.IsNotNull(content);
			Assert.IsTrue(content.Count() > 0);
		}
	}
}