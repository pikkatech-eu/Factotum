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
		#region Root finding related
		/// <summary>
		/// 
		/// </summary>
		/// <param name="f"></param>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <param name="precision"></param>
		/// <param name="maxIterations"></param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">
		///		Thrown if the values of the function at left and right have the same sign (no bisection possible).
		/// </exception>
		/// <exception cref="StopIterationException">Thrown if the number of iterations exceeds a defined maximum.</exception>
		public static double Bisection(Func<double, double> f, double left, double right, double precision, int maxIterations = Constants.DEFAULT_MAX_ITERATIONS)
		{
			double fLeft = f(left);
			double fRight = f(right);
			if (Math.Sign(fLeft) == Math.Sign(fRight))
			{
				throw new InvalidOperationException("Wrong initial interval: the values of the function are of the same sign");
			}

			double middle = 0.5 * (left + right);
			int iterations = 0;
			double accuracy = Math.Abs(f(middle));

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
				accuracy = Math.Abs(f(middle));
				iterations++;

				if (iterations > maxIterations)
				{
					throw new StopIterationException(iterations, maxIterations);
				}
			}

			return middle;
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
