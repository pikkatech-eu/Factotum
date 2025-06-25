/***********************************************************************************
* File:         Cache.cs                                                           *
* Contents:     Class Cache                                                        *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-25 20:03                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factotum.Structures
{
	/// <summary>
	/// Models a cache with arbitrary key and value type.
	/// </summary>
	/// <typeparam name="K">The key type, e.g. int or string.</typeparam>
	/// <typeparam name="T">The value type.</typeparam>
	public class Cache<K, T> where T : ICacheable
	{
		#region Constants
		/// <summary>
		/// The default (low) capacity of the cache (16.7 MB)
		/// </summary>
		private const int	DEFAULT_CAPACITY	= 16777216;
		#endregion

		#region Private members
		/// <summary>
		/// Dictionary of values, to provide for fast access.
		/// </summary>
		private Dictionary<K, T> _values = [];

		/// <summary>
		/// Current summary byte site (or cost) of all cached items.
		/// </summary>
		private int	_currentSize = 0;
		#endregion

		#region Properties
		/// <summary>
		/// The capacity of the cache.
		/// </summary>
		public int Capacity { get; internal set; } = DEFAULT_CAPACITY;

		/// <summary>
		/// Gets current number of items on cache.
		/// </summary>
		public int Count
		{
			get	{return this._values.Count;}
		}

		/// <summary>
		/// Gets the array of keys in the cache.
		/// </summary>
		public K[] Keys
		{
			get	{return this._values.Keys.ToArray();}
		}

		/// <summary>
		/// Gets the current summary byte size.
		/// </summary>
		public int CurrentSize
		{
			get	{return this._currentSize;}
		}
		#endregion

		#region Indexers
		/// <summary>
		/// Gets the item stored under a given key.
		/// </summary>
		/// <param name="key">Key to find.</param>
		/// <returns>The value stored with the key, if the key is contained, otherwise the default value of the type T.</returns>
		public T this[K key]
		{
			get
			{
				if (this._values.ContainsKey(key))
				{
					return this._values[key];
				}
				else
				{
					return default(T);
				}
			}
		}
		#endregion

		#region Construction
		/// <summary>
		/// Creates a cache with given capacity.
		/// By default, with 16.7 MB.
		/// </summary>
		/// <param name="capacity">The capacity of cache.</param>
		public Cache(int capacity = DEFAULT_CAPACITY)
		{
			this.Capacity	= capacity;
		}
		#endregion

		#region Management
		/// <summary>
		/// Clears the cache.
		/// </summary>
		public void Clear()
		{
			this._values.Clear();
		}

		/// <summary>
		/// Key containment.
		/// </summary>
		/// <param name="key">Key to check the contzainment of.</param>
		/// <returns>True if the key is contained on the key list.</returns>
		public bool ContainsKey(K key)
		{
			return this._values.ContainsKey(key);
		}

		/// <summary>
		/// Adds a key value pair to the cache.
		/// The size of the value to add is measured by the ObjectMeter and, 
		/// if the summary size of the elements with the new element exceeds 
		/// the capacity of the cache, a number of elements that were added first, are deleted.
		/// </summary>
		/// <param name="key">The key to add with.</param>
		/// <param name="value">The value to add.</param>
		public void Add(K key, T value)
		{
			int size	= value.Cost;

			if (this._values.ContainsKey(key))
			{
				return;
			}

			if (size > this.Capacity)
			{
				throw new OutOfMemoryException("Size of the object to add exceeds the cache's capacity");
			}

			if (this._values.Count > 0)
			{
				while(this._currentSize + size > this.Capacity)
				{
					try
					{
						int sizeToRemove = this._values.Values.First().Cost;
						this._values.Remove(this._values.Keys.First());
						this._currentSize -= sizeToRemove;
					}
					catch	{}
				}
			}

			this._values.Add(key, value);
			this._currentSize	+= size;
		}
		#endregion
	}
}
