/***********************************************************************************
* File:         Temporal.cs                                                        *
* Contents:     Class Temporal                                                     *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-19 20:40                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;

namespace Factotum.Chrono
{
	public class Temporal
	{
		#region Static private members
        private static Temporal _indefinite = new Temporal();
        #endregion

		#region Properties
        /// <summary>
        /// Start of the time interval.
        /// </summary>
        public GregorianDate Start  {get;internal set;} = null;

        /// <summary>
        /// End of the time interval.
        /// </summary>
        public GregorianDate End    {get;internal set;} = null;

        /// <summary>
        /// Gets the Indefinite Temporal.
        /// </summary>
        public static Temporal Indefinite {get{return _indefinite;}}
        #endregion

		#region Construction
        /// <summary>
        /// Internal constructor. Creates an indefinite instance of Temporal.
        /// </summary>
        internal Temporal()
        {
        }

        /// <summary>
        /// Internal interval constructor.
        /// Creates an instance of Temporal with defined values of Start and End.
        /// </summary>
        /// <param name="start">The value of Start (can be null).</param>
        /// <param name="end">The value of End (can be null).</param>
        internal Temporal(GregorianDate start, GregorianDate end)
        {
            this.Start          = start;
            this.End            = end;
        }

        /// <summary>
        /// Closed interval constructor.
        /// Creates an instance of Temporal for a closed interval with defined and non-null values of Start and End.
        /// </summary>
        /// <param name="start">The value of Start (may not be null).</param>
        /// <param name="end">The value of End (may not be null).</param>
        /// <returns>An interval value of Temporal.</returns>
        /// <exception cref="ArgumentException">Thrown if one of the IDate values is null.</exception>
        public static Temporal CreateClosedIterval(GregorianDate start, GregorianDate end)
        {
            if (start == null || end == null)
            {
                throw new ArgumentException("One of the IDate arguments is null");
            }

            Temporal result = new Temporal(start, end);

            return result;
        }

        /// <summary>
        /// Past interval constructor.
        /// Creates an instance of Temporal for an interval open from left (i.e. describing the time before a date)
        /// </summary>
        /// <param name="value">The value of closing time (may not be null).</param>
        /// <returns>An interval-before value of Temporal.</returns>
        /// <exception cref="ArgumentException">Thrown if the IDate value is null.</exception>
        public static Temporal CreateIntervalBefore(GregorianDate value)
        {
            if (value == null)
            {
                throw new ArgumentException("The IDate arguments must not ne null");
            }

            Temporal result = new Temporal(null, value);

            return result;
        }

        /// <summary>
        /// Future interval constructor.
        /// Creates an instance of Temporal for an interval open from right (i.e. describing the time after a date)
        /// </summary>
        /// <param name="value">The value of opening time (may not be null).</param>
        /// <returns>An interval-after value of Temporal.</returns>
        /// <exception cref="ArgumentException">Thrown if the IDate value is null.</exception>
        public static Temporal CreateIntervalAfter(GregorianDate value)
        {
            if (value == null)
            {
                throw new ArgumentException("The IDate arguments must not ne null");
            }

            Temporal result = new Temporal(value, null);

            return result;
        }

        /// <summary>
        /// Creates an instance of Temporal that describes a time instant (within reasonable precision).
        /// </summary>
        /// <param name="value">The value of time (may not be null).</param>
        /// <returns>An istant value of Temporal.</returns>
        /// <exception cref="ArgumentException">Thrown if the IDate value is null.</exception>
        public static Temporal CreateInstant(GregorianDate value)
        {
            if (value == null)
            {
                throw new ArgumentException("The IDate arguments must not ne null");
            }

            Temporal result = new Temporal(value, value);

            return result;
        }
		#endregion

		#region Public Features
		public bool IsClosedInterval()
		{
			return this.Start != null && this.End != null;
		}

		/// <summary>
		/// Checks if the Temporal is a time instant.
		/// </summary>
		/// <returns>True, if the condition holds.</returns>
		public bool IsInstant()
        {
			if (!this.IsClosedInterval())
			{
				return false;
			}

			return this.Start.Equals(this.End);
        }

		public bool IsIntervalBefore()
		{
			return this.Start == null && this.End != null;
		}

		public bool IsIntervalAfter()
		{
			return this.Start != null && this.End == null;
		}

		#endregion

		#region String Representation
		public string ToString(string format)
		{
			if (this.IsInstant())
			{
				return this.Start.ToString(format);
			}
			else if (this.IsClosedInterval())
			{
				return $"{this.Start.ToString(format)}--{this.End.ToString(format)}";
			}
			else if (this.IsIntervalBefore())
			{
				return $"--{this.End.ToString(format)}";
			}
			else if (this.IsIntervalAfter())
			{
				return $"{this.Start.ToString(format)}--";
			}
			else
			{
				return "Indefinite temporal";
			}
		}

		public override string ToString()
		{
			return this.ToString("ISO");
		}

		public static Temporal Parse(string source)
		{
			string[] cells = source.Split(new string[]{"--"}, StringSplitOptions.None);

			for (int i = 0; i < cells.Length; i++)
			{
				cells[i]	= cells[i].Trim();
			}

			switch (cells.Length)
			{
				case 1:
					return CreateInstant(GregorianDate.Parse(cells[0]));

				case 2:
					if (cells[0].Length == 0)
					{
						return CreateIntervalBefore(GregorianDate.Parse(cells[1]));
					}
					else if (cells[1].Length == 0)
					{
						return CreateIntervalAfter(GregorianDate.Parse(cells[0]));
					}
					else 
					{
						return CreateClosedIterval(GregorianDate.Parse(cells[0]), GregorianDate.Parse(cells[1]));
					}

				default:
					return Temporal.Indefinite;
			}
		}

		public bool TryParse(string dateString, out Temporal temporal)
		{
			try
			{
				temporal = Parse(dateString);
				
				return true;
			}
			catch (Exception)
			{
				temporal = Temporal.Indefinite;
				return false;
			}
		}
		#endregion
	}
}
