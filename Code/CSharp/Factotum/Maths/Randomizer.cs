/***********************************************************************************
* File:         Randomizer.cs                                                      *
* Contents:     Class Randomizer                                                   *
* Author:       Stacy Maimoon (stacy.maimoon@seznam.cz)                            *
* Date:         2026-09-26 14:28                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Text.Json.Serialization;

namespace Factotum.Maths
{
	/// <summary>
	/// Randomizer to generate random choice from a collection of arbitrary objects.
	/// </summary>
	[JsonConverter(typeof(RandomizerConverter))]
	public class Randomizer
	{
		#region Public Properties
		/// <summary>
		/// Type of distribution.
		/// </summary>
		public DistributionType	DistributionType	{get;set;}	= DistributionType.Uniform;
		#endregion

		#region Internal Properties
		/// <summary>
		/// Cumulative probabilities of elements.
		/// </summary>
		[JsonInclude]
		internal double[] Distribution	{get;set;}	= new double[0];

		/// <summary>
		/// Array of parameters.
		/// Needed for serialization.
		/// Number and meaning of parameters depend on the distribution type.
		///		Uniform distribution:			[0]: number of elements.
		///		Zipf's distribution:			[0]: number of elements; [1] Zipf's exponent.
		///		Geometric decay distribution:	[0]: number of elements; [1] power; [2] floor.
		/// </summary>
		[JsonInclude]
		internal double[] Parameters	{get;set;}	= new double[0];

		/// <summary>
		/// Randomizer to produce uniform double random values.
		/// </summary>
		private static Random _random = new Random((int)DateTime.Now.Ticks);
		#endregion

		#region Construction
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Randomizer()	{}

		/// <summary>
		/// Internal type and parameters constructor.
		/// Used for Json deserialization.
		/// </summary>
		/// <param name="type">Distribution type.</param>
		/// <param name="parameters">Array of parameters.</param>
		internal Randomizer(DistributionType type, double[] parameters)
		{
			this.DistributionType	= type;
			this.Parameters			= parameters;

			int N					= 0;

			switch (this.DistributionType)
			{
				case DistributionType.Uniform:
					this.CreateUniform(parameters);
					break;

				case DistributionType.Zipf:
					this.CreateZipf(parameters);
					break;

				case DistributionType.GeometricDecay:
					this.CreateGeometricDecay(parameters);
					break;

				case DistributionType.Empiric:
					// parameters are treated as empiric frequencies, non-normalized.
					this.CreateEmpiric(parameters);
					break;

				default:
					break;
			}
		}

		/// <summary>
		/// Creates an instance of Randomizer with uniform distribution.
		/// </summary>
		/// <param name="N">Number of elements in the collection.</param>
		/// <returns>Instance of Randomizer, if successful.</returns>
		/// <exception cref="ArgumentException">Thrown if the value of N is non-positive.</exception>
		public static Randomizer Uniform(int N)
		{
			Randomizer randomizer		= new Randomizer();
			randomizer.DistributionType	= DistributionType.Uniform;
			randomizer.Parameters		= [N];
			randomizer.CreateUniform([N]);

			return randomizer;
		}

		/// <summary>
		/// Creates an instance of Randomizer with Zipf's distribution.
		/// </summary>
		/// <param name="N">Number of elements in the collection.</param>
		/// <param name="s">Zipf's exponent.</param>
		/// <returns>Instance of Randomizer, if successful.</returns>
		/// <exception cref="ArgumentException">Thrown if one of the parameters is invalid.</exception>
		public static Randomizer Zipf(int N, double s)
		{
			Randomizer randomizer		= new Randomizer();
			randomizer.DistributionType	= DistributionType.Zipf;
			randomizer.Parameters		= [N, s];
			randomizer.CreateZipf([N, s]);

			return randomizer;
		}

		/// <summary>
		/// Creates an instance of Randomizer with geometric decay distribution.
		/// </summary>
		/// <param name="N">Number of elements in the collection.</param>
		/// <param name="q">Value of power in the geometric progression.</param>
		/// <param name="f">Value of floor.</param>
		/// <returns>Instance of Randomizer, if successful.</returns>
		/// <exception cref="ArgumentException">Thrown if one of the parameters is invalid.</exception>
		public static Randomizer GeometricDecay(int N, double q, double f = 0)
		{
			Randomizer randomizer		= new Randomizer();
			randomizer.DistributionType	= DistributionType.GeometricDecay;
			randomizer.Parameters		= [N, q, f];
			randomizer.CreateGeometricDecay([N, q, f]);

			return randomizer;
		}

		/// <summary>
		/// Creates an instance of Randomizer with an empiric distribution.
		/// </summary>
		/// <param name="data">Array of occurrencies of the array's elements, not necessarily normalized.</param>
		/// <returns>Instance of Randomizer, if successful.</returns>
		/// <exception cref="ArgumentException">
		///		Thrown if either the size of the collection is less than 1 or if one of the occurrencies is negative.
		///	</exception>
		public static Randomizer Empiric(double[] data)
		{
			Randomizer randomizer		= new Randomizer();
			randomizer.DistributionType	= DistributionType.Empiric;
			randomizer.CreateEmpiric(data);

			return randomizer;
		}
		#endregion

		#region Randomization
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

			if (random < this.Distribution[0])
			{
				return 0;
			}

			for (int i = 0; i < this.Distribution.Length - 1; i++)
			{
				if (this.Distribution[i] <= random && random < this.Distribution[i + 1])
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

		#region Private Auxiliary
		/// <summary>
		/// Creates a uniform distribution using the array of data.
		/// The only expected element of the array is the length of the object collection N.
		/// </summary>
		/// <param name="data">Array of data to use.</param>
		/// <exception cref="ArgumentException">
		///		Thrown if the length of the data array is zero.
		/// </exception>
		private void CreateUniform(double[] data)
		{
			if (data.Length < 1)
			{
				throw new ArgumentException("Uniform distribution needs a positive integer length");
			}

			int N					= (int)data[0];
			double[] occurrences	= new double[N];

			for (int i = 0; i < occurrences.Length; i++)
			{
				occurrences[i]		= 1.0 / N;
			}

			this.CreateCumulativeDistribution(occurrences);
		}

		/// <summary>
		/// Creates a Zipf's distribution using the array of data.
		/// The data array contains:
		///		[0]: The length of the object collection N,
		///		[1]: Zipf's exponent.
		/// </summary>
		/// <param name="data">Array of data to use.</param>
		/// <exception cref="ArgumentException">
		///		Thrown if the length of the data array is less than two or the value of Zipf's exponent is less or equal to 1.
		/// </exception>
		private void CreateZipf(double[] data)
		{
			if (data.Length < 2)
			{
				throw new ArgumentException("Zipf distribution needs two parameters: a positive integer length and a double exponent");
			}

			int N		= (int)data[0];
			double s	= data[1];

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

			this.CreateCumulativeDistribution(occurrences);
		}

		/// <summary>
		/// Creates a geometric decay distribution using the array of data.
		/// The data array contains:
		///		[0]: The length of the object collection N,
		///		[1]: Geometric decay power.
		///		[2]: Geometric decay floor.
		/// </summary>
		/// <param name="data">Array of data to use.</param>
		/// <exception cref="ArgumentException">
		///		Thrown if the length of the data array is less than three 
		///		or if the value of power is less or equal to 1 
		///		or if the floor is negative.
		/// </exception>
		private void CreateGeometricDecay(double[] data)
		{
			if (data.Length < 3)
			{
				throw new ArgumentException("Geometric decay distribution needs 3 parameters: a positive integer length, a double power and a double floor");
			}

			int N		= (int)data[0];
			double q	= data[1];
			double f	= data[2];

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

			this.CreateCumulativeDistribution(occurrences);
		}

		/// <summary>
		/// Creates an empiric distribution using an array of occurrencies.
		/// </summary>
		/// <param name="data">The array of occurrencies.</param>
		/// <exception cref="ArgumentException">
		///		Thrown if the length of the occurrencies array is less than one
		///		or if one of the occurrencies is negative.
		/// </exception>
		/// <exception cref="DivideByZeroException">
		///		Thrown if the sum of occurrencies is equal to zero.
		///	</exception>
		private void CreateEmpiric(double[] data)
		{
			if (data.Count() < 1)
			{
				throw new ArgumentException("Cannot create a discrete randomizer from less than one occurrence");
			}

			if (data.Any(t => t < 0))
			{
				throw new ArgumentException("Cannot create a discrete randomizer from these occurrencies. Occurrences must be non-negative.");
			}

			double sum = data.Sum();

			if (sum == 0)
			{
				throw new DivideByZeroException("Cannot create a discrete randomizer with sum of occurrencies equal to zero");
			}

			this.CreateCumulativeDistribution(data);
		}

		/// <summary>
		/// Creates cumulative probability histogram out of an array of occurrencies.
		/// </summary>
		/// <param name="occurrencies">Array of occurrencies.</param>
		/// <exception cref="ArgumentException">
		///		Thrown if the length of the occurrencies array is less than one
		///		or if one of the occurrencies is negative.
		/// </exception>
		/// <exception cref="DivideByZeroException">
		///		Thrown if the sum of occurrencies is equal to zero.
		/// </exception>
		private void CreateCumulativeDistribution(double[] occurrencies)
		{
			if (occurrencies.Count() < 1)
			{
				throw new ArgumentException("Cannot create a discrete randomizer from less than one occurrence");
			}

			if (occurrencies.Any(t => t < 0))
			{
				throw new ArgumentException("Cannot create a discrete randomizer from these occurrencies. Occurrences must be non-negative.");
			}

			double sum = occurrencies.Sum();

			if (sum == 0)
			{
				throw new DivideByZeroException("Cannot create a discrete randomizer with sum of occurrencies equal to zero");
			}

			for (int i = 0; i < occurrencies.Length; i++)
			{
				occurrencies[i] /= sum;
			}

			this.Distribution = new double[occurrencies.Length];

			this.Distribution[0] = occurrencies[0];

			for (int i = 1; i < this.Distribution.Length; i++)
			{
				this.Distribution[i] = this.Distribution[i - 1] + occurrencies[i];
			}
		}
		#endregion
	}
}
