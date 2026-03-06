/***********************************************************************************
* File:         XmlTools.cs                                                        *
* Contents:     Class XmlTools                                                     *
* Author:       Stanislav Koncebovski (stanislav@pikkatech.eu)                     *
* Date:         2020-03-19 14:56                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Factotum.Xml
{
	/// <summary>
	/// Extension methods for XElement to append elements and attributres and to safely access their values.
	/// </summary>
	public static partial class XmlTools
	{
		#region Public Features
		/// <summary>
		/// Shortcut for adding attributes to an XElement (less to type than x.Add(new XAttribute("key", value));).
		/// </summary>
		/// <param name="x">The element to append value to.</param>
		/// <param name="key">The key with which to append.</param>
		/// <param name="value">The value to append.</param>
		public static void AppendAttribute(this XElement x, string key, object value)
		{
			if (value == null)
			{
				return;
			}

			try
			{
				x. Add(new XAttribute(key, value));
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Shortcut for adding elements to an XElement (less to type than x.Add(new XElement("name", value));).
		/// </summary>
		/// <param name="x">The element to append value to.</param>
		/// <param name="tag">The tag with which to append.</param>
		/// <param name="value">The value to append.</param>
		public static void AppendElement(this XElement x, string tag, object value)
		{
			if (value == null)
			{
				return;
			}

			try
			{
				x. Add(new XElement(tag, value));
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Appends a collection of items by creating a collection node in the XML structure and adding all individual elements to it.
		/// </summary>
		/// <typeparam name="T">The type of the items to add.</typeparam>
		/// <param name="x">The element to append the collection value to.</param>
		/// <param name="items">
		///		The collection of items to append. The items are supposed to be all of the same type T (no polymorphic collections).
		///	</param>
		/// <param name="tagItem">The tag with which each item will be represented in the XML structure.</param>
		/// <param name="tagItems">
		///		The tag of the collection item. 
		///		If set to null (default), the collection tag will be created from the item tag by adding an "s" to it.
		/// </param>
		/// <example>
		///		XElement x = new XElement("main");
		///		double[] prices = {2.87, 3.62, 4.12};
		///		x.AppendElements<double>(prices, "price");
		///		
		/// The resulting XML will be
		///		<main>
		///			<prices>
		///				<price>2.87</price>
		///				<price>3.62</price>
		///				<price>4.12</price>
		///			</prices>
		///		</main>
		/// </example>
		public static void AppendElements<T>(this XElement x, IEnumerable<T> items, string tagItem, string tagItems = null) 
		{
			string tagItemsWork = String.IsNullOrEmpty(tagItems) ? $"{tagItem}s" : tagItems;

			XElement xItems	= new XElement(tagItemsWork);
			x.Add(xItems);

			foreach (T item in items)
			{
				try
				{
					xItems.Add(new XElement(tagItem, item));
				}
				catch {}				
			}
		}

		/// <summary>
		/// Appends a dictionary of items by creating a collection node in the XML structure and adding all individual elements to it.
		/// </summary>
		/// <typeparam name="K">The type of the key.</typeparam>
		/// <typeparam name="T">The type of the item values.</typeparam>
		/// <param name="x">The element to append the collection value to.</param>
		/// <param name="dictionary">The dictionary to append. The values are supposed to be all of the same type T (no polymorphism of values).</param>
		/// <param name="tagItem">The tag with which each item will be represented in the XML structure.</param>
		/// <param name="tagItems">
		/// 	The tag of the collection item. 
		///		If set to null (default), the collection tag will be created from the item tag by adding an "s" to it.
		/// </param>
		/// <param name="tagKey">The name for the key attribute in the XML structure. Default: "Key".</param>
		/// <example>
		///		Dictionary<int, double> dictionary = new Dictionary<int, double>();
		///		dictionary.Add(42, 2.87);
		///		dictionary.Add(69, 3.62);
		///		x.AppendDictionary<int, double>(dictionary, "price");
		/// 
		/// Produces the following XML:
		///		<main>
		///			<prices>
		///				<price Key="42">2.87</price>
		///				<price Key="69">3.62</price>
		///			</prices>
		///		</main>
		/// </example>
		public static void AppendDictionary<K, T>(this XElement x, Dictionary<K, T> dictionary, string tagItem, string tagItems = null, string tagKey = "Key")
		{
			string tagItemsWork = String.IsNullOrEmpty(tagItems) ? $"{tagItem}s" : tagItems;

			XElement xItems	= new XElement(tagItemsWork);

			x.Add(xItems);

			foreach (K key in dictionary.Keys)
			{
				T item = dictionary[key];

				if (item != null)
				{
					XElement xItem	= new XElement(tagItem, new XAttribute(tagKey, key), item);
					xItems.Add(xItem);
				}
			}
		}

		/// <summary>
		/// Safely gets the typed value of an element within a host XML element.
		/// </summary>
		/// <typeparam name="T">The type of the element to get.</typeparam>
		/// <param name="x">The host XElement.</param>
		/// <param name="elementName">Name of the element to get the value from.</param>
		/// <param name="defaultValue">The default value to return when the value could not be retrieved.</param>
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

		/// <summary>
		/// Gets a collection value from an XML element (as a list).
		/// </summary>
		/// <typeparam name="T">The type of the list values.</typeparam>
		/// <param name="x">The host XElement.</param>
		/// <param name="tagItem">The tag with which each item is represented in the XML structure.</param>
		/// <param name="tagItems">
		/// 	The tag of the collection item. 
		///		If set to null (default), the collection tag will be created from the item tag by adding an "s" to the item tag.
		/// </param>
		/// <returns>List of values of type T.</returns>
		public static List<T> ListValue<T>(this XElement x, string tagItem, string tagItems = null) 
		{
			string tagItemsWork = String.IsNullOrEmpty(tagItems) ? $"{tagItem}s" : tagItems;

			XElement xItems	= x.Element(tagItemsWork);

			List<T> result = new List<T>();

			if (xItems != null)
			{
				foreach (XElement xItem in xItems.Elements(tagItem))
				{
					T item	= (T)Convert.ChangeType(xItem.Value, typeof(T));

					result.Add(item);
				}
			}

			return result;
		}

		/// <summary>
		///		Gets a dictionary value from an XML element.
		/// </summary>
		/// <typeparam name="K">The type of the key.</typeparam>
		/// <typeparam name="T">The type of the dictionary values.</typeparam>
		/// <param name="x">The host XElement.</param>
		/// <param name="tagItem">The tag with which each item is represented in the XML structure.</param>
		/// <param name="tagItems">
		/// 	The tag of the collection item. 
		///		If set to null (default), the collection tag will be created from the item tag by adding an "s" to the item tag.
		/// </param>
		/// <param name="tagKey">The name for the key attribute in the XML structure. Default: "Key".</param>
		/// <returns>Dictionary of defined type.</returns>
		public static Dictionary<K, T> DictionaryValue<K, T> (this XElement x, string tagItem, string tagItems = null, string tagKey = "Key") where T : struct
		{
			string tagItemsWork = String.IsNullOrEmpty(tagItems) ? $"{tagItem}s" : tagItems;

			XElement xItems	= x.Element(tagItemsWork);

			Dictionary<K, T> result = new Dictionary<K, T>();

			if (xItems != null)
			{
				foreach (XElement xItem in xItems.Elements(tagItem))
				{
					K key = xItem.AttributeValue<K>(tagKey);
					T value = (T)Convert.ChangeType(xItem.Value, typeof(T));

					result.Add(key, value);
				}
			}

			return result;
		}

		/// <summary>
		/// Renames an XML tag.
		/// </summary>
		/// <param name="x">The instance of XElement to rename.</param>
		/// <param name="newName">The new name of the element.</param>
		/// <returns>XElement instance with the new name.</returns>
		public static XElement Rename(this XElement x, string newName)
		{
			x.Name = newName;
			return x;
		}
		#endregion
	}
}
