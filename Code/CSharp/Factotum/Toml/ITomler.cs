/***********************************************************************************
* File:         ITomler.cs                                                         *
* Contents:     Interface ITomler                                                  *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-08-21 15:02                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factotum.Toml
{
	/// <summary>
	/// Defines a simple TOML parser with the functionality to read an write TOML files with simple values and sections.
	/// </summary>
	public interface ITomler
	{
		/// <summary>
		/// Loads a toml file from the file system.
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		/// <exception cref="IOException"> thrown if the file cannot be read.</exception>
		void Load(string fileName);

		/// <summary>
		/// saves a toml file to the file system.
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		void Save(string fileName);

		#region Section Management
		/// <summary>
		/// Adds a new section with a given name.
		/// If the name already exists, nothing happens.
		/// </summary>
		/// <param name="section">The name of the section to add.</param>
		void AddSection(string section);

		/// <summary>
		/// Deletes a section.
		/// If the name of the section does not exist, nothing happens.
		/// </summary>
		/// <param name="section">The name of the section to delete.</param>
		void DeleteSection(string section);

		/// <summary>
		/// Gets a section as an array of strings.
		/// </summary>
		/// <param name="section">The name of the section to get.</param>
		/// <returns>Array of strings with "ke = Value" entries.</returns>
		string[] GetSection(string section);

		/// <summary>
		/// Gets the list of all section names.
		/// </summary>
		/// <returns>The list of section names.</returns>
		string[] GetSections();
		#endregion

		#region Value Management
		/// <summary>
		/// Gets the value by the section and key.
		/// </summary>
		/// <param name="section">The section name.</param>
		/// <param name="key">The key.</param>
		/// <returns>The value, if the key exists in the section.</returns>
		object GetValue(string section, string key);

		/// <summary>
		/// Sets a value to a section and a key.
		/// If the key already existed, it will be overwritten.
		/// </summary>
		/// <param name="section">The section name.</param>
		/// <param name="key">The key.</param>
		/// <param name="value">The value to set.</param>
		void SetValue(string section, string key, object value);

		/// <summary>
		/// Deletes a value from a section.
		/// If the key does not exist, nothing happens.
		/// </summary>
		/// <param name="section">The section name.</param>
		/// <param name="key">The key to delete.</param>
		void DeleteValue(string section, string key);
		#endregion
	}
}
