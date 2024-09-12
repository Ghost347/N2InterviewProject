using RouletteAPI.Data;
using RouletteAPI.Repositories;
using RouletteAPI.Models;

namespace RouletteTests
{
	[TestClass]
	public class BetsTest
	{
		public Bets CreateBets()
		{
			AppDbContext dbContext = DataConnection.CreateMemoryDb();
			Bets bets = new Bets(dbContext);
			return bets;
		}

		public Bet CreateSample()
		{
			Bet bet = new Bet()
			{
				Amount = 100,
				Number = 10,
				Win = true,
				Winnings = 1000
			};
			return bet;
		}

		[TestMethod]
		public void TestDatabaseConnection()
		{
			Bets bets = CreateBets();
			Assert.IsNotNull(bets);
		}

		[TestMethod]
		public void PlaceBet()
		{
			Bets bets = CreateBets();
			Bet bet = CreateSample();
			Task<Bet?> betResult = bets.PlaceBet(bet);
			betResult.Wait();
			Bet? content = betResult.Result;
			Assert.IsNotNull(content);
			Assert.IsTrue(content.Id >= 0);

			Console.Write("Done");
		}

		[TestMethod]
		public void GetPayout()
		{
			Bets bets = CreateBets();
			Bet bet = CreateSample();
			Task<Bet?> createdBet = bets.PlaceBet(bet);
			createdBet.Wait();
			Bet? contentCreated = createdBet.Result;
			Assert.IsNotNull(contentCreated);
			Assert.IsTrue(contentCreated.Id >= 0);

			Task<Bet?> betResult = bets.GetPayout(contentCreated.Id);
			betResult.Wait();
			Bet? content = betResult.Result;
			Assert.IsNotNull(content);
			Console.Write("Done");
		}
	}
}