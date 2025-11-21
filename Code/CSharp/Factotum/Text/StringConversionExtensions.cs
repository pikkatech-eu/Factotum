/***********************************************************************************
* File:         ParsingTools.cs                                                    *
* Contents:     Class ParsingTools                                                 *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2024-09-13 10:31                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Factotum.Tools
{
	/// <summary>
	/// Safely converts a string to a typed numeric value.
	/// </summary>
	public static class StringConversionExtensions
	{
		/// <summary>
		/// Performs the conversion.
		/// </summary>
		/// <typeparam name="T">
		///		The type of the element to conver to.
		///		At the moment, supports the following types:
		///			int
		///			double
		///	</typeparam>
		/// <param name="x">The text to convert.</param>
		/// <param name="defaultValue">Default value to assign.</param>
		/// <returns>The typed value as converted, if successful, otherwise the default value.</returns>
		public static T ToNumber<T>(this string x, T defaultValue = default(T))
		{
			Type type = typeof(T);

			switch (type)
			{
				case Type _ when type == typeof(int):
					return (T)Convert.ChangeType(Int32.TryParse(x, out int intValue) ? intValue : default(int), typeof(T));

				case Type _ when type == typeof(short):
					return (T)Convert.ChangeType(Int16.TryParse(x, out short shortValue) ? shortValue : default(short), typeof(T));

				case Type _ when type == typeof(long):
					return (T)Convert.ChangeType(Int64.TryParse(x, out long longValue) ? longValue : default(long), typeof(T));

				case Type _ when type == typeof(byte):
					return (T)Convert.ChangeType(Byte.TryParse(x, out byte byteValue) ? byteValue : default(byte), typeof(T));

				case Type _ when type == typeof(bool):
					return (T)Convert.ChangeType(Boolean.TryParse(x, out bool boolValue) ? boolValue : default(bool), typeof(T));

				case Type _ when type == typeof(double):
					return (T)Convert.ChangeType(Double.TryParse(x, out double doubleValue) ? doubleValue : default(double), typeof(T));

				case Type _ when type == typeof(float):
					return (T)Convert.ChangeType(Double.TryParse(x, out double floatValue) ? floatValue : default(float), typeof(T));

				case Type _ when type == typeof(Guid):
					return (T)Convert.ChangeType(Guid.TryParse(x, out Guid guidValue) ? guidValue : default(Guid), typeof(T));

				case Type _ when type == typeof(DateTime):
					return (T)Convert.ChangeType(DateTime.TryParse(x, out DateTime dateTimeValue) ? dateTimeValue : default(DateTime), typeof(T));

				default:
					return default(T);
			}
		}
	}
}
