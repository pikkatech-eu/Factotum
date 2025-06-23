/***********************************************************************************
* File:         TriadicDate.cs                                                     *
* Contents:     Class TriadicDate                                                  *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-19 14:58                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factotum.Chrono
{
	public abstract class TriadicDate : IFuzzyDate
	{
		#region Properties
		/// <summary>
		/// Exactness / Fuzziness.
		/// </summary>
		public bool IsExact		{get;set;}	= true;

		/// <summary>
		/// The year. 
		/// If set to null, the value of the date is considered unknown.
		/// Default value = null.
		/// </summary>
		public int?	Year		{get;set;}	= null;

		/// <summary>
		/// The month of the year, 1-base..
		/// If set to null, the month is unknown.
		/// </summary>
		public int?	Month		{get;set;}	= null;

		/// <summary>
		/// The day of the month, 1-based.
		/// If set to null, the month is unknown.
		/// </summary>
		public int?	Day			{get;set;}	= null;
		#endregion

		#region Construction
		/// <summary>
		/// Full data constructor.
		/// Creates a triadic date, exact or fuzzy, with the defined values of year, month, and day.
		/// </summary>
		/// <param name="year">The year.</param>
		/// <param name="month">The month.</param>
		/// <param name="day">The day.</param>
		/// <param name="isExact">Exactness / Fuzziness.</param>
		public TriadicDate(int year, int month, int day, bool isExact = true)
		{
			this.IsExact = isExact;
			this.Year = year;
			this.Month = month;
			this.Day = day;
		}

		/// <summary>
		/// Triadic year-and-month constructor.
		/// Creates a triadic date, exact or fuzzy, with unknown day of the month.
		/// </summary>
		/// <param name="year">The year.</param>
		/// <param name="month">The month.</param>
		public TriadicDate(int year, int month, bool isExact = true)
		{
			this.IsExact = isExact;
			this.Year = year;
			this.Month = month;
		}

		/// <summary>
		/// Triadic year only constructor.
		/// Creates a triadic date, exact or fuzzy, with unknown month of the year and day of the month.
		/// </summary>
		/// <param name="year">The year.</param>
		public TriadicDate(int year, bool isExact = true)
		{
			this.IsExact = isExact;
			this.Year = year;
		}

		/// <summary>
		/// Unknown date constructor.
		/// Creates a triadic date, exact, with the unknown values of year, month, and day.
		/// </summary>
		public TriadicDate()
		{
			this.Year = null;
		}
		#endregion
	}
}
