using UnitTestsDemo.Interfaces;

namespace UnitTestsDemo.Classes
{
	public class Luggage : ILuggage
	{
		public string Name { get; set; }

		public Luggage(string name)
		{
			Name = name;
		}
	}
}
