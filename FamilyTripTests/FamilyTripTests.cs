using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsDemo.Interfaces;
using UnitTestsDemo.Classes;
using Moq;

namespace FamilyTripTests
{
	[TestClass]
	public class FamilyTripTests
	{
        private Mock<List<ILuggage>> fakeLuggage;
        private Mock<ICar> fakeCar;
        private Mock<ICarTrunk> fakeCarTrunk;

        [TestInitialize]
        public void TestInit()
        {
            fakeCar = new Mock<ICar>();
            fakeCarTrunk = new Mock<ICarTrunk>();
            fakeLuggage = new Mock<List<ILuggage>>();
        }

        [TestMethod]
        public void ShouldPrepareFamilyTripReturnFalseWhenExceptionOccurredDuringPackingLuggage()
        {
            // Given
            fakeCar.Setup(x => x.PackLuggageToTheTrunk(It.IsAny<List<ILuggage>>())).Throws(new Exception());

            var familyTrip = new FamilyTrip(fakeCar.Object, fakeLuggage.Object);

            // When
            var result = familyTrip.PrepareFamilyTrip();

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldPrepareFamilyTripReturnFalseWhenFuelLevelIsNotEnough()
        {
            // Given
            fakeCar.Setup(x => x.PackLuggageToTheTrunk(It.IsAny<List<ILuggage>>())).Returns(true);
            fakeCar.Setup(x => x.CheckFuelLevel()).Returns(49);

            var familyTrip = new FamilyTrip(fakeCar.Object, fakeLuggage.Object);

            // When
            var result = familyTrip.PrepareFamilyTrip();

            // Then
            Assert.IsFalse(result);
        }

		[TestMethod]
		public void ShouldPrepareFamilyTripReturnTrueWhenAllIsOk()
		{
			// Given
            fakeCar.Setup(x => x.PackLuggageToTheTrunk(It.IsAny<List<ILuggage>>())).Returns(true);
            fakeCar.Setup(x => x.CheckFuelLevel()).Returns(100);

            var familyTrip = new FamilyTrip(fakeCar.Object, fakeLuggage.Object);

			// When
            var result = familyTrip.PrepareFamilyTrip();

			// Then
			Assert.IsTrue(result);
		}
	}
}
