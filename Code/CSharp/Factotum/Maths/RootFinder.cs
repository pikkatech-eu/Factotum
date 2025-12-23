/***********************************************************************************
* File:         RootFinder.cs                                                      *
* Contents:     Class RootFinder                                                   *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2024-10-19 23:44                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using Factotum.Exceptions;

namespace Factotum.Maths
{
	public static class RootFinder
	{
		public static int Iterations	{get;internal set;} = 0;

		#region Root finding related
		/// <summary>
		/// Tries to compute the zero of a function using the Bisection method.
		/// Uses two approximations of the zero [left, right] called bracket where the value of the function takes opposite signs.
		/// </summary>
		/// <param name="f">The function for which to find the zero.</param>
		/// <param name="left">The left value of the bracket.</param>
		/// <param name="right">The right value of the bracket.</param>
		/// <param name="precision">Precision to compute with.</param>
		/// <param name="maxIterations">Maximum number of iterations to make.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">
		///		Thrown if the values of the function at left and right have the same sign (no bisection possible).
		/// </exception>
		/// <exception cref="StopIterationException">Thrown if the number of iterations exceeds a defined maximum.</exception>
		public static double Bisection(Func<double, double> f, double left, double right, double precision, int maxIterations = Constants.DEFAULT_MAX_ITERATIONS)
		{
			double fLeft = f(left);
			double fRight = f(right);

			if (Math.Sign(fLeft) == Math.Sign(fRight))
			{
				throw new ArgumentException("Wrong initial interval: the values of the function are of the same sign");
			}

			double middle = 0.5 * (left + right);
			int iterations = 0;
			double accuracy = Math.Abs(right - left);

			while (accuracy > precision && iterations < maxIterations)
			{
				double fMiddle = f(middle);

				if (Math.Sign(fMiddle) == Math.Sign(fLeft))
				{
					left = middle;
				}
				else
				{
					right = middle;
				}

				middle = 0.5 * (left + right);
				accuracy = Math.Abs(right - left);
				iterations++;

				if (iterations > maxIterations)
				{
					throw new StopIterationException(iterations, maxIterations);
				}
			}

			Iterations = iterations;

			return middle;
		}

		/// <summary>
		/// Tries to compute the zero of a function using the Regula Falsi (False Position) method.
		/// Uses two approximations of the zero [left, right] called bracket where the value of the function takes opposite signs.
		/// </summary>
		/// <param name="f">The function for which to find the zero.</param>
		/// <param name="left">The left value of the bracket.</param>
		/// <param name="right">The right value of the bracket.</param>
		/// <param name="precision">Precision to compute with.</param>
		/// <param name="maxIterations">Maximum number of iterations to make.</param>
		/// <returns>The value of the zero if succeeded.</returns>
		/// <exception cref="ArgumentException">Thrown if the function's value at the ends of the bracket are of the same sign.</exception>
		/// <exception cref="StopIterationException">Thrown if the number of iterations exceeded the maximum value.</exception>
		public static double RegulaFalsi(Func<double, double> f, double left, double right, double precision, int maxIterations = Constants.DEFAULT_MAX_ITERATIONS)
		{
			double fLeft = f(left);
			double fRight = f(right);

			if (Math.Sign(fLeft) == Math.Sign(fRight))
			{
				throw new ArgumentException("Wrong initial interval: the values of the function are of the same sign");
			}

			int iterations = 0;
			double middle = left;
			double fMiddle = f(middle);
			double accuracy = Math.Abs(fMiddle);

			Iterations = 0;

			while (accuracy > precision && iterations < maxIterations)
			{
				// Calculate the point using the false position formula
				middle = left - (fLeft * (right - left)) / (fRight - fLeft);

				fMiddle = f(middle);
				accuracy = Math.Abs(fMiddle);
				iterations++;

				// Check if the solution is found or if it's within tolerance
				if (accuracy < precision)
				{
					Iterations = iterations;
					return middle;
				}

				// Update the interval [a, b]
				if (fLeft * fMiddle < 0)
				{
					right = middle;
					fRight = fMiddle;
				}
				else
				{
					left = middle;
					fLeft = fMiddle;
				}
			}

			throw new StopIterationException(maxIterations, iterations);
		}

		/// <summary>
		/// Tries to compute the zero of a function using the method of secants.
		/// </summary>
		/// <param name="f">The function for which to find the zero.</param>
		/// <param name="x0">The first zero guess.</param>
		/// <param name="x1">The second zero guess.</param>
		/// <param name="precision">Precision to compute with.</param>
		/// <param name="maxIterations">Maximum number of iterations to make.</param>
		/// <returns>The value of the zero if succeeded.</returns>
		/// <exception cref="StopIterationException">Thrown if the number of iterations exceeded the maximum value.</exception>
		public static double Secants(Func<double, double> f, double x0, double x1, double precision, int maxIterations = Constants.DEFAULT_MAX_ITERATIONS)
		{
			double f0 = f(x0);
			double f1 = f(x1);

			Iterations = 0;

			for (int i = 0; i < maxIterations; i++)
			{
				if (Math.Abs(f1) < precision)
				{
					Iterations = i;
					return x1;
				}

				// Calculate the next approximation using the Secant formula
				double x2 = x1 - f1 * (x1 - x0) / (f1 - f0);

				// Update x0, x1 for the next iteration
				x0 = x1;
				f0 = f1;
				x1 = x2;
				f1 = f(x1);
			}

			throw new StopIterationException("Secant method did not converge.");
		}

		/// <summary>
		/// Tries to bracket an interval with respect to a function, i.e. if the initial interval is not a bracket itself, 
		/// it successively increases its boundaries before it reaches a bracketing interval.
		/// </summary>
		/// <param name="f">The function f(x) that should be bracketed</param>
		/// <param name="left">The initial left boundary of the interval to start bracketing from</param>
		/// <param name="right">The initial right boundary of the interval to start bracketing from</param>
		/// <param name="factor">The factor to expand the intervals' boundaries. Default = 0.618...</param>
		/// <param name="maxIterations"></param>
		/// <returns>A bracketing interval, if successfull.</returns>
		/// <exception cref="OverflowException">Raised if no bracket was found after maxIterations.</exception>
		public static (double Left, double Right) Bracket
															(
																Func<double, double> f,
																double left,
																double right,
																double factor = Constants.DEFAULT_BRACKETING_FACTOR,
																int maxIterations = Constants.DEFAULT_MAX_ITERATIONS
															)
		{
			left = Math.Min(left, right);
			right = Math.Max(left, right);

			double fLeft = f(left);
			double fRight = f(right);

			if (Math.Sign(fLeft) != Math.Sign(fRight))
			{
				return (left, right);
			}

			int iterations = 0;

			while (iterations < maxIterations)
			{
				double width = right - left;
				left -= factor * width;

				if (Math.Sign(fLeft) != Math.Sign(fRight))
				{
					return (left, right);
				}

				right += factor * width;

				if (Math.Sign(fLeft) != Math.Sign(fRight))
				{
					return (left, right);
				}

				iterations++;
			}

			throw new OverflowException("Maximum iterations reached. No bracket found");
		}
		#endregion
	}
}
