using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PicoYPlaca.Util
{
	public class Predictor
	{
		#region Properties
		public static readonly string dateFormat = "dd/MM/yyyy";
		public static readonly string timeFormat = "HH:mm";
		#endregion

		public static bool IsLicensePlateValid(string licensePlate)
		{			
			var regEx = new Regex("^[a-ceg-ik-tv-z][a-z]{2}[-][\\d]{3,4}", RegexOptions.IgnoreCase);
			bool isValid = regEx.IsMatch(licensePlate);
			return isValid;
		}

		public static bool StringToDateOrTime(string dateTime, bool isDate, out DateTime convertedDateOrTime)
		{
			bool isValid = DateTime.TryParseExact(dateTime, isDate ? dateFormat : timeFormat, null, DateTimeStyles.AssumeLocal, out convertedDateOrTime);
			return isValid;
		}		
	}
}