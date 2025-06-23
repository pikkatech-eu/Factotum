/***********************************************************************************
* File:         Polynomial.cs                                                      *
* Contents:     Class Polynomial                                                   *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2024-10-19 20:31                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Collections.Generic;
using System.Linq;

namespace Factotum.Maths
{
	/// <summary>
	/// Describes a real polynomial.
	/// \f$ P(x) = a_0 + a_1  x + a_2  x^2 + ... + a_n x^n \f$
	/// </summary>
	public class Polynomial
	{
		#region Properties
		/// <summary>
		/// The degree of the polynomial.
		/// </summary>
		public	int			Degree			{get;set;} = 0;

		/// <summary>
		/// The coefficients of the polynomial.
		/// </summary>
		public	double[]	Coefficients	{get; internal set;} = null;
		#endregion

		#region Construction
		/// <summary>
		/// Data constructor.
		/// Creates a polynomial from a collection of real values taken as the coefficients.
		/// </summary>
		/// <param name="coefficients">The coefficients of the polynomial from a_0 to a_n.</param>
		public Polynomial(IEnumerable<double> coefficients)
		{
			if (coefficients.Count() == 0)
			{
				return;
			}

			this.Degree			= coefficients.Count()  - 1;
			this.Coefficients	= coefficients.ToArray();
		}

		/// <summary>
		/// Parametric data constructor.
		/// Creates a polynomial from a collection of a parametric array of real values taken as the coefficients.
		/// </summary>
		/// <param name="coefficients">The coefficients of the polynomial from a_0 to a_n.</param>
		public Polynomial(params double[] coefficients)
		{
			if (coefficients.Length == 0)
			{
				return;
			}

			this.Degree			= coefficients.Length - 1;
			this.Coefficients	= coefficients;
		}

		/// <summary>
		/// Seeding constructor.
		/// Creates a polynomial of a given degree with all coefficients equal to a defined value.
		/// </summary>
		/// <param name="degree">The degree of the polynomial.</param>
		/// <param name="value">The value to seed with (default 0).</param>
		public Polynomial(int degree, double value = 0)
		{
			if (degree <= 0)
			{
				return;
			}

			this.Degree = degree;
			this.Coefficients = new double[degree + 1];

			for (int i = 0; i < this.Coefficients.Length; i++)
			{
				this.Coefficients[i] = value;
			}
		}

		/// <summary>
		/// Copying constructor.
		/// Creates a deep copy of an existing polynomial.
		/// </summary>
		/// <param name="polynomial">The polynomial to copy.</param>
		public Polynomial(Polynomial polynomial)
		{
			if (!polynomial.IsValid())
			{
				return;
			}

			this.Degree = polynomial.Degree;

			for (int i = 0; i < polynomial.Coefficients.Length; i++)
			{
				this.Coefficients[i] = polynomial.Coefficients.Length;
			}
		}

		/// <summary>
		/// Default constructor.
		/// Creates a zero-degree polynomial with the value of a_0 equal to zero.
		/// </summary>
		public Polynomial()
		{
			this.Degree = 0;
			this.Coefficients = new double[1];
			this.Coefficients[0] = 0;
		}
		#endregion

		#region Validation
		/// <summary>
		/// Validation concept.
		/// A polynomial is valid if its degree is greater or equal to tero and the coefficient array is not null.
		/// </summary>
		/// <returns></returns>
		public bool IsValid()
		{
			return this.Degree >= 0 && this.Coefficients != null;
		}
		#endregion

		#region Calculations
		/// <summary>
		/// Calculates the value of the polynomial for a given value of argument.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The value of the polynomial.</returns>
		public double Value(double x)
		{
			if (this.Degree == 0)
			{
				return this.Coefficients[0];
			}

			double value	= x * this.Coefficients[this.Degree] + this.Coefficients[this.Degree - 1];

			for (int i = this.Degree - 2; i >= 0; i--)
			{
				value	= x * value + this.Coefficients[i];
			}

			return value;
		}
		#endregion
	}
}
