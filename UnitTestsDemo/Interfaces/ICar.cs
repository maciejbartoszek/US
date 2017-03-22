using System.Collections.Generic;

namespace UnitTestsDemo.Interfaces
{
	public interface ICar
	{
        string Model { get; }

        ICarTrunk Trunk { get; }

		int CheckFuelLevel();

		bool PackLuggageToTheTrunk(List<ILuggage> luggageItems);
	}
}
