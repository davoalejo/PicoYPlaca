using PicoYPlaca.Util.Models;
using System;
using System.Globalization;
using System.Linq;

namespace PicoYPlaca.Util.Predictor
{
	public class Predictor
	{
		/// <summary>
		/// Generates a message indicating wheater or not the vehicle should be circulating
		/// </summary>
		public static string PredictPicoYPlaca(LicensePlate licensePlate, DateTime date, TimeSpan time)
		{			
			if (licensePlate.IsSpecialPlate || licensePlate.IsPublicPlate)
			{
				return "Relax you can circulate any day any time :)";
			}

			//Get the penultimate character wich contains the last digit if a motorcycle plate 
			//else the last charatcer contains the last digit of a normal plate
			int lastDigit = GetLastDigit(licensePlate.LicensePlateNumber, licensePlate.IsMotorcyclePlate ? 2 : 1);
			//Get the applying rule of pico y placa depending on the last digit of the plate
			PicoYPlacaRule picoYPlacaRule = PicoYPlacaRule.GetPicoYPlacaRules().First(t => 
																	t.PlateLastNumbers.Contains(lastDigit));
			//Get the day of the week of the date entered
			string dayOfWeek = date.ToString("dddd", new CultureInfo("en-EN"));

			if (picoYPlacaRule.DayOfWeek.Equals(dayOfWeek))
			{
				return GetCanOrCantCirculateMessage(time);
			}
			
			return "Chill today is not your day.........of Pico y Placa";
			
		}

		private static string GetCanOrCantCirculateMessage(TimeSpan time)
		{
			bool cantCirculate = (time >= PicoYPlacaRule.DayMinTime && time <= PicoYPlacaRule.DayMaxTime) ||
								 (time >= PicoYPlacaRule.AfterNoonMinTime && time <= PicoYPlacaRule.AfterNoonMaxTime);
			return cantCirculate ? "PULL OVER NOW!!!!!!!!!" : "You can circulate, FOR NOW!!!";
		}

		private static int GetLastDigit(string licensePlateNumber, int index)
		{
			string lastDigitChar = licensePlateNumber.Substring(licensePlateNumber.Length - index, 1);
			int lastDigit = int.Parse(lastDigitChar);
			return lastDigit;
		}
	}
}
