/***********************************************************************************
* File:         XmlTools.AttributeValues.cs                                        *
* Contents:     Class XmlTools                                                     *
* Author:       Stanislav Koncebovski (stanislav@pikkatech.eu)                     *
* Date:         2021-09-29 09:18                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/
using System;
using System.Globalization;
using System.Xml.Linq;

namespace Factotum.Xml
{
	public static partial class XmlTools
	{
		#region Private Typed Element Value Getters
		#region Integer Types
		private static int? GetAttributeIntNullable(this XElement x, string attributeName)
		{
			XAttribute xAttribute = x.Attribute(attributeName);

			if (xAttribute == null)
			{
				return null;
			}

			int result;

			if (Int32.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static int GetAttributeInt(this XElement x, string attributeName, int defaultValue = default(int))
		{
			XAttribute xAttribute = x.Attribute(attributeName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			int result;

			if (Int32.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static short? GetAttributeShortNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			short result;

			if (Int16.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static short GetAttributeShort(this XElement x, string elementName, short defaultValue = default(short))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			short result;

			if (Int16.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static long? GetAttributeLongNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			long result;

			if (Int64.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static long GetAttributeLong(this XElement x, string elementName, long defaultValue = default(long))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			long result;

			if (Int64.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static uint? GetAttributeUintNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			uint result;

			if (UInt32.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static uint GetAttributeUint(this XElement x, string elementName, uint defaultValue = default(uint))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			uint result;

			if (UInt32.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static ushort? GetAttributeUshortNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			ushort result;

			if (UInt16.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static ushort GetAttributeUshort(this XElement x, string elementName, ushort defaultValue = default(ushort))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			ushort result;

			if (UInt16.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static ulong? GetAttributeUlongNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			ulong result;

			if (UInt64.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static ulong GetAttributeUlong(this XElement x, string elementName, ulong defaultValue = default(ulong))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			ulong result;

			if (UInt64.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static byte? GetAttributeByteNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			byte result;

			if (Byte.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static byte GetAttributeByte(this XElement x, string elementName, byte defaultValue = default(byte))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			byte result;

			if (Byte.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static bool? GetAttributeBooleanNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			bool result;

			if (Boolean.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static bool GetAttributeBoolean(this XElement x, string elementName, bool defaultValue = default(bool))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			bool result;

			if (Boolean.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static DateTime? GetAttributeDateTimeNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			DateTime result;

			if (DateTime.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static DateTime GetAttributeDateTime(this XElement x, string elementName, DateTime defaultValue = default(DateTime))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			DateTime result;

			if (DateTime.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static Guid? GetAttributeGuidNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			Guid result;

			if (Guid.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static Guid GetAttributeGuid(this XElement x, string elementName, Guid defaultValue = default(Guid))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			Guid result;

			if (Guid.TryParse(xAttribute.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		public static object AttributeEnum(this XElement x, Type enumType, string tag, object defaultValue)
		{
			if (x.Attribute(tag) == null)
			{
				return null;
			}

			try
			{
				return Enum.Parse(enumType, x.Attribute(tag).Value);
			}
			catch 
			{
				return defaultValue;
			}
		}
		#endregion

		#region Float Types
		private static double? GetAttributeDoubleNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			double result;

			if (Double.TryParse(xAttribute.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static double GetAttributeDouble(this XElement x, string elementName, double defaultValue = default(double))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			double result;

			if (Double.TryParse(xAttribute.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static float? GetAttributeFloatNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}

			float result;

			if (Single.TryParse(xAttribute.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static float GetAttributeFloat(this XElement x, string elementName, float defaultValue = default(float))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}

			float result;

			if (Single.TryParse(xAttribute.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}
		#endregion

		#region Text Types
		private static string GetAttributeString(this XElement x, string elementName, string defaultValue = default(string))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}
			else
			{
				return xAttribute.Value;
			}
		}

		private static char GetAttributeChar(this XElement x, string elementName, char defaultValue = default(char))
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return defaultValue;
			}
			else
			{
				if (xAttribute.Value.Length > 0)
				{
					return xAttribute.Value[0];
				}
				else
				{
					return defaultValue;
				}
			}
		}

		private static char? GetAttributeCharNullable(this XElement x, string elementName)
		{
			XAttribute xAttribute = x.Attribute(elementName);

			if (xAttribute == null)
			{
				return null;
			}
			else if (xAttribute.Value.Length > 0)
			{
				return xAttribute.Value[0];
			}
			else
			{
				return null;
			}
		}
		#endregion
		#endregion
	}
}
