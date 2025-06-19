/***********************************************************************************
* File:         GregorianDate.cs                                                   *
* Contents:     Class GregorianDate                                                *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-19 15:01                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Factotum.Chrono
{
	public class GregorianDate : TriadicDate
	{
		public static readonly string[] GREGORIAN_MONTHS = {"January",  "February",  "March",  "April",  "May",  "June",  
															"July",  "August",  "September",  "October",  "November",  "December"};
		#region Construction
		public GregorianDate(int year, int month, int day, bool isExact = true) : base(year, month, day, isExact)	{}
		public GregorianDate(int year, int month, bool isExact = true) : base(year, month, isExact)	{}
		public GregorianDate(int year, bool isExact = true) : base(year, isExact)	{}
		public GregorianDate() : base()	{}
		public GregorianDate(GregorianDate gregorian)
		{
			this.Year		= gregorian.Year;
			this.Month		= gregorian.Month;
			this.Day		= gregorian.Day;
			this.IsExact	= gregorian.IsExact;
		}

		public GregorianDate(DateTime dateTime)	: this(dateTime.Year, dateTime.Month, dateTime.Day)	{}

		public static implicit  operator GregorianDate(DateTime dateTime)
		{
			return new GregorianDate(dateTime);
		}

		public static implicit operator DateTime(GregorianDate gregorian)
		{
			if (!gregorian.IsComplete())
			{
				throw new ArgumentException("Gregorian date incomplete");
			}

			try
			{
				return new DateTime((int)gregorian.Year, (int)gregorian.Month, (int)gregorian.Day);
			}
			catch (Exception)
			{
				// invalid value in gregorian, e.g. Month = 13 etc.
				throw;
			}
		}
		#endregion

		#region Pseudoconstants
		public static readonly GregorianDate Unknown = new GregorianDate();
		#endregion

		#region Completeness
		public bool IsComplete()
		{
			return this.Year != null && this.Month != null && this.Day != null;
		}
		#endregion

		#region Comparison
		public override bool Equals(object obj)
		{
			if (obj is GregorianDate)
			{
				GregorianDate gregorian = obj as GregorianDate;

				return this.Year	== gregorian.Year && 
					   this.Month	== gregorian.Month && 
					   this.Day		== gregorian.Day && 
					   this.IsExact	== gregorian.IsExact;
			}
			else
			{
				return base.Equals(obj);
			}
		}
		#endregion

		#region String Representation
		/// <summary>
		/// String output-
		/// In current version, only English month names are supported.
		/// </summary>
		/// <param name="format">
		/// Supported values:
		///		"ISO"			: output in ISO format, e.g. "1990-12-05", "1990-12", "1990"
		///		"DD.MM.YYYY"	: output in continental format, e.g. "1990.12.05", , "1990.12"
		///		"DD.MMMM.YYYY"	: output with month names, e.g. "05 December 1990", "December 1990"
		///		"MM/DD/YYYY"	: output in US format, e.g. "12/05/1990", "12/1990".
		/// </param>
		/// <returns>
		///		The string representation of the Gregorian date, if the format is supported, otherwise null.
		/// </returns>
		public string ToString(string format)
		{
			if (this == GregorianDate.Unknown)
			{
				return "Unknown Gregorian date";
			}

			string yearString	= this.Year != null  ? $"{this.Year}" : null;
			string monthString	= this.Month != null ? $"{this.Month:00}" : null;
			string dayString	= this.Day != null   ? $"{(int)this.Day:00}" : null;

			string result = null;

			switch (format.ToUpper())
			{
				case "ISO":
					if (monthString != null && dayString != null)
					{
						result = $"{yearString}-{monthString}-{dayString}";
					}
					else if (monthString != null)
					{
						result = $"{yearString}-{monthString}";
					}
					else
					{
						result = $"{yearString}";
					}

					break;

				case "DD.MM.YYYY":
					if (monthString != null && dayString != null)
					{
						result = $"{dayString}.{monthString}.{yearString}";
					}
					else if (monthString != null)
					{
						result = $"{monthString}.{yearString}";
					}
					else
					{
						result = $"{yearString}";
					}

					break;

				case "DD.MMMM.YYYY":
					if (monthString != null && dayString != null)
					{
						result = $"{dayString} {GREGORIAN_MONTHS[(int)this.Month]} {yearString}";
					}
					else if (monthString != null)
					{
						result = $"{GREGORIAN_MONTHS[(int)this.Month]} {yearString}";
					}
					else
					{
						result = $"{yearString}";
					}

					break;

				case "MM/DD/YYYY":
					if (monthString != null && dayString != null)
					{
						result = $"{monthString}/{dayString}/{yearString}";
					}
					else if (monthString != null)
					{
						result = $"{monthString}/{yearString}";
					}
					else
					{
						result = $"{yearString}";
					}

					break;

				default:
					break;
			}

			if (!this.IsExact && result != null)
			{
				result = $"~{result}";
			}

			return result;
		}

		public override string ToString()
		{
			return this.ToString("ISO");
		}

		/// <summary>
		/// Parses a string to a GregorianDate.
		/// </summary>
		/// <param name="dateString">
		///		In current version, only English month names are supported.
		///		The string must be in one of the following formats: 
		///			"ISO"				
		/// 		"DD.MM.YYYY"	
		/// 		"DD.MMMM.YYYY"	
		/// 		"MM/DD/YYYY"
		///		(see description with ToString()).
		/// </param>
		/// <returns></returns>
		public static GregorianDate Parse(string dateString)
		{
			try
			{
				DateTime dateTime = DateTime.Parse(dateString);
				return new GregorianDate(dateTime);
			}
			catch (Exception)
			{
				string[] items = new string[0];

				if (dateString.Contains("-"))
				{
					items = dateString.Split('-');
				}
				else if (dateString.Contains("/"))
				{
					items = dateString.Split('/');
				}
				else
				{
					items = new string[]{ dateString.Trim() };
				}

				if (items.Length == 1)
				{
					// year only
					return new GregorianDate(Int32.Parse(items[0]));
				}
				else if (items.Length == 2)
				{
					if (items[0].Length > items[1].Length)
					{
						return new GregorianDate(Int32.Parse(items[0]), Int32.Parse(items[1]));
					}
					else
					{
						return new GregorianDate(Int32.Parse(items[1]), Int32.Parse(items[0]));
					}
				}
				else
				{
					return GregorianDate.Unknown;
				}
			}
		}

		/// <summary>
		/// Tries to parse a string to a Gregogian date.
		/// </summary>
		/// <param name="dateString"></param>
		/// <param name="gregorian"></param>
		/// <returns></returns>
		public bool TryParse(string dateString, out GregorianDate gregorian)
		{
			try
			{
				gregorian = Parse(dateString);

				return true;
			}
			catch (Exception)
			{
				gregorian = GregorianDate.Unknown;
				return false;
			}
		}
		#endregion
	}
}
