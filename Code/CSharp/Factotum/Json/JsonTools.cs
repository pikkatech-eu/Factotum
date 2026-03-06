/***********************************************************************************
* File:         JsonTools.cs                                                       *
* Contents:     Class JsonTools                                                    *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2026-03-06 16:30                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Text.Json;

namespace Factotum.Json
{
	/// <summary>
	/// Extension methods for JsonElement to safely access their values.
	/// </summary>
	public static class JsonTools
	{
		/// <summary>
		/// Safely gets the typed value of an element within a host JsonElement.
		/// </summary>
		/// <typeparam name="T">The type of the element to get.</typeparam>
		/// <param name="je">The host JsonElement.</param>
		/// <param name="propertyName">The name of the property to get.</param>
		/// <param name="defaultValue">The default value to return when the value could not be retrieved.</param>
		/// <returns>The typed value of the element, if could be retrieved, otherwise the default value.</returns>
		public static T PropertyValue<T>(this JsonElement je, string propertyName, T defaultValue = default(T))
		{
			Type type = typeof(T);
			object result;

			switch (type)
			{
				case Type _ when type == typeof(string):
					result = GetPropertyString(je, propertyName, Convert.ToString(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				default:
					return default(T);
			}
		}

		/// <summary>
		///		Safely gets the indexed typed value of an element within a host JsonElement.
		///		Describes the case when the property of name propertyName is an array, 
		///		and we want to know the value of the subelement by its index.
		/// </summary>
		/// <typeparam name="T">The type of the element to get.</typeparam>
		/// <param name="je">The host JsonElement.</param>
		/// <param name="propertyName">The name of the property to get.</param>
		/// <param name="defaultValue">The default value to return when the value could not be retrieved.</param>
		/// <param name="index">The index of the value in the array.</param>
		/// <returns>The typed value of the element, if could be retrieved, otherwise the default value.</returns>
		public static T IndexedPropertyValue<T>(this JsonElement je, string propertyName, T defaultValue = default(T), int index = 0)
		{
			Type type = typeof(T);
			object result;

			switch (type)
			{
				case Type _ when type == typeof(string):
					result = GetPropertyString(je, propertyName, Convert.ToString(defaultValue), index);
					return (T)Convert.ChangeType(result, typeof(T));

				default:
					return default(T);
			}
		}

		#region Private Auxiliary
		private static object GetPropertyString(JsonElement je, string propertyName, string defaultValue)
		{
			try
			{
				JsonElement jeProperty	= je.GetProperty(propertyName);
				JsonElement jeItem = jeProperty;
				return jeProperty.ToString();
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}

		private static object GetPropertyString(JsonElement je, string propertyName, string defaultValue, int index = 0)
		{
			try
			{
				JsonElement jeProperty	= je.GetProperty(propertyName);
				JsonElement jeItem = jeProperty.EnumerateArray().ToArray()[index];
				return jeItem.ToString();
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}
		#endregion
	}
}
