/***********************************************************************************
* File:         ElementaryFunctions.cs                                             *
* Contents:     Class ElementaryFunctions                                          *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2024-10-12 01:21                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;

namespace Factotum.Maths
{
	public static class ElementaryFunctions
	{
		#region Reingolg & Dershowitz - related.
		/// <summary>
		/// RDU (1.17): The	remainder, or modulus, of float numbers.
		/// </summary>
		/// <param name="x">The first operand</param>
		/// <param name="y">The second operand</param>
		/// <returns>The result of the operation.</returns>
		/// <example>fmod(9, 4) = 5; fmod(-9, 5) = 1; fmod(9, -5) = -1; fmod(-9, -5) = -4.</example>
		public static double Fmod(double x, double y)
		{
			return x - y * Math.Floor(x / y);
		}

		/// <summary>
		/// The Fmod function for integer arguments.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static double Fmod(int x, int y)
		{
			return Fmod((double)x, (double)y);
		}

		/// <summary>
		/// Calculates the whole part of a ratio.
		/// </summary>
		/// <param name="x">The dividend</param>
		/// <param name="y">The divisor</param>
		/// <returns>The result</returns>
		public static double Quotient(double x, double y)
		{
			return Math.Floor(x / y);
		}

		/// <summary>
		/// Calculates the whole part of a ratio as an integer number.
		/// </summary>
		/// <param name="x">The dividend</param>
		/// <param name="y">The divisor</param>
		/// <returns>The result</returns>
		public static int IntegerQuotient(double x, double y)
		{
			return (int)Quotient(x, y);
		}

		/// <summary>
		/// RDU (1.29): Adjusted Remainder, a "function like mod with its values adjusted in such a	way 
		/// that the modulus of	a multiple of the divisor is the divisor itself rather than 0".
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static double Amod(double x, double y)
		{
			return x + Fmod(x, -y);
		}
		#endregion

		#region Trigonometry
		/// <summary>
		/// Sine of an argument given in degrees. (Neither math nor numpy seem to have these simple functions).
		/// </summary>
		/// <param name="x">The argument in degrees</param>
		/// <returns>sin(x°)</returns>
		public static double Sind(double x)
		{
			return Math.Sin(Constants.DEGREE * x);
		}

		/// <summary>
		/// Cosine of an argument given in degrees. (Neither math nor numpy seem to have these simple functions).
		/// </summary>
		/// <param name="x">The argument in degrees</param>
		/// <returns>cos(x°)</returns>
		public static double Cosd(double x)
		{
			return Math.Cos(Constants.DEGREE * x);
		}

		/// <summary>
		/// Tangent of an argument given in degrees. (Neither math nor numpy seem to have these simple functions).
		/// </summary>
		/// <param name="x">The argument in degrees</param>
		/// <returns>tan(x°)</returns>
		public static double Tand(double x)
		{
			return Math.Tan(Constants.DEGREE * x);
		}

		/// <summary>
		/// Calculates the quadrant-sensitive value of arctan by both coordinates.
		/// Notice the order of argument different from the order in Math.Atan(y, x).
		/// </summary>
		/// <param name="x">The x coordinate (cos a).</param>
		/// <param name="y">The y coordinate (sin a).</param>
		/// <returns>The value of the angle, Radian.</returns>
		public static double Arctan(double x, double y)
		{
			double alpha0 = 0;

			if (Math.Abs(x) <= Constants.EPSILON)
			{
				alpha0 = Constants.PI_OVER2;
			}
			else
			{
				alpha0 = Math.Atan(Math.Abs(y) / Math.Abs(x));
			}

			if (x >= 0 && y >= 0)
			{
				return alpha0;
			}
			else if (x <= 0 && y >= 0)
			{
				return Constants.PI - alpha0;
			}
			else if (x <= 0 && y <= 0)
			{
				return Constants.PI + alpha0;
			}
			else
			{
				return Constants.TWO_PI - alpha0;
			}
		}

		/// <summary>
		/// Calculates the quadrant-sensitive degree value of arctan by both coordinates.
		/// Notice the order of argument different from the order in Math.Atan(y, x).
		/// </summary>
		/// <param name="x">The x coordinate (cos a).</param>
		/// <param name="y">The y coordinate (sin a).</param>
		/// <returns>The value of the angle, degrees.</returns>
		public static double Arctand(double x, double y)
		{
			return Arctan(x, y) * Constants.RADIAN;
		}

		/// <summary>
		/// Arcsine of a value expressed in degrees.
		/// </summary>
		/// <param name="x">Sine value.</param>
		/// <returns>\f$ \arcsin(x) \f$ in degrees.</returns>
		public static double Asind(double x)
		{
			return Math.Asin(x) * Constants.RADIAN;
		}

		/// <summary>
		/// Arccosine of a value expressed in degrees.
		/// </summary>
		/// <param name="x">Cosine value.</param>
		/// <returns>\f$ \arccos(x) \f$ in degrees.</returns>
		public static double Acosd(double x)
		{
			return Math.Acos(x) * Constants.RADIAN;
		}

		/// <summary>
		/// Arctan of a value expressed in degrees.
		/// </summary>
		/// <param name="x">Tangens value.</param>
		/// <returns>\f$ \arctan(x) \f$ in degrees.</returns>
		public static double Atand(double x)
		{
			return Math.Atan(x) * Constants.RADIAN;
		}

		/// <summary>
		/// Atan2 for values expressed in degrees.
		/// </summary>
		/// <param name="y">Value of sine.</param>
		/// <param name="x">Value of cosine.</param>
		/// <returns>Arctan of the values expressed in degrees.</returns>
		public static double Atan2d(double y, double x)
		{
			return Math.Atan2(y, x) * Constants.RADIAN;
		}
		#endregion
	}
}
