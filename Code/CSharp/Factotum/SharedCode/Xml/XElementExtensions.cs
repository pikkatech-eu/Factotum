/***********************************************************************************
* File:         XElementExtensions.cs                                              *
* Contents:     Class XElementExtensions                                           *
* Author:       Stanislav Koncebovski (stanislav@pikkatech.eu)                     *
* Date:         2023-10-11 2243                                                    *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/
using System;
using System.Reflection;
using System.Xml.Linq;

namespace Factotum.Xml
{
	public static class XElementExtensions
	{
		/// <summary>
		/// Changing the name of an XElement "on the fly".
		/// </summary>
		/// <param name="x">The element the name of which to change.</param>
		/// <param name="name">The new name.</param>
		/// <returns>The element with the new name.</returns>
		public static XElement ChangeName(this XElement x, string name)
		{
			x.Name = name;
			return x;
		}

		/// <summary>
		/// Safe adding a subelement to an element.
		/// If the subelement is not null, it will be added, otherwise nothing happens.
		/// </summary>
		/// <param name="x">The element to which to add a sub-element.</param>
		/// <param name="xChild">The subelement to add (may be null).</param>
		/// <param name="newName">Optionally the new name under which to add the subelement.</param>
		public static void AddSafe(this XElement x, XElement xChild, string newName = null)
		{
			if (xChild != null)
			{
				if (!String.IsNullOrEmpty(newName))
				{
					xChild.Name = newName;
				}

				x.Add(xChild);
			}
		}

		/// <summary>
		/// Adds safely the result of the ToXElement() method for a property as applied to an owner object (the owner of the property).
		/// If the property's value is not null, its XElement will be added to the parent XElement, optionally under a new name.
		/// If the vale of the property is null, nothing happens.
		/// </summary>
		/// <param name="x">The parent element to which to add the property's subelement.</param>
		/// <param name="owner">The owner instance of the property.</param>
		/// <param name="propertyName">The name of the property.</param>
		/// <param name="newName">Optional new name to be used in the XElement.</param>
		public static void AddSafe(this XElement x, object owner, string propertyName, string newName = null)
		{
			PropertyInfo property = owner.GetType().GetProperty(propertyName);

			if (property == null)
			{
				return;
			}

			var value = property.GetValue(owner, null);

			if (value != null)
			{
				MethodInfo method = value.GetType().GetMethod("ToXElement");
				XElement xChild = method.Invoke(value, null) as XElement;

				if (!String.IsNullOrEmpty(newName))
				{
					xChild.Name = newName;
				}

				x.Add(xChild);
			}
		}
	}
}
