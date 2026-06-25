/***********************************************************************************
* File:         ManagedDictionary.cs                                               *
* Contents:     Class ManagedDictionary                                            *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-06-25 17:57                                                   *
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
	public class ManagedDictionary<K>
	{
		private Dictionary<K, object>	_values	= new Dictionary<K, object>();

		public void Add(K key, object value)
		{
			if (!this._values.ContainsKey(key))
			{
				this._values.Add(key, value);
			}
		}

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

			//Type type = typeof(T);

			//switch (type)
			//{
			//	case Type _ when type == typeof(int):
			//		try
			//		{
			//			return (T)Convert.ChangeType(this[key], typeof(T));
			//		}
			//		catch
			//		{
			//			return defaultValue;
			//		}

			//	case Type _ when type == typeof(double):
			//		try
			//		{
			//			return (T)Convert.ChangeType(this[key], typeof(T));
			//		}
			//		catch
			//		{
			//			return defaultValue;
			//		}

			//	default:
			//		return defaultValue;
			//}
		}
	}
}
