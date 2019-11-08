using System;
using System.Collections.Generic;

namespace PicoYPlaca.Util.Models
{
	public class PicoYPlacaRule
	{
		public string DayOfWeek { get; set; }
		public List<int> PlateLastNumbers { get; set; }

		//Here we can modify the time ranges
		public static readonly TimeSpan DayMinTime = new TimeSpan(7, 0, 0);
		public static readonly TimeSpan DayMaxTime = new TimeSpan(9, 30, 0);
		public static readonly TimeSpan AfterNoonMinTime = new TimeSpan(16, 0, 0);
		public static readonly TimeSpan AfterNoonMaxTime = new TimeSpan(19, 30, 0);

		//Here we can Add/Modify the rules of the Pico y Placa Days
		private static readonly List<PicoYPlacaRule> _picoYPlacaRules =
			new List<PicoYPlacaRule> 
			{ 
				new PicoYPlacaRule { DayOfWeek = "Monday", PlateLastNumbers = new List<int> { 1, 2 } },
				new PicoYPlacaRule { DayOfWeek = "Tuesday", PlateLastNumbers = new List<int> { 3, 4 } },
				new PicoYPlacaRule { DayOfWeek = "Wednesday", PlateLastNumbers = new List<int> { 5, 6 } },
				new PicoYPlacaRule { DayOfWeek = "Thursday", PlateLastNumbers = new List<int> { 7, 8 } },
				new PicoYPlacaRule { DayOfWeek = "Friday", PlateLastNumbers = new List<int> { 9, 0 } }
			};

		public static List<PicoYPlacaRule> GetPicoYPlacaRules()
		{
			return _picoYPlacaRules;
		}
	}
}
