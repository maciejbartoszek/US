using System;
using System.Collections.Generic;
using UnitTestsDemo.Interfaces;

namespace UnitTestsDemo.Classes
{
	public class Car : ICar
	{
		public string Model { get; private set; }
		public ICarTrunk Trunk { get; private set; }

		public Car(string model, ICarTrunk trunk)
		{
			Model = model;
			Trunk = trunk;
		}

		public int CheckFuelLevel()
		{
			Console.Out.WriteLine("Fuel level checking...");

			return FuelChecker.ReturnFuelLevel();
		}

		public bool PackLuggageToTheTrunk(List<ILuggage> luggageItems)
		{
			if (luggageItems == null)
			{
				throw new Exception("Luggage does not exist!");
			}

			if (luggageItems.Count > Trunk.TrunkCapacity)
			{
				Console.Out.WriteLine("Car trunk is not big enough for such a luggage!");
				return false;
			}

			foreach (var luggageItem in luggageItems)
			{
				Trunk.PackItem(Model, luggageItem);
			}

			return true;
		}
	}
}
