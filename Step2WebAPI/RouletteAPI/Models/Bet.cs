namespace RouletteAPI.Models
{
	public class Bet
	{
		public int Id { get; set; }
		public int Amount { get; set; } = 0;
		public int Number { get; set; } = 0;
		public bool Win { get; set; } = false;
		public int Winnings { get; set; } = 0;
	}
}
