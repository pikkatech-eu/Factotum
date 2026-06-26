/***********************************************************************************
* File:         ManagedDictionary.cs                                               *
* Contents:     Class ManagedDictionary                                            *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-06-25 17:57                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Factotum.Structures
{
	/// <summary>
	/// Auxiliary dictionary to simplify checked retrieval of items.
	/// </summary>
	/// <typeparam name="K">Type of the dictionary key.</typeparam>
	public class ManagedDictionary<K>
	{
		#region Private Members
		private Dictionary<K, object>	_values	= new Dictionary<K, object>();
		#endregion

		/// <summary>
		/// Adds an item to the dictionary.
		/// If the key is already existing in the dictionary, nothing happens.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>

		public void Add(K key, object value)
		{
			if (!this._values.ContainsKey(key))
			{
				this._values.Add(key, value);
			}
		}

		/// <summary>
		/// Gets the item of the dictionaly stored under a key.
		/// Sets or updates an item.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		///		Value stored under the key, if the key is existent, otherwise null;
		/// </returns>
		public object this[K key]
		{
			get
			{
				if (this._values.ContainsKey(key))
				{
					return this._values[key];
				}
				else
				{
					return null;
				}
			}

			set
			{
				this._values[key] = value;
			}
		}

		/// <summary>
		///		Gets a typed item by key.
		/// </summary>
		/// <typeparam name="T">
		///		Type of the return value.
		///		Nullable types (such as int?) are not supported.
		///	</typeparam>
		/// <param name="key">
		///		The key under which the value is stored.
		/// </param>
		/// <param name="defaultValue">
		///		Default value to return if the key is not found.
		///		If not specified otherwise, the default value of type T.
		///	</param>
		/// <returns>
		///		Value stored under the key, if the key is existent and the type supported,
		///		otherwise the default value.
		///		NB: Does not support nullable types!
		/// </returns>
		public T GetValue<T>(K key, T defaultValue = default(T))
		{
			if (!this._values.ContainsKey(key))
			{
				return defaultValue;
			}

			try
			{
				return (T)Convert.ChangeType(this[key], typeof(T));
			}
			catch
			{
				return defaultValue;
			}
		}
	}
}
