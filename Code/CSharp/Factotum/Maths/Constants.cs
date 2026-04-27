/***********************************************************************************
* File:         Constants.cs                                                       *
* Contents:     Class containing                                                   *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2024-10-12 00:48                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Factotum.Maths
{
	/// <summary>
	/// Static class containing a few common mathematical, physical, and astronomical constants constants.
	/// Sources: Abramowitz & Steagun.
	/// http://books.google.de/books?hl=de&lr=&id=MtU8uP7XMvoC&oi=fnd&pg=PR4&dq=abramowitz+and+stegun+mathematical+constants&ots=-CTJJnL5Hi&sig=ux992ySG8oCKAtCOjrn_H2omY1U#v=onepage&q=&f=false
	/// http://www.nrbook.com/abramowitz_and_stegun/page_5.htm
	/// </summary>
	public static class Constants
	{
		#region Mathematical constants
		public const double SQRT2 				= 1.4142135623730950488;
		public const double SQRT3 				= 1.7320508075688772935;
		public const double SQRT5 				= 2.2360679774997896964;
		public const double SQRT7 				= 2.6457513110645905905;
		public const double SQRT10 				= 3.1622776601683793320;

		public const double ONE_OVER_SQRT2 		= 0.7071067811865475244;
		public const double ONE_OVER_SQRT3 		= 0.5773502691896257484;
		public const double ONE_OVER_SQRT5 		= 0.4472135954999579517;
		public const double ONE_OVER_SQRT7 		= 0.3779644730092272167;
		public const double ONE_OVER_SQRT10		= 0.3162277660168379332;


		public const double PI					= 3.141592653589793238462643;   // 180°
		public const double PI_OVER2			= 1.570796326794896619231322;   //  90°
		public const double PI_OVER3			= 1.047197551196597746154214;   //	60°
		public const double PI_OVER4			= 0.7853981633974483096156608;  //	45°
		public const double PI_OVER6			= 0.5235987755982988156;        // 30°
		public const double PI_OVER12			= 0.2617993877991494078;        // 15°
		public const double TWO_PI				= 6.283185307179586476925286;	// 360°


		public const double ONE_OVER_PI			= 0.318309886183790671537767;	// 1/Pi
		public const double ONE_OVER_TWO_PI		= 0.159154943091895335768883;	// 1/(2*Pi)
		public const double ONE_OVER_SQRT_PI 	= 0.5641895835477562869480795;
		public const double ONE_OVER_SQRT_2PI	= 0.3989422804014326779399461;
		public const double RADIAN				= 57.295779513082320876798155;
		public const double DEGREE				= 0.017453292519943295769237;

		public const double E					= 2.718281828459045235360287;
		public const double GAMMA				= 0.577215664901532860606512;
		public const double GOLDEN_RATIO		= 1.6180339887498948482045868343656;
		#endregion

		#region Astronomical constants
		/// <summary>
		/// Earth Radius (km), Abramowitz & Stegun, Table 2.6, p.8 (middle value of the half-axes).
		/// </summary>
		public const double EARTH_RADIUS		= 6367.650;

		/// <summary>
		/// Tropical year is 365.2422 days (365d, 5h, 48min, 46s)
		/// </summary>
		public const double MEAN_TROPICAL_YEAR	= 365.242189;

		/// <summary>
		/// Moon month is 29.53059 days (29d, 12h, 44min, 2.9 s)
		/// </summary>
		public const double MOON_MONTH			= 29.53059;
	
		/// <summary>
		/// Moon phase is 7.38265 days
		/// </summary>
		public const double MOON_PHASE			= 7.38265;
		#endregion

		#region Computation-related
		/// <summary>
		/// A reasonably small number to use when checking division.
		/// </summary>
		public const double EPSILON						= 1e-38;
		public const int    DEFAULT_MAX_ITERATIONS      = 100;
		public const double DEFAULT_BRACKETING_FACTOR	= 0.6180339887498948482045868343656;

		#endregion
	}
}
