/***********************************************************************************
* File:         Fouble.cs                                                          *
* Contents:     Class Fouble                                                       *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2024-12-09 16:50                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Xml.Linq;
using Factotum.Xml;

namespace Factotum.Maths.Fuzzy
{
	/// <summary>
	/// Fouble == "Fuzzy Double".
	/// </summary>
	public class Fouble
	{
		#region Private Pseudoconstants
		/// <summary>
		/// All pseudoconstants are defined as exact.
		/// </summary>
		private static readonly Fouble _zero				= 0;
		private static readonly Fouble _nan					= Double.NaN;
		private static readonly Fouble _positiveInfinity	= Double.PositiveInfinity;
		private static readonly Fouble _negativeInfinity	= Double.NegativeInfinity;
		#endregion

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
		public static implicit operator Fouble(double value)	=> new Fouble(value);

		/// <summary>
		/// Implicit conversion of a Fouble into double.
		/// Creates a double value equal to that in the Fouble.
		/// </summary>
		/// <param name="f"></param>
		public static implicit operator double(Fouble f)		=> f.Value;

		/// <summary>
		/// Implicit conversion of a pair of a double and a Boolean to Fouble.
		/// </summary>
		/// <param name="pair">The pair of double and Boolean to convert.</param>
		public static implicit operator Fouble((double value, bool isExact) pair)	=> new Fouble(pair.value, pair.isExact);

		/// <summary>
		/// Implicit conversion of a fuzzy integer to fuzzy double.
		/// </summary>
		/// <param name="fint"></param>
		public static implicit operator Fouble(Fint fint)	=> new Fouble(fint.Value, fint.IsExact);

		/// <summary>
		/// Explicit conversion of a fuzzy double to fuzzy integer.
		/// </summary>
		/// <param name="f"></param>
		public static explicit operator Fint(Fouble f)	=> new Fint((int)f.Value, f.IsExact);
		#endregion

		#region String representation
		public override string ToString()
		{
			return this.IsExact ? this.Value.ToString() : $"~{this.Value}";
		}

		public static Fouble Parse(string text)
		{
			try
			{
				Fouble f = new Fouble();

				if (text.Trim().StartsWith("~"))
				{
					f.IsExact = false;
				}

				f.Value	= double.Parse(text.Trim().TrimStart('~'));

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
		/// Addition of foubles.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Fuzzy sum; exact only if both opwerands are exact.</returns>
		public static Fouble operator + (Fouble x, Fouble y)
		{
			return new Fouble(x.Value + y.Value, x.IsExact && y.IsExact);
		}

		/// <summary>
		/// Subtraction of foubles.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Fuzzy difference; exact only if both opwerands are exact.</returns>
		public static Fouble operator - (Fouble x, Fouble y)
		{
			return new Fouble(x.Value - y.Value, x.IsExact && y.IsExact);
		}

		/// <summary>
		/// Multiplication of foubles.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Fuzzy product; exact only if both opwerands are exact.</returns>
		public static Fouble operator * (Fouble x, Fouble y)
		{
			return new Fouble(x.Value * y.Value, x.IsExact && y.IsExact);
		}

		/// <summary>
		/// Division of foubles.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Fuzzy ratio; exact only if both opwerands are exact.</returns>
		public static Fouble operator / (Fouble x, Fouble y)
		{
			return new Fouble(x.Value / y.Value, x.IsExact && y.IsExact);
		}

		public static Fouble operator - (Fouble x)
		{
			return new Fouble(-x.Value, x.IsExact);
		}
		#endregion

		#region Pseudoconstants
		public static Fouble Zero				{get {return _zero;}}
		public static Fouble NaN				{get {return _nan;}}
		public static Fouble PositiveInfinity	{get {return _positiveInfinity;}}
		public static Fouble NegativeInfinity	{get {return _negativeInfinity;}}
		#endregion

		#region XML
		public XElement ToXElement()
		{
			return new XElement("Fouble", new XAttribute("Value", this.Value), new XAttribute("IsExact", this.IsExact));
		}

		public static Fouble FromXElement(XElement x)
		{
			Fouble f	= new Fouble();

			f.Value		= x.AttributeValue<double>("Value");
			f.IsExact	= x.AttributeValue<bool>("IsExact");

			return f;
		}
		#endregion
	}
}
