using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PicoYPlaca.Util.Predictor
{
	public class InputValidator
	{
		#region Properties
		public static readonly string dateFormat = "dd/MM/yyyy";
		public static readonly string timeFormat = "HH:mm";
		private static readonly string _normalLicenseRegex = "^[a-ceg-ik-tv-z][a-z]{2}(-|)[\\d]{3,4}";
		public static readonly Regex regExNormalPlate = new Regex(_normalLicenseRegex, RegexOptions.IgnoreCase);
		private static readonly string _motorcycleLicenseRegex = "^[a-z][a-z][\\d]{3}[a-z]";
		public static readonly Regex regExMotorcyclePlate = new Regex(_motorcycleLicenseRegex, RegexOptions.IgnoreCase);
		private static readonly string _specialLicenseRegex = "^(cc|cd|oi|at|it)(-|)[\\d]{3,4}";
		public static readonly Regex regExSpecialPlate = new Regex(_specialLicenseRegex, RegexOptions.IgnoreCase);
		private static readonly string _publicLicenseRegex = "^[a-ceg-ik-tv-z][aemuxz][a-z](-|)[\\d]{3,4}";
		public static readonly Regex regExPublicPlate = new Regex(_publicLicenseRegex, RegexOptions.IgnoreCase);
		#endregion

		/// <summary>
		/// Validates if a license plate is valid according to Ecuador's standards
		/// </summary>
		public static bool IsLicensePlateValid(string licensePlate)
		{			
			bool isValid = regExNormalPlate.IsMatch(licensePlate) || regExMotorcyclePlate.IsMatch(licensePlate) || 
				regExSpecialPlate.IsMatch(licensePlate);
			return isValid;
		}

		public static bool StringToDateOrTime(string dateTime, bool isDate, out DateTime convertedDateOrTime)
		{
			bool isValid = DateTime.TryParseExact(dateTime, isDate ? dateFormat : timeFormat, null, DateTimeStyles.AssumeLocal, out convertedDateOrTime);
			return isValid;
		}		
	}
}