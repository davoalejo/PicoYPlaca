using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PicoYPlaca.Util.Models;
using PicoYPlaca.Util.Predictor;

namespace PicoYPlaca.Tests.TestClasses
{
	[TestClass]
	public class PredictorTests
	{
		//Special Plate
		[DataRow("CC-1258")]
		//Public Plate
		[DataRow("PMD-128")]
		[TestMethod, Description("Test to verify the Predictor method is returning the correct message")]
		public void PredictPicoYPlaca_PassSpecialOrPublicPlate_ReturnsCorrectString(string plate)
		{
			//Arrange
			var licensePlate = new LicensePlate { LicensePlateNumber = plate };
			DateTime date = DateTime.Now;
			TimeSpan time = DateTime.Now.TimeOfDay;
			const string expectedMessage = "Relax you can circulate any day any time :)";

			//Act
			var actualMessage = Predictor.PredictPicoYPlaca(licensePlate, date, time);

			//Assert
			Assert.AreEqual(expectedMessage, actualMessage);
		}

		//Motorcycle
		[DataRow("IG879D")]
		//Automovile
		[DataRow("PDD-7470")]
		[TestMethod, Description("Test to verify the Predictor method is returning the correct message")]
		public void PredictPicoYPlaca_PassPlateWithPicoYPlacaDayRestriction_ReturnsCorrectString(string plate)
		{
			//Arrange
			var licensePlate = new LicensePlate { LicensePlateNumber = plate };
			DateTime date = new DateTime(2019, 11, 08);
			TimeSpan time = new TimeSpan(7, 35, 0);
			const string expectedMessage = "PULL OVER NOW!!!!!!!!!";

			//Act
			var actualMessage = Predictor.PredictPicoYPlaca(licensePlate, date, time);

			//Assert
			Assert.AreEqual(expectedMessage, actualMessage);
		}

		//Motorcycle
		[DataRow("IG877D")]
		//Automovile
		[DataRow("PDD-7478")]
		[TestMethod, Description("Test to verify the Predictor method is returning the correct message")]
		public void PredictPicoYPlaca_PassPlateWithPicoYPlacaAfterNoonRestriction_ReturnsCorrectString(string plate)
		{
			//Arrange
			var licensePlate = new LicensePlate { LicensePlateNumber = plate };
			DateTime date = new DateTime(2019, 11, 07);
			TimeSpan time = new TimeSpan(18, 00, 0);
			const string expectedMessage = "PULL OVER NOW!!!!!!!!!";

			//Act
			var actualMessage = Predictor.PredictPicoYPlaca(licensePlate, date, time);

			//Assert
			Assert.AreEqual(expectedMessage, actualMessage);
		}

		//Motorcycle
		[DataRow("IG875D")]
		//Automovile
		[DataRow("PDD-7476")]
		[TestMethod, Description("Test to verify the Predictor method is returning the correct message")]
		public void PredictPicoYPlaca_PassPlateWithPicoYPlacaNotRestricted_ReturnsCorrectString(string plate)
		{
			//Arrange
			var licensePlate = new LicensePlate { LicensePlateNumber = plate };
			DateTime date = new DateTime(2019, 11, 06);
			TimeSpan time = new TimeSpan(5, 00, 0);
			const string expectedMessage = "You can circulate, FOR NOW!!!";

			//Act
			var actualMessage = Predictor.PredictPicoYPlaca(licensePlate, date, time);

			//Assert
			Assert.AreEqual(expectedMessage, actualMessage);
		}

		//Motorcycle
		[DataRow("IG873D")]
		//Automovile
		[DataRow("PDD-7474")]
		[TestMethod, Description("Test to verify the Predictor method is returning the correct message")]
		public void PredictPicoYPlaca_PassPlateWithPicoYPlacaOtherDay_ReturnsCorrectString(string plate)
		{
			//Arrange
			var licensePlate = new LicensePlate { LicensePlateNumber = plate };
			DateTime date = new DateTime(2019, 11, 06);
			TimeSpan time = new TimeSpan(5, 00, 0);
			const string expectedMessage = "Chill today is not your day.........of Pico y Placa";

			//Act
			var actualMessage = Predictor.PredictPicoYPlaca(licensePlate, date, time);

			//Assert
			Assert.AreEqual(expectedMessage, actualMessage);
		}
	}
}
