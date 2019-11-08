using PicoYPlaca.Util.Predictor;

namespace PicoYPlaca.Util.Models
{
	public class LicensePlate
	{
		public string LicensePlateNumber { get; set; }
		public bool IsSpecialPlate => InputValidator.regExSpecialPlate.IsMatch(LicensePlateNumber);
		public bool IsPublicPlate => InputValidator.regExPublicPlate.IsMatch(LicensePlateNumber);
		public bool IsMotorcyclePlate => InputValidator.regExMotorcyclePlate.IsMatch(LicensePlateNumber);
	}
}
