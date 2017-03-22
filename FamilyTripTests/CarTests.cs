using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsDemo.Interfaces;
using UnitTestsDemo.Classes;
using Moq;

namespace FamilyTripTests
{
	[TestClass]
	public class CarTests
	{
        private Mock<ICarTrunk> fakeCarTrunk;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            fakeCarTrunk = new Mock<ICarTrunk>();
        }

		[TestMethod]
		public void ShouldPackLuggageToTheTrunkReturnTrueWhenTrunkSizeIsEnoughForLuggage()
		{
			// Given
			const int TrunkCapacity = 2;
			var carTrunk = new CarTrunk(TrunkCapacity);
			var car = new Car("test model", carTrunk);
			var testLuggage = new List<ILuggage>
			{
				new Luggage("item no 1")
			};

			// When
			var result = car.PackLuggageToTheTrunk(testLuggage);

			// Then
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void ShouldPackLuggageToTheTrunkReturnFalseWhenTrunkSizeIsNotEnoughForLuggage()
		{
			// Given
			const int TrunkCapacity = 2;
			var carTrunk = new CarTrunk(TrunkCapacity);
			var car = new Car("test model", carTrunk);
			var testLuggage = new List<ILuggage>
			{
				new Luggage("item no 1"),
				new Luggage("item no 2"),
				new Luggage("item no 3")
			};

			// When
			var result = car.PackLuggageToTheTrunk(testLuggage);

			// Then
			Assert.IsFalse(result);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void ShouldThrowExceptionWhenLuggageListIsNull()
		{
			// Given
			const int TrunkCapacity = 2;
			var carTrunk = new CarTrunk(TrunkCapacity);
			var car = new Car("test model", carTrunk);
			List<ILuggage> testLuggage = null;

			// When
			car.PackLuggageToTheTrunk(testLuggage);

			// Then
		}

        [TestMethod]
        public void ShouldCallPackMethodAsManyTimesAsLuggageCount()
        {
            // Given
            const int TrunkCapacity = 5;
            const string CarModel = "test model";

            fakeCarTrunk.SetupGet(x => x.TrunkCapacity).Returns(TrunkCapacity);
            var car = new Car(CarModel, fakeCarTrunk.Object);
            var testLuggage = new List<ILuggage>
			{
				new Luggage("item no 1"),
				new Luggage("item no 2"),
				new Luggage("item no 3")
			};

            // When
            var result = car.PackLuggageToTheTrunk(testLuggage);

            // Then
            fakeCarTrunk.Verify(x => x.PackItem(CarModel, It.IsAny<ILuggage>()), Times.Exactly(testLuggage.Count));
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TestData\\testdata.xml", "testcase", DataAccessMethod.Sequential)]
        public void ShouldPackLuggageToTheTrunkReturnTrueWhenTrunkSizeIsEnoughForLuggage_DataDriven()
        {
            // Given
            var trunkCapacity = int.Parse(TestContext.DataRow[0].ToString());
            var luggageCount = int.Parse(TestContext.DataRow[1].ToString());

            var carTrunk = new CarTrunk(trunkCapacity);
            var car = new Car("test model", carTrunk);

            var testLuggage = new List<ILuggage>();
            for(var i = 0; i < luggageCount; i++)
            {
                testLuggage.Add(new Luggage(i.ToString()));
            }

            // When
            var result = car.PackLuggageToTheTrunk(testLuggage);

            // Then
            Assert.IsTrue(result);
        }
	}
}
