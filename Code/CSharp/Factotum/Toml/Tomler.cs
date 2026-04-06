/***********************************************************************************
* File:         Tomler.cs                                                          *
* Contents:     Class Tomler                                                       *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-08-21 14:50                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Factotum.Toml
{
	/// <summary>
	/// Tomler is a simple TOML parser enabling it to read an write TOML files with simple values and sections.
	/// </summary>
	public class Tomler : ITomler
	{
		#region Internal Properties
		internal Dictionary<string, TomlSection>	Sections = new Dictionary<string, TomlSection>();
		#endregion

		#region I/O
		/// <summary>
		/// Loads a toml file from the file system.
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		/// <exception cref="IOException"> thrown if the file cannot be read.</exception>
		public void Load(string fileName)
		{
			using (StreamReader reader = new StreamReader(fileName))
			{
				string[] lines = reader.ReadToEnd().Split('\n');

				TomlSection tomlSection = null;

				for (int i = 0; i < lines.Length; i++)
				{
					string line = lines[i].Trim();

					if (line.StartsWith("%") || line.Length < 3)
					{
						continue;
					}

					if (line.StartsWith('[') && line.EndsWith(']'))
					{
						// new section
						string section = line[1..^1];
						tomlSection = new TomlSection();
						tomlSection.Name	= section;
						this.Sections.Add(section, tomlSection);

						tomlSection.Items.Clear();
					}
					else
					{
						// a key-value pair item
						string[] cells = line.Split('=');

						if (cells.Length != 2)
						{
							continue;
						}

						string key = cells[0].Trim();
						string value = cells[1].Trim();

						tomlSection.Items.Add(key, value);
					}
				}
			}
		}

		/// <summary>
		/// saves a toml file to the file system.
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		public void Save(string fileName)
		{
			string result = "";

			foreach (string section in this.Sections.Keys)
			{
				TomlSection tomlSection = this.Sections[section];
				result += tomlSection.ToString() + "\n";
			}

			using (StreamWriter writer = new StreamWriter(fileName))
			{
				writer.Write(result);
			}
		}
		#endregion

		#region Section Management
		/// <summary>
		/// Adds a new section with a given name.
		/// If the name already exists, nothing happens.
		/// </summary>
		/// <param name="section">The name of the section to add.</param>
		public void AddSection(string section)
		{
			if (this.Sections.ContainsKey(section))
			{
				return;
			}

			TomlSection tomlSection = new TomlSection{Name = section};
			this.Sections.Add(section, tomlSection);
		}

		/// <summary>
		/// Deletes a section.
		/// If the name of the section does not exist, nothing happens.
		/// </summary>
		/// <param name="section">The name of the section to delete.</param>
		public void DeleteSection(string section)
		{
			if (this.Sections.ContainsKey(section))
			{
				this.Sections.Remove(section);
			}
		}

		/// <summary>
		/// Gets a section as an array of strings.
		/// </summary>
		/// <param name="section">The name of the section to get.</param>
		/// <returns>Array of strings with "ke = Value" entries.</returns>
		public string[] GetSection(string section)
		{
			if (this.Sections.ContainsKey(section))
			{
				return this.Sections[section].ToString().Split('\n');
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Gets the list of all section names.
		/// </summary>
		/// <returns>The list of section names.</returns>
		public string[] GetSections()
		{
			return this.Sections.Keys.ToArray();
		}
		#endregion

		#region Value Management
		/// <summary>
		/// Gets the value by the section and key.
		/// </summary>
		/// <param name="section">The section name.</param>
		/// <param name="key">The key.</param>
		/// <returns>The value, if the key exists in the section.</returns>
		public string GetValue(string section, string key)
		{
			if (this.Sections.ContainsKey(section))
			{
				TomlSection tomlSection = this.Sections[section];

				if (tomlSection.Items.ContainsKey(key))
				{
					return tomlSection.Items[key];
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Sets a value to a section and a key.
		/// If the key already existed, it will be overwritten.
		/// </summary>
		/// <param name="section">The section name.</param>
		/// <param name="key">The key.</param>
		/// <param name="value">The value to set.</param>
		public void SetValue(string section, string key, object value)
		{
			if (this.Sections.ContainsKey(section))
			{
				TomlSection tomlSection = this.Sections[section];

				tomlSection.Items[key] = value.ToString();
			}
		}

		/// <summary>
		/// Deletes a value from a section.
		/// If the key does not exist, nothing happens.
		/// </summary>
		/// <param name="section">The section name.</param>
		/// <param name="key">The key to delete.</param>
		public void DeleteValue(string section, string key)
		{
			if (this.Sections.ContainsKey(section))
			{
				TomlSection tomlSection = this.Sections[section];

				if (tomlSection.Items.ContainsKey(key))
				{
					tomlSection.Items.Remove(key);
				}
			}
		}
		#endregion

		#region Extended Gets
		/// <summary>
		/// Added for convenience.
		/// Tries to get an integer value.
		/// </summary>
		/// <param name="section">The section name.</param>
		/// <param name="key">The key.</param>
		/// <returns>The integer value, if the entry is of an integer type.</returns>
		/// <exception cref="ArgumentException">Thrown if the string value cannot be converted to an integer.</exception>
		public int GetInteger(string section, string key)
		{
			try
			{
				return Int32.Parse(this.GetValue(section, key));
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Added for convenience.
		/// Tries to get a double value.
		/// </summary>
		/// <param name="section">The section name.</param>
		/// <param name="key">The key.</param>
		/// <returns>The double value, if the entry is of a real type.</returns>
		/// <exception cref="ArgumentException">Thrown if the string value cannot be converted to a double.</exception>
		public double GetDouble(string section, string key)
		{
			try
			{
				return Double.Parse(this.GetValue(section, key));
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Added for convenience.
		/// Tries to get a Boolean value.
		/// </summary>
		/// <param name="section">The section name.</param>
		/// <param name="key">The key.</param>
		/// <returns>The Boolean value, if the entry is of Boolean type.</returns>
		/// <exception cref="ArgumentException">Thrown if the string value cannot be converted to a Boolean.</exception>
		public bool GetBoolean(string section, string key)
		{
			try
			{
				return Boolean.Parse(this.GetValue(section, key));
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Added for convenience.
		/// Tries to get a DateTime value.
		/// </summary>
		/// <param name="section">The section name.</param>
		/// <param name="key">The key.</param>
		/// <returns>The DateTime value, if the entry is of DateTime type.</returns>
		/// <exception cref="ArgumentException">Thrown if the string value cannot be converted to a DateTime.</exception>
		public DateTime GetDateTime(string section, string key)
		{
			try
			{
				return DateTime.Parse(this.GetValue(section, key));
			}
			catch (Exception)
			{
				throw;
			}
		}
		#endregion
	}
}
