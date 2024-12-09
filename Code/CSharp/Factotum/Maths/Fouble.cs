/***********************************************************************************
* File:         Fouble.cs                                                          *
* Contents:     Class Fouble                                                       *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2024-12-09 16:50                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;

namespace Factotum.Maths
{
	/// <summary>
	/// Fouble == "Fuzzy Double".
	/// </summary>
	public class Fouble
	{
		#region Properties
		/// <summary>
		/// The double value.
		/// </summary>
		public	double	Value	{get;set;}	= 0;

		/// <summary>
		/// Exactness: true if the value is exact, false if it is fuzzy, i.e. non-exact.
		/// </summary>
		public	bool	IsExact	{get;set;}	= true;
		#endregion

		#region Construction

		/// <summary>
		/// Value constructor.
		/// Creates a fouble from defined arguments.
		/// </summary>
		/// <param name="value">The value of the fouble.</param>
		/// <param name="isExact">the exactness.</param>
		public Fouble(double value, bool isExact = true)
		{
			this.Value		= value;
			this.IsExact	= isExact;
		}

		/// <summary>
		/// Default constructor.
		/// Creates eine instance of Fouble with Value = 0 and IsExact = true;
		/// </summary>
		internal Fouble()	{}

		/// <summary>
		/// Implicit conversion of a double to a Fouble.
		/// Creates an instance of Fouble with the defined double value and isExact = true.
		/// </summary>
		/// <param name="value">The defined double.</param>
		public static implicit operator Fouble(double value)						=> new Fouble(value);

		/// <summary>
		/// Implicit conversion of a Fouble into double.
		/// Creates a double value equal to that in the Fouble.
		/// </summary>
		/// <param name="f"></param>
		public static implicit operator double(Fouble f)							=> f.Value;

		/// <summary>
		/// Implicit conversion of a pair of a double and a Boolean to Fouble.
		/// </summary>
		/// <param name="pair">The pair of double and Boolean to convert.</param>
		public static implicit operator Fouble((double value, bool isExact) pair)	=> new Fouble(pair.value, pair.isExact);
		#endregion

		#region String representation
		public override string ToString()
		{
			string suffix = this.IsExact ? "" : "F";
			return $"{this.Value}{suffix}";
		}

		public static Fouble Parse(string text)
		{
			try
			{
				Fouble f = new Fouble();

				if (text.Trim().EndsWith("F"))
				{
					f.IsExact = false;
				}

				f.Value	= Double.Parse(text.Trim().TrimEnd('F'));

				return f;
			}
			catch (ArgumentException)
			{
				throw;
			}
		}

		public static bool TryParse(string text, out Fouble f)
		{
			try
			{
				f = Fouble.Parse(text);
				return true;
			}
			catch (Exception)
			{
				f = null;
				return false;
			}
		}
		#endregion
	}
}
