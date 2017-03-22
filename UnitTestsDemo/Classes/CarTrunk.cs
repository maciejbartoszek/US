using System;
using UnitTestsDemo.Interfaces;

namespace UnitTestsDemo.Classes
{
	public class CarTrunk : ICarTrunk
	{
		public int TrunkCapacity { get; private set; }

		public CarTrunk(int capacity)
		{
			TrunkCapacity = capacity;
		}

		public void PackItem(string carModel, ILuggage item)
		{
			Console.Out.WriteLine(string.Format("New item: {0} has been packed to {1} trunk!", item.Name, carModel));
		}
	}
}