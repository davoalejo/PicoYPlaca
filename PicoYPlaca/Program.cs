using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicoYPlaca.Util;

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
				Console.WriteLine("******Pico & Placa InputValidator******");

				string licensePlate = GetLicensePlate();
				while (!InputValidator.IsLicensePlateValid(licensePlate))
				{
					Console.WriteLine("Wrong license plate Format!");
					licensePlate = GetLicensePlate();
				}

				string date = GetDate();
				while(!InputValidator.StringToDateOrTime(date, true, out DateTime convertedDate))
				{
					Console.WriteLine("Wrong date format!");
					date = GetDate();
				}

				string time = GetTime();
				while(!InputValidator.StringToDateOrTime(time, false, out DateTime convertedTime))
				{
					Console.WriteLine("Wrong time format!");
					time = GetTime();
				}

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
