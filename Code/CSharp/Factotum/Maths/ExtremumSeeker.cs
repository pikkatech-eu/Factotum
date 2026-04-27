/***********************************************************************************
* File:         ExtremumSeeker.cs                                                  *
* Contents:     Class ExtremumSeeker                                               *
* Author:       Stanislav Koncvebovski (aka Bav) (stanislav@pikkatech.eu)          *
* Date:         2026-04-27 10:17                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using Factotum.Exceptions;

namespace Factotum.Maths
{
	public static class ExtremumSeeker
	{
		/// <summary>
		///		Finds maximum of a unimodal function on interval [a, b] using the Golden Ratio method.
		/// </summary>
		/// <param name="f">The function.</param>
		/// <param name="a">Left boundary of the interval.</param>
		/// <param name="b">Right boundary of the interval.</param>
		/// <param name="tolerance">Calculation tolerance.</param>
		/// <param name="maxIterations">Maximum number of iterations.</param>
		/// <returns>
		///		Argument of the maximum of the function, if it existrs, otherwise the last iteration's value.
		///	</returns>
		public static double FindMaximum(Func<double, double> f, double a, double b, double tolerance = 1e-8, int maxIterations = Constants.DEFAULT_MAX_ITERATIONS)
		{
			double c = b - (b - a) / Constants.GOLDEN_RATIO;
			double d = a + (b - a) / Constants.GOLDEN_RATIO;

			double fc = f(c);
			double fd = f(d);

			int iter = 0;

			while (Math.Abs(b - a) > tolerance && iter < maxIterations)
			{
				if (fc > fd)
				{
					b = d;
					d = c;
					fd = fc;

					c = b - (b - a) / Constants.GOLDEN_RATIO;
					fc = f(c);
				}
				else
				{
					a = c;
					c = d;
					fc = fd;

					d = a + (b - a) / Constants.GOLDEN_RATIO;
					fd = f(d);
				}

				iter++;

				if (iter > maxIterations)
				{
					throw new StopIterationException(iter, maxIterations);
				}
			}

			return (a + b) / 2;
		}

		/// <summary>
		/// Finds maximum of a unimodal function on interval [a, b] using Brent's method.
		/// </summary>
		/// <param name="f">The function.</param>
		/// <param name="a">Left boundary of the interval.</param>
		/// <param name="b">Right boundary of the interval.</param>
		/// <param name="tolerance">Calculation tolerance.</param>
		/// <param name="maxIterations">Maximum number of iterations.</param>
		/// <returns>
		///		Argument of the maximum of the function, if it existrs, otherwise the last iteration's value.
		///	</returns>
		public static double FindMaximumBrent(Func<double, double> f, double a, double b, double tolerance = 1e-8, int maxIterations = Constants.DEFAULT_MAX_ITERATIONS)
		{
			// Inverse golden ratio
			const double c = 0.3819660112501051; // (3 - sqrt(5)) / 2

			double x = a + c * (b - a);
			double w = x, v = x;

			double fx = f(x);
			double fw = fx, fv = fx;

			double d = 0.0; // movement step
			double e = 0.0; // previous step

			int iter = 0;
			for (iter = 0; iter < maxIterations; iter++)
			{
				double m = 0.5 * (a + b);
				double tol1 = tolerance * Math.Abs(x) + 1e-12;
				double tol2 = 2.0 * tol1;

				// Stopping condition
				if (Math.Abs(x - m) <= tol2 - 0.5 * (b - a))
				{
					break;
				}

				bool useParabolic = false;
				double p = 0, q = 0, r = 0;

				if (Math.Abs(e) > tol1)
				{
					// Attempt parabolic interpolation
					r = (x - w) * (fx - fv);
					q = (x - v) * (fx - fw);
					p = (x - v) * q - (x - w) * r;
					q = 2.0 * (q - r);

					if (q > 0) p = -p;
					q = Math.Abs(q);

					if (Math.Abs(p) < Math.Abs(0.5 * q * e) &&
						p > q * (a - x) &&
						p < q * (b - x))
					{
						d = p / q;
						useParabolic = true;
					}
				}

				if (!useParabolic)
				{
					// Golden section fallback
					e = (x < m) ? (b - x) : (a - x);
					d = c * e;
				}

				double u = x + (Math.Abs(d) >= tol1 ? d : Math.Sign(d) * tol1);
				double fu = f(u);

				// Update points
				if (fu > fx)
				{
					if (u < x) b = x; else a = x;

					v = w; fv = fw;
					w = x; fw = fx;
					x = u; fx = fu;
				}
				else
				{
					if (u < x) a = u; else b = u;

					if (fu > fw || w == x)
					{
						v = w; fv = fw;
						w = u; fw = fu;
					}
					else if (fu > fv || v == x || v == w)
					{
						v = u; fv = fu;
					}
				}

				e = d;

				if (iter > maxIterations)
				{
					throw new StopIterationException(iter, maxIterations);
				}
			}

			return x;
		}
	}
}
