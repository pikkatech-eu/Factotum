/***********************************************************************************
* File:         icacheable.cs                                                      *
* Contents:     Interface ICacheable                                               *
* Author:       Stanislav Koncebovski (Stanislav.Koncebovski@dktech.de)            *
* Date:         2018-03-27 10:14                                                   *
* Version:      1.0                                                                *
* Copyright:    DK Technologies (www.dktech.de)                                    *
***********************************************************************************/
namespace Factotum.Structures
{
	/// <summary>
	/// Interface for classes that use Cache.
	/// Defines property Cost.
	/// </summary>
	public interface ICacheable
	{
		/// <summary>
		/// "Cost" of an item in a cache.
		/// In a cache using byte length as capacity measure, this will be the item's byte length.
		/// </summary>
		int Cost	{get;}
	}
}
