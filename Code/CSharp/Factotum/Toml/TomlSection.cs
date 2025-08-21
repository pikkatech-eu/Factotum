/***********************************************************************************
* File:         TomlSection.cs                                                     *
* Contents:     Class TomlSection                                                  *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-08-21 15:17                                                   *
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
	internal class TomlSection
	{
		#region Properties
		public string						Name	{get;set;} = "";
		public Dictionary<string, string>	Items	= new Dictionary<string, string>();
		#endregion

		public override string ToString()
		{
			string result = $"[{this.Name}]\n";

			foreach (string key in this.Items.Keys)
			{
				result += $"{key} = {this.Items[key]}\n";
			}

			return result;
		}
	}
}
