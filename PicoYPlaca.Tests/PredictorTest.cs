using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PicoYPlaca.Util;

namespace PicoYPlaca.Tests
{
	[TestClass]
	public class PredictorTest
	{
		[TestMethod, Description("Test to validate IsLicensePlateValid returns true with a valid License Plate")]
		public void IsLicensePlateValid_WithValidLicense_ReturnTrue()
		{
			//Arrange
			const string licensePlate = "pdd-1260";

			//Act
			bool actualBool = Predictor.IsLicensePlateValid(licensePlate);

			//Assert
			Assert.IsTrue(actualBool);
		}

		[TestMethod, Description("Test to validate IsLicensePlateValid returns false with an invalid License Plate")]
		public void IsLicensePlateValid_WithInValidLicense_ReturnFalse()
		{
			//Arrange
			const string licensePlate = "pdd-12";

			//Act
			bool actualBool = Predictor.IsLicensePlateValid(licensePlate);

			//Assert
			Assert.IsFalse(actualBool);
		}

		[TestMethod, Description("Test to validate IsLicensePlateValid returns true with a valid License Plate with upper case")]
		public void IsLicensePlateValid_WithValidLicenseUpperCase_ReturnTrue()
		{
			//Arrange
			const string licensePlate = "PDD-1260";

			//Act
			bool actualBool = Predictor.IsLicensePlateValid(licensePlate);

			//Assert
			Assert.IsTrue(actualBool);
		}

		[TestMethod, Description("Test to validate IsLicensePlateValid returns true with a valid License Plate with 3 digits instead of 4")]
		public void IsLicensePlateValid_WithValidLicense3Digits_ReturnTrue()
		{
			//Arrange
			const string licensePlate = "PDD-126";

			//Act
			bool actualBool = Predictor.IsLicensePlateValid(licensePlate);

			//Assert
			Assert.IsTrue(actualBool);
		}

		[TestMethod, Description("Test to validate StringToDateOrTime returns true with a valid date")]
		public void StringToDateOrTime_WithValidDate_ReturnTrue()
		{
			//Arrange
			const string date = "06/11/2019";
			const bool isDate = true;

			//Act
			bool actualBool = Predictor.StringToDateOrTime(date, isDate, out DateTime converted);

			//Assert
			Assert.IsTrue(actualBool);
		}

		[DataRow("notADate")]
		[DataRow("6/11/2019")]
		[DataRow("06/1/2019")]
		[DataRow("40/01/2019")]
		[DataRow("05/20/2019")]
		[DataRow("05/11/201")]
		[TestMethod, Description("Test to validate StringToDateOrTime returns false with a non-valid date")]
		public void StringToDateOrTime_WithInValidDate_ReturnFalse(string date)
		{
			//Arrange			
			const bool isDate = true;

			//Act
			bool actualBool = Predictor.StringToDateOrTime(date, isDate, out DateTime converted);

			//Assert
			Assert.IsFalse(actualBool);
		}

		[TestMethod, Description("Test to validate StringToDateOrTime returns the correct converted date")]
		public void StringToDateOrTime_WithValidDate_ReturnCorrectDate()
		{
			//Arrange
			const string date = "06/11/2019";
			const bool isDate = true;
			DateTime expectedDate = new DateTime(2019, 11, 6);

			//Act
			bool actualBool = Predictor.StringToDateOrTime(date, isDate, out DateTime actualDate);

			//Assert
			Assert.AreEqual(expectedDate, actualDate);
		}

		[TestMethod, Description("Test to validate StringToDateOrTime returns true with a valid time")]
		public void StringToDateOrTime_WithValidTime_ReturnTrue()
		{
			//Arrange
			const string time = "23:25";
			const bool isDate = false;

			//Act
			bool actualBool = Predictor.StringToDateOrTime(time, isDate, out DateTime converted);

			//Assert
			Assert.IsTrue(actualBool);
		}

		[DataRow("notMyTime")]
		[DataRow("6/11/2019")]
		[DataRow("25:25:12")]
		[DataRow("15:74:12")]
		[DataRow("15:57:64")]
		[TestMethod, Description("Test to validate StringToDateOrTime returns false with a non-valid time")]
		public void StringToDateOrTime_WithInValidTime_ReturnFalse(string time)
		{
			//Arrange			
			const bool isDate = false;

			//Act
			bool actualBool = Predictor.StringToDateOrTime(time, isDate, out DateTime converted);

			//Assert
			Assert.IsFalse(actualBool);
		}

		[TestMethod, Description("Test to validate StringToDateOrTime returns the correct converted time")]
		public void StringToDateOrTime_WithValidTime_ReturnCorrectTime()
		{
			//Arrange
			const string time = "15:25";
			const bool isDate = false;
			TimeSpan expectedTime = new TimeSpan(15, 25, 00);

			//Act
			bool actualBool = Predictor.StringToDateOrTime(time, isDate, out DateTime actualTime);

			//Assert
			Assert.AreEqual(expectedTime, actualTime.TimeOfDay);
		}
	}
}
