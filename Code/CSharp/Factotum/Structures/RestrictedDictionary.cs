/***********************************************************************************
* File:         RestrictedDictionary.cs                                            *
* Contents:     Class RestrictedDictionary                                         *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-06-16 09:31                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Text.Json.Serialization;

namespace Factotum.Structures
{
	/// <summary>
	/// Dictionary with keys from a defined list of values.
	/// K: key type (can be anything which can server as a key).
	/// T: value type.
	/// </summary>
	public class RestrictedDictionary<K, T>
	{
		#region Private members
		/// <summary>
		/// List of supported keys.
		/// </summary>
		private List<K>				_supportedKeys	= new List<K>();

		/// <summary>
		/// Dictionary of values with keys of type K, values of type T.
		/// </summary
		[JsonInclude()]
		private Dictionary<K, T>	_values			= new Dictionary<K, T>();
		#endregion

		#region Construction

		/// <summary>
		/// Key list constructor.
		/// Sets the list of supported keys (which cannot be modified later).
		/// </summary>
		/// <param name="keys">Supported keys.</param>
		public RestrictedDictionary(IEnumerable<K> keys)
		{
			this._supportedKeys.AddRange(keys);
		}

		/// <summary>
		/// Default constructor.
		/// Creates an instance with no supported keys.
		/// </summary>
		public RestrictedDictionary()
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Returny the array of supported keys.
		/// </summary>
		[JsonIgnore()]
		public K[] Keys
		{
			get	{return this._supportedKeys.ToArray();}
		}
		#endregion

		#region Indexers
		/// <summary>
		/// Gets and sets a value with a key.
		/// If the key is not in the supported list,
		/// get returns deault value of type T,
		/// set does nothing.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>Value under the key, if that is supported.</returns>
		public T this[K key]
		{
			get
			{
				if (this._supportedKeys.Contains(key))
				{
					return this._values[key];
				}
				else
				{
					return default(T);
				}
			}

			set
			{
				if (this._supportedKeys.Contains(key))
				{
					this._values[key]	= value;
				}
			}
		}
		#endregion
	}
}
