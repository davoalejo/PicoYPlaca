using System;
using PicoYPlaca.Util.Models;
using PicoYPlaca.Util.Predictor;

namespace PicoYPlaca
{
	class Program
	{
		static void Main(string[] args)
		{
			bool exit = false;
			do
			{
				Console.Clear();
				Console.WriteLine("******Pico & Placa Predictor******");

				string licensePlate = GetLicensePlate();
				while (!InputValidator.IsLicensePlateValid(licensePlate))
				{
					Console.WriteLine("Wrong license plate Format!");
					licensePlate = GetLicensePlate();
				}

				string date = GetDate();
				DateTime convertedDate;
				while (!InputValidator.StringToDateOrTime(date, true, out convertedDate))
				{
					Console.WriteLine("Wrong date format!");
					date = GetDate();
				}

				string time = GetTime();
				DateTime convertedTime;
				while (!InputValidator.StringToDateOrTime(time, false, out convertedTime))
				{
					Console.WriteLine("Wrong time format!");
					time = GetTime();
				}
				Console.Clear();
				//Create the model for the License
				var licenseModel = new LicensePlate { LicensePlateNumber = licensePlate };
				//Get and display the message from the predictor
				Console.WriteLine(Predictor.PredictPicoYPlaca(licenseModel, convertedDate, convertedTime.TimeOfDay));
				Console.Write("Exit? (Y/N): ");
				exit = Console.ReadLine().ToLower() == "y";
			} while (!exit);
		}

		private static string GetLicensePlate()
		{
			Console.Write("Enter a valid ecuadorian license plate with or without '-' in the middle: ");
			return Console.ReadLine();
		}

		private static string GetDate()
		{
			Console.Write($"Enter the date (Format: {InputValidator.dateFormat}): ");
			return Console.ReadLine();
		}

		private static string GetTime()
		{
			Console.Write($"Enter the time in 24 Hour format (Format: {InputValidator.timeFormat}): ");
			return Console.ReadLine();
		}
	}
}
