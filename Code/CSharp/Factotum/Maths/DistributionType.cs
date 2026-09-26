/***********************************************************************************
* File:         DistributionType.cs                                                *
* Contents:     Enum DistributionType                                              *
* Author:       Stacy Maimoon (stacy.maimoon@seznam.cz)                            *
* Date:         2026-09-25 11:57                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Text.Json.Serialization;

namespace Factotum.Maths
{
	/// <summary>
	/// Defines supported types of discrete randomizers.
	/// </summary>
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum DistributionType
	{
		/// <summary>
		/// Uniform distribution.
		/// </summary>
		Uniform,

		/// <summary>
		/// Zipf's distribution.
		/// </summary>
		Zipf,

		/// <summary>
		/// Distribution of geometric decay.
		/// </summary>
		GeometricDecay,

		/// <summary>
		/// Empiric distribution.
		/// </summary>
		Empiric
	}
}
