/***********************************************************************************
* File:         DiscreteRandomizer.cs                                              *
* Contents:     Class DiscreteRandomizer                                           *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-10-18 23:26                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/
namespace Factotum.Maths
{
	/// <summary>
	/// Randomizer to generate random members of object collections.
	/// TODO: Add predefined distribution types: Zipf, geometric.
	/// </summary>
	public class DiscreteRandomizer
	{
		#region Private members
		/// <summary>
		/// Cumulative distribution of elements.
		/// </summary>
		private double[] _distribution	= new double[0];

		/// <summary>
		/// Randomizer to produce uniform double random values.
		/// </summary>
		private static Random _random = new Random((int)DateTime.Now.Ticks);
		#endregion

		#region Construction
		/// <summary>
		/// Creates a double randomizer with given relative numbers of occurrences of elements. 
		/// </summary>
		/// <param name="occurrences">Array or list of occurency numbers.</param>
		public DiscreteRandomizer(IEnumerable<double> occurrences)
		{
			if (occurrences.Count() < 1)
			{
				throw new ArgumentException("Cannot create a discrete randomizer from less than one occurrence");
			}

			if (occurrences.Any(t => t < 0))
			{
				throw new ArgumentException("Cannot create a discrete randomizer from these occurrences. Occurrences must be non-negative.");
			}

			double sum = occurrences.Sum();

			if (sum == 0)
			{
				throw new DivideByZeroException("Cannot create a discrete randomizer with sum of occurrences equal to zero");
			}

			List<double> frequencies = new List<double>();

			foreach (double value in occurrences)
			{
				frequencies.Add(value / sum);
			}

			this._distribution = new double[frequencies.Count];

			this._distribution[0] = frequencies[0];

			for (int i = 1; i < this._distribution.Length; i++)
			{
				this._distribution[i] = this._distribution[i - 1] + frequencies[i];
			}
		}

		/// <summary>
		/// Creates an instance of DiscreteRandomizer with Zipf's finite distribution
		/// (https://en.wikipedia.org/wiki/Zipf's_law):
		/// \$p(k) = \frac{k^{-s}}{H_N} \$
		/// where k >= 1 is the index of the element,
		/// s > 1 the distribution parameter,
		/// \$ N_N = \sum_{k=1}^N k^{-s} \$ the sum of the discrete probabilities for the finite case, 
		/// aka generalized harmonic number playing the role of normalization constant.
		/// </summary>
		/// <param name="N">Length of the elements' list.</param>
		/// <param name="s">Distribution parameter.</param>
		/// <returns>An instance of DiscreteRandomizer for (finite) Zipf distribution.</returns>
		/// <exception cref="ArgumentException">
		/// Thrown if s < 1.
		/// </exception>
		public static DiscreteRandomizer Zipf(int N, double s)
		{
			if (s < 1)
			{
				throw new ArgumentException("Zipf's distribution parameter must be >= 1");
			}

			double[] occurrences = new double[N];
			occurrences[0] = 1;

			for (int i = 1; i < N; i++)
			{
				occurrences[i] = occurrences[i - 1] / s;
			}

			return new DiscreteRandomizer(occurrences);
		}




		/// <summary>
		/// \$ p(k) = \frac{q^k + f}{H_N}, 1 <= k <= N, \$
		/// where \$ H_N = \sum_{k=1}^N q^k + f. \$
		/// </summary>
		/// <param name="N">Length of the elements' list.</param>
		/// <param name="q">
		///		Decay factor. Must be > 1. 
		///		(With q=1 we have uniform distribution that is treated as a different case.)
		///	</param>
		/// <param name="f">Floor value. Default value = 0.</param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public static DiscreteRandomizer GeometricDecay(int N, double q, double f = 0)
		{
			if (q <= 1)
			{
				throw new ArgumentException("Geometric distribution power must be > 1.");
			}

			if (f < 0)
			{
				throw new ArgumentException("Geometric distribution floor must be non-negative.");
			}

			double[] occurrences = new double[N];
			double factor = 1;

			for (int i = 0; i < N; i++)
			{
				occurrences[i] = factor + f;
				factor /= q;
			}

			return new DiscreteRandomizer(occurrences);
		}
		#endregion

		#region Random values
		/// <summary>
		/// Generates a uniform random index according to current distribution.
		/// </summary>
		/// <returns>
		///		A random integer i: 0 <= i <= N-1, 
		///		where N is the numner of steps in the distribution.
		///	</returns> 
		public int RandomIndex()
		{
			double random = _random.NextDouble();

			if(random < this._distribution[0])
			{
				return 0;
			}

			for (int i = 0; i < this._distribution.Length - 1; i++)
			{
				if (this._distribution[i] <= random && random < this._distribution[i + 1])
				{
					return i + 1;
				}
			}

			return 0;
		}

		/// <summary>
		/// Object randomizer for polymorphic collections.
		/// </summary>
		/// <param name="objects">Collection of objects of arbitrary types.</param>
		/// <returns>Random object of the collection.</returns>
		public object RandomObject(IEnumerable<object> objects)
		{
			int index = this.RandomIndex();
			return objects.ToArray()[index];
		}

		/// <summary>
		/// Object randomizer for monomorphic collections.
		/// </summary>
		/// <typeparam name="T">Type of the objects in the collection.</typeparam>
		/// <param name="objects">Collection of objects of type T.</param>
		/// <returns>Random object of the collection.</returns>
		public T RandomObject<T>(IEnumerable<T> objects)
		{
			int index = this.RandomIndex();

			return objects.ToArray()[index];
		}
		#endregion
	}
}
