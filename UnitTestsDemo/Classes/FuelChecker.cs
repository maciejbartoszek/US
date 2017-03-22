using System;

namespace UnitTestsDemo.Classes
{
	public static class FuelChecker
	{
		public static int ReturnFuelLevel()
		{
			var random = new Random();
			var randomValue = random.Next(100);

			return randomValue;
		}
	}
}
