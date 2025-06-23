/***********************************************************************************
* File:         GregorianDateFormat.cs                                             *
* Contents:     Enum GregorianDateFormat                                           *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-20 19:03                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Factotum.Chrono.Enumerations
{
	/// <summary>
	/// Defines the group of the Gregorian Date format.
	/// https://en.wikipedia.org/wiki/Calendar_date#Date_format
	/// </summary>
	public enum GregorianDateFormat
	{
		/// <summary>
		/// A.k.a. DMY.
		/// </summary>
		/// <example>
		///		9 November 2006 or 9. November 2006
		///		9/11/2006 or 09/11/2006
		///		09.11.2006 or 9.11.2006
		///		9. 11. 2006
		///		9-11-2006 or 09-11-2006
		/// </example>
		DayMonthYear,

		/// <summary>
		/// A.k.a YMD.
		/// </summary>
		/// <example>
		///		2003-11-09 (ISO)
		///		2003 November 9
		///		2003Nov9 or 2003Nov09
		///		2003-Nov-9 or 2003-Nov-09
		///		2003.11.09
		///		2003/11/09 or 2003/11/9
		/// </example>
		YearMonthDay,

		/// <summary>
		/// A.k.a MDY.
		/// </summary>
		/// <example>
		///		November 9, 2006
		///		Nov 9, 2006
		///		Nov-9-2006
		///		Nov-09-2006
		///		11/9/2006 or 11/09/2006
		///		11-09-2006 or 11-9-2006
		///		11.09.2006 or 11.9.2006
		/// </example>
		MonthDayYear,

		/// <summary>
		/// Unsupported or wrong date format.
		/// </summary>
		Unknown
	}
}
