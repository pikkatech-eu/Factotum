/***********************************************************************************
* File:         XmlTools.ElementValues.cs                                          *
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
		#region Private Auxiliary
		private static T? GetGenericValue<T>(object result) where T : struct
		{
			if (result == null)
			{
				return null;
			}
			else
			{
				return (T)Convert.ChangeType(result, typeof(T));
			}
		}

		private static Guid ConvertToGuid<T>(T argument)
		{
			try
			{
				return new Guid(argument.ToString());
			}
			catch
			{
				return default(Guid);
			}
		}
		#endregion

		#region Private Typed Element Value Getters
		#region Integer Types
		private static int? GetElementIntNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			int result;

			if (Int32.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static int GetElementInt(this XElement x, XName elementName, int defaultValue = default(int))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			int result;

			if (Int32.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static short? GetElementShortNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			short result;

			if (Int16.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static short GetElementShort(this XElement x, XName elementName, short defaultValue = default(short))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			short result;

			if (Int16.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static long? GetElementLongNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			long result;

			if (Int64.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static long GetElementLong(this XElement x, XName elementName, long defaultValue = default(long))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			long result;

			if (Int64.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static uint? GetElementUintNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			uint result;

			if (UInt32.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static uint GetElementUint(this XElement x, XName elementName, uint defaultValue = default(uint))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			uint result;

			if (UInt32.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static ushort? GetElementUshortNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			ushort result;

			if (UInt16.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static ushort GetElementUshort(this XElement x, XName elementName, ushort defaultValue = default(ushort))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			ushort result;

			if (UInt16.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static ulong? GetElementUlongNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			ulong result;

			if (UInt64.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static ulong GetElementUlong(this XElement x, XName elementName, ulong defaultValue = default(ulong))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			ulong result;

			if (UInt64.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static byte? GetElementByteNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			byte result;

			if (Byte.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static byte GetElementByte(this XElement x, XName elementName, byte defaultValue = default(byte))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			byte result;

			if (Byte.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static bool? GetElementBooleanNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			bool result;

			if (Boolean.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static bool GetElementBoolean(this XElement x, XName elementName, bool defaultValue = default(bool))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			bool result;

			if (Boolean.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static DateTime? GetElementDateTimeNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			DateTime result;

			if (DateTime.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static DateTime GetElementDateTime(this XElement x, XName elementName, DateTime defaultValue = default(DateTime))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			DateTime result;

			if (DateTime.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static Guid? GetElementGuidNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			Guid result;

			if (Guid.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static Guid GetElementGuid(this XElement x, XName elementName, Guid defaultValue = default(Guid))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			Guid result;

			if (Guid.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		public static object ElementEnum(this XElement x, Type enumType, XName tag, object defaultValue)
		{
			if (x.Element(tag) == null)
			{
				return null;
			}

			try
			{
				return Enum.Parse(enumType, x.Element(tag).Value);
			}
			catch 
			{
				return defaultValue;
			}
		}
		#endregion

		#region Float Types
		private static double? GetElementDoubleNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			double result;

			if (Double.TryParse(xElement.Value, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static double GetElementDouble(this XElement x, XName elementName, double defaultValue = default(double))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			double result;

			if (Double.TryParse(xElement.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				return result;
			}
			else
			{
				return defaultValue;
			}
		}

		private static float? GetElementFloatNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}

			float result;


			if (Single.TryParse(xElement.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private static float GetElementFloat(this XElement x, XName elementName, float defaultValue = default(float))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}

			float result;

			if (Single.TryParse(xElement.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
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
		private static string GetElementString(this XElement x, XName elementName, string defaultValue = default(string))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}
			else
			{
				return xElement.Value;
			}
		}

		private static char GetElementChar(this XElement x, XName elementName, char defaultValue = default(char))
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return defaultValue;
			}
			else
			{
				if (xElement.Value.Length > 0)
				{
					return xElement.Value[0];
				}
				else
				{
					return defaultValue;
				}
			}
		}

		private static char? GetElementCharNullable(this XElement x, XName elementName)
		{
			XElement xElement = x.Element(elementName);

			if (xElement == null)
			{
				return null;
			}
			else if (xElement.Value.Length > 0)
			{
				return xElement.Value[0];
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
