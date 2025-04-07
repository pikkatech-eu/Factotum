/***********************************************************************************
* File:         Fint.cs                                                            *
* Contents:     Class Fint                                                         *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-04-07 22:08                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;

namespace Factotum.Maths.Fuzzy
{
	/// <summary>
	/// Fint == "Fuzzy Integer".
	/// </summary>
    public class Fint
    {
		#region Properties
		/// <summary>
		/// The double value.
		/// </summary>
		public	int	Value	{get;set;}	= 0;

		/// <summary>
		/// Exactness: true if the value is exact, false if it is fuzzy, i.e. non-exact.
		/// </summary>
		public	bool	IsExact	{get;set;}	= true;
		#endregion

		#region Construction
		/// <summary>
		/// Value constructor.
		/// Creates a Fint from defined arguments.
		/// </summary>
		/// <param name="value">The value of the fouble.</param>
		/// <param name="isExact">the exactness.</param>
		public Fint(int value, bool isExact = true)
		{
			this.Value		= value;
			this.IsExact	= isExact;
		}

		/// <summary>
		/// Default constructor.
		/// Creates eine instance of Fint with Value = 0 and IsExact = true;
		/// </summary>
		internal Fint()	{}

		/// <summary>
		/// Implicit conversion of an int to a Fint.
		/// Creates an instance of Fint with the defined integer value and isExact = true.
		/// </summary>
		/// <param name="value">The defined integer.</param>
		public static implicit operator Fint(int value)	=> new Fint(value);

		

		/// <summary>
		/// Implicit conversion of a Fint into int.
		/// Creates an integer value equal to that in the Fint.
		/// </summary>
		/// <param name="f"></param>
		public static implicit operator int(Fint f)		=> f.Value;

		

		/// <summary>
		/// Implicit conversion of a pair of an integer and a Boolean to Fint.
		/// </summary>
		/// <param name="pair">The pair of int and Boolean to convert.</param>
		public static implicit operator Fint((int value, bool isExact) pair)	=> new Fint(pair.value, pair.isExact);
		#endregion

		#region String representation
		public override string ToString()
		{
			return this.IsExact ? this.Value.ToString() : $"~{this.Value}";
		}

		public static Fint Parse(string text)
		{
			try
			{
				Fint f = new Fint();

				if (text.Trim().StartsWith("~"))
				{
					f.IsExact = false;
				}

				f.Value	= Int32.Parse(text.Trim().TrimStart('~'));

				return f;
			}
			catch (ArgumentException)
			{
				throw;
			}
		}

		public static bool TryParse(string text, out Fint f)
		{
			try
			{
				f = Parse(text);
				return true;
			}
			catch (Exception)
			{
				f = null;
				return false;
			}
		}
		#endregion

		#region Arithmetics
		/// <summary>
		/// Addition of Fints.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Fuzzy sum; exact only if both operands are exact.</returns>
		public static Fint operator + (Fint x, Fint y)
		{
			return new Fint(x.Value + y.Value, x.IsExact && y.IsExact);
		}

		/// <summary>
		/// Subtraction of Fints.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Fuzzy difference; exact only if both operands are exact.</returns>
		public static Fint operator - (Fint x, Fint y)
		{
			return new Fint(x.Value - y.Value, x.IsExact && y.IsExact);
		}

		/// <summary>
		/// Multiplication of Fints.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Fuzzy product; exact only if both operands are exact.</returns>
		public static Fint operator * (Fint x, Fint y)
		{
			return new Fint(x.Value * y.Value, x.IsExact && y.IsExact);
		}

		/// <summary>
		/// Division of Fints.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Fuzzy ratio; exact only if both opwerands are exact.</returns>
		public static Fint operator / (Fint x, Fint y)
		{
			return new Fint(x.Value / y.Value, x.IsExact && y.IsExact);
		}

		public static Fint operator - (Fint x)
		{
			return new Fint(-x.Value, x.IsExact);
		}
		#endregion
    }
}
