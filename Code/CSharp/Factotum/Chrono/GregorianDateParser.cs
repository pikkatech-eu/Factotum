/***********************************************************************************
* File:         GregorianDateParser.cs                                             *
* Contents:     Class GregorianDateParser                                          *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-20 18:59                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Text.RegularExpressions;
using Factotum.Chrono.Enumerations;

namespace Factotum.Chrono
{
	/// <summary>
	/// Contains methods to parse date string into valid instances of GregorianDate supporting a range of curent date formats.
	/// </summary>
	public static class GregorianDateParser
	{
		private static readonly Regex RX_YMD = new Regex(@"^\d{4}");

		/// <summary>
		/// We only support the YMD format in this version, the other two are messy 
		/// (you cannon tell what 05/06/2006 is, the 5th of May or the 6th of June).
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		private static GregorianDateFormat GetDateFormat(string source)
		{
			source	= source.Trim();

			if (source.StartsWith("~"))
			{
				source = source.Substring(1);
			}

			if (RX_YMD.IsMatch(source))
			{
				return GregorianDateFormat.YearMonthDay;
			}
			else
			{
				return GregorianDateFormat.Unknown;
			}
		}

		public static GregorianDate Parse(string source)
		{
			GregorianDateFormat format = GetDateFormat(source);

			if (format == GregorianDateFormat.YearMonthDay)
			{
				return ParseYmd(source);
			}
			else
			{
				throw new FormatException("Date string is in unsupported format");
			}
		}

		/// <summary>
		/// Does not support months expreassed with words, at the moment.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		private static GregorianDate ParseYmd(string source)
		{
			source	= source.Trim();

			bool isExact	= true;

			if (source.StartsWith("~"))
			{
				source = source.Substring(1);

				isExact = false;
			}

			char separator = '-';

			if (source.Contains("/"))
			{
				separator = '/';
			}

			if (source.Contains("."))
			{
				separator = '.';
			}

			string[] cells = source.Split(separator);

			for (int i = 0; i < cells.Length; i++)
			{
				cells[i]	= cells[i].Trim();
			}

			switch (cells.Length)
			{
				case 1:	// year only
					return new GregorianDate(Int32.Parse(cells[0]), isExact);

				case 2:	// year and month
					return new GregorianDate(Int32.Parse(cells[0]), Int32.Parse(cells[1]), isExact);

				case 3:	// year, month, day
					return new GregorianDate(Int32.Parse(cells[0]), Int32.Parse(cells[1]), Int32.Parse(cells[2]), isExact);

				default:
					return GregorianDate.Unknown;
			}
		}
	}
}
