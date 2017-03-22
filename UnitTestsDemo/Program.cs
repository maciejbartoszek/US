using System;
using System.Collections.Generic;
using UnitTestsDemo.Interfaces;
using UnitTestsDemo.Classes;

namespace UnitTestsDemo
{
	public class Program
	{
		static void Main(string[] args)
		{
			var carTrunk = new CarTrunk(3);
			var ourFamilyCar = new Car("Honda Accord", carTrunk);

			var mommyBag = new Luggage("Huge mommy bag");
			var tennisRacket = new Luggage("My tennis racket");
			var dadTools = new Luggage("Dad tools");
			//var notNeededLuggage = new Luggage("Useless stuff");

			var ourLuggage = new List<ILuggage>();
			ourLuggage.Add(mommyBag);
			ourLuggage.Add(tennisRacket);
			ourLuggage.Add(dadTools);
			//ourLuggage.Add(notNeededLuggage);

			var ourFamilyTrip = new FamilyTrip(ourFamilyCar, null);

			ourFamilyTrip.PrepareFamilyTrip();
			Console.ReadKey();
		}
	}
}
