using UnitTestsDemo.Classes;

namespace UnitTestsDemo.Interfaces
{
	public interface ICarTrunk
	{
		int TrunkCapacity { get; }

		void PackItem(string carModel, ILuggage item);
	}
}