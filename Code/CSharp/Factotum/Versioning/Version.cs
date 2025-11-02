/***********************************************************************************
* File:         Version.cs                                                         *
* Contents:     Class Version                                                      *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-09-29 17:06                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using Factotum.Toml;
using Factotum.Tools;

namespace Factotum.Versioning
{
	public class Version
	{
		private static readonly string DEFAULT_COMPANY = "Pikkatech";
		private const string DEFAULT_VERSION_FILE_NAME = "version.toml";

		#region Properties
		public string	Company		{get;set;}	= DEFAULT_COMPANY;
		public string	Product		{get;set;}	= "";

		public int		Major		{get;set;}	= 0;
		public int		Minor		{get;set;}	= 0;
		public int		Build		{get;set;}	= 0;
		public int		Revision	{get;set;}	= 0;

		public string	Stage		{get;set;} = "";
		public string	StageIndex	{get;set;} = "";
		#endregion

		#region Construction
		public Version()
		{
			DateTime now	= DateTime.Now;

			this.Major		= now.Year;
			this.Minor		= now.Month;
			this.Build		= now.Day;
			this.Revision	= 0;
		}

		public void FromToml(string fileName = DEFAULT_VERSION_FILE_NAME)
		{
			string currentFolder = Directory.GetCurrentDirectory();

			string currentVersionFile = Path.Combine(currentFolder, fileName);

			if (File.Exists(currentVersionFile))
			{
				Tomler tomler = new Tomler();

				tomler.Load(currentVersionFile);

				this.Major		= tomler.GetValue("Version", "Major").ToNumber<int>();
				this.Minor		= tomler.GetValue("Version", "Minor").ToNumber<int>();
				this.Build		= tomler.GetValue("Version", "Build").ToNumber<int>();
				this.Revision	= tomler.GetValue("Version", "Revision").ToNumber<int>();
			}
		}
		#endregion

		#region String Representation
		public override string ToString()
		{
			return $"{this.Major}.{this.Minor}.{this.Build}.{this.Revision}";
		}
		#endregion
	}
}
