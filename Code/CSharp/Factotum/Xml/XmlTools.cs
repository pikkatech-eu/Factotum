/***********************************************************************************
* File:         XmlTools.cs                                                        *
* Contents:     Class XmlTools                                                     *
* Author:       Stanislav Koncebovski (stanislav@pikkatech.eu)                     *
* Date:         2020-03-19 14:56                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/
using System;
using System.Xml.Linq;

namespace Factotum.Xml
{
	public static partial class XmlTools
	{
		#region Public Features		
		/// <summary>
		/// Safely gets the typed value of an element within a host XML element.
		/// </summary>
		/// <typeparam name="T">The type of the element to get.</typeparam>
		/// <param name="x">The host XElement.</param>
		/// <param name="elementName">Name of the element to get the value from.</param>
		/// <param name="defaultValue">The default value to return when the value could not be retrieved..</param>
		/// <returns>The typed value of the element, if could be retrieved, otherwise the default value.</returns>
		public static T ElementValue<T>(this XElement x, string elementName, T defaultValue = default(T))
		{
			Type type = typeof(T);
			object result;

			switch (type)
			{
				case Type _ when type == typeof(int):
					result = GetElementInt(x, elementName, Convert.ToInt32(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(short):
					result = GetElementShort(x, elementName, Convert.ToInt16(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(long):
					result = GetElementLong(x, elementName, Convert.ToInt16(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(uint):
					result = GetElementUint(x, elementName, Convert.ToUInt32(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(ushort):
					result = GetElementUshort(x, elementName, Convert.ToUInt16(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(ulong):
					result = GetElementUlong(x, elementName, Convert.ToUInt64(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(byte):
					result = GetElementByte(x, elementName, Convert.ToByte(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(bool):
					result = GetElementBoolean(x, elementName, Convert.ToBoolean(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(DateTime):
					result = GetElementDateTime(x, elementName, Convert.ToDateTime(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(Guid):
					result = GetElementGuid(x, elementName, ConvertToGuid(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(double):
					result = GetElementDouble(x, elementName, Convert.ToDouble(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(float):
					result = GetElementFloat(x, elementName, Convert.ToSingle(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(string):
					result = GetElementString(x, elementName, Convert.ToString(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(char):
					result = GetElementChar(x, elementName, Convert.ToChar(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type.BaseType == typeof(Enum):
					return (T)ElementEnum(x, type, elementName, default(T));

				default:
					return default(T);
			}
		}

		/// <summary>
		/// Gets the value of a typed nullable value of an element within a host XML element.
		/// </summary>
		/// <typeparam name="T">The type of the element to get.</typeparam>
		/// <param name="x">The host XElement.</param>
		/// <param name="elementName">Name of the element to get the value from.</param>
		/// <returns>The typed value of the element, if could be retrieved, otherwise null.</returns>
		public static T? ElementValueNullable<T>(this XElement x, string elementName)  where T : struct
		{
			Type type = typeof(T);

			switch (type)
			{
				case Type _ when type == typeof(int):
					return GetGenericValue<T>(GetElementIntNullable(x, elementName));

				case Type _ when type == typeof(short):
					return GetGenericValue<T>(GetElementShortNullable(x, elementName));

				case Type _ when type == typeof(long):
					return GetGenericValue<T>(GetElementLongNullable(x, elementName));

				case Type _ when type == typeof(uint):
					return GetGenericValue<T>(GetElementUintNullable(x, elementName));

				case Type _ when type == typeof(ushort):
					return GetGenericValue<T>(GetElementUshortNullable(x, elementName));

				case Type _ when type == typeof(ulong):
					return GetGenericValue<T>(GetElementUlongNullable(x, elementName));

				case Type _ when type == typeof(byte):
					return GetGenericValue<T>(GetElementByteNullable(x, elementName));

				case Type _ when type == typeof(bool):
					return GetGenericValue<T>(GetElementBooleanNullable(x, elementName));

				case Type _ when type == typeof(DateTime):
					return GetGenericValue<T>(GetElementDateTimeNullable(x, elementName));

				case Type _ when type == typeof(Guid):
					return GetGenericValue<T>(GetElementGuidNullable(x, elementName));

				case Type _ when type == typeof(double):
					return GetGenericValue<T>(GetElementDoubleNullable(x, elementName));
				
				case Type _ when type == typeof(float):
					return GetGenericValue<T>(GetElementFloatNullable(x, elementName));

				case Type _ when type == typeof(string):
					return GetGenericValue<T>(GetElementString(x, elementName));

				case Type _ when type == typeof(char):
					return GetGenericValue<T>(GetElementCharNullable(x, elementName));

				default:
					return default(T);
			}
		}
		
		/// <summary>
		/// Safely gets the typed value of an attribute within a host XML element.
		/// </summary>
		/// <typeparam name="T">The type of the attribute to get.</typeparam>
		/// <param name="x">The host XElement.</param>
		/// <param name="elementName">Name of the attribute to get the value from.</param>
		/// <param name="defaultValue">The default value to return when the value could not be retrieved..</param>
		/// <returns>The typed value of the attribute, if could be retrieved, otherwise the default value.</returns>
		public static T AttributeValue<T>(this XElement x, string attributeName, T defaultValue = default(T))
		{
			Type type = typeof(T);
			object result;

			switch (type)
			{
				case Type _ when type == typeof(int):
					result = GetAttributeInt(x, attributeName, Convert.ToInt32(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(short):
					result = GetAttributeShort(x, attributeName, Convert.ToInt16(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(long):
					result = GetAttributeLong(x, attributeName, Convert.ToInt16(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(uint):
					result = GetAttributeUint(x, attributeName, Convert.ToUInt32(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(ushort):
					result = GetAttributeUshort(x, attributeName, Convert.ToUInt16(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(ulong):
					result = GetAttributeUlong(x, attributeName, Convert.ToUInt64(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(byte):
					result = GetAttributeByte(x, attributeName, Convert.ToByte(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(bool):
					result = GetAttributeBoolean(x, attributeName, Convert.ToBoolean(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(DateTime):
					result = GetAttributeDateTime(x, attributeName, Convert.ToDateTime(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(Guid):
					result = GetAttributeGuid(x, attributeName, ConvertToGuid(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(double):
					result = GetAttributeDouble(x, attributeName, Convert.ToDouble(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(float):
					result = GetAttributeFloat(x, attributeName, Convert.ToSingle(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(string):
					result = GetAttributeString(x, attributeName, Convert.ToString(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type == typeof(char):
					result = GetAttributeChar(x, attributeName, Convert.ToChar(defaultValue));
					return (T)Convert.ChangeType(result, typeof(T));

				case Type _ when type.BaseType == typeof(Enum):
					return (T)AttributeEnum(x, type, attributeName, default(T));

				default:
					return default(T);
			}
		}

		/// <summary>
		/// Gets the value of a typed nullable value of an attribute within a host XML element.
		/// </summary>
		/// <typeparam name="T">The type of the attribute to get.</typeparam>
		/// <param name="x">The host XElement.</param>
		/// <param name="elementName">Name of the attribute to get the value from.</param>
		/// <returns>The typed value of the attribute, if could be retrieved, otherwise null.</returns>
		public static T? AttributeValueNullable<T>(this XElement x, string attributeName)  where T : struct
		{
			Type type = typeof(T);

			switch (type)
			{
				case Type _ when type == typeof(int):
					return GetGenericValue<T>(GetAttributeIntNullable(x, attributeName));

				case Type _ when type == typeof(short):
					return GetGenericValue<T>(GetAttributeShortNullable(x, attributeName));

				case Type _ when type == typeof(long):
					return GetGenericValue<T>(GetAttributeLongNullable(x, attributeName));

				case Type _ when type == typeof(uint):
					return GetGenericValue<T>(GetAttributeUintNullable(x, attributeName));

				case Type _ when type == typeof(ushort):
					return GetGenericValue<T>(GetAttributeUshortNullable(x, attributeName));

				case Type _ when type == typeof(ulong):
					return GetGenericValue<T>(GetAttributeUlongNullable(x, attributeName));

				case Type _ when type == typeof(byte):
					return GetGenericValue<T>(GetAttributeByteNullable(x, attributeName));

				case Type _ when type == typeof(bool):
					return GetGenericValue<T>(GetAttributeBooleanNullable(x, attributeName));

				case Type _ when type == typeof(DateTime):
					return GetGenericValue<T>(GetAttributeDateTimeNullable(x, attributeName));

				case Type _ when type == typeof(Guid):
					return GetGenericValue<T>(GetAttributeGuidNullable(x, attributeName));

				case Type _ when type == typeof(double):
					return GetGenericValue<T>(GetAttributeDoubleNullable(x, attributeName));
				
				case Type _ when type == typeof(float):
					return GetGenericValue<T>(GetAttributeFloatNullable(x, attributeName));

				case Type _ when type == typeof(string):
					return GetGenericValue<T>(GetAttributeString(x, attributeName));

				case Type _ when type == typeof(char):
					return GetGenericValue<T>(GetAttributeCharNullable(x, attributeName));

				default:
					return default(T);
			}
		}
		#endregion
	}
}
