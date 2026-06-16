/***********************************************************************************
* File:         RestrictedDictionary.cs                                            *
* Contents:     Class RestrictedDictionary                                         *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-06-16 09:31                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Factotum.Structures
{
	/// <summary>
	/// Dictionary with string keys from a defined list of values.
	/// </summary>
	public class RestrictedDictionary<T>
	{
		#region Private members
		private List<string>			_supportedKeys	= new List<string>();
		private Dictionary<string, T>	_values			= new Dictionary<string, T>();
		#endregion

		#region Construction
		public RestrictedDictionary(IEnumerable<string> keys)
		{
			this._supportedKeys.AddRange(keys);
		}

		public RestrictedDictionary()
		{
		}
		#endregion

		#region Properties
		public string[] Keys
		{
			get	{return this._supportedKeys.ToArray();}
		}
		#endregion

		#region Indexers
		public T this[string key]
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

			set
			{
				if (this._values.ContainsKey(key))
				{
					this._values[key]	= value;
				}
			}
		}
		#endregion
	}
}
