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
	/// <summary>
	/// Semantic versioning (https://en.wikipedia.org/wiki/Software_versioning#Semantic_versioning)
	/// 
	/// Four-part version number (Major.Minor.Build.Revision). 
	/// Major: Breaking changes (high risk)
	/// Minor: New, non-breaking features (medium risk)
	/// Build: Other non-breaking changes (lowest risk)
	/// Revision: Revision number
	/// Stage: Alpha/Beta/Release
	/// Stage index: Number of the stageString (e.g. "alpha-1.2")
	/// </summary>
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

		public Stage	Stage		{get;set;} = Stage.None;
		public string	StageIndex	{get;set;} = "";
		#endregion

		#region Construction
		public Version()
		{
			DateTime now	= DateTime.Now;

			this.Major		= now.Year;
			this.Minor		= now.Month;
			this.Build		= now.Day;
			this.Revision	= 1;
		}

		public void FromToml(string fileName = DEFAULT_VERSION_FILE_NAME)
		{
			string currentFolder = Directory.GetCurrentDirectory();

			string currentVersionFile = Path.Combine(currentFolder, fileName);

			if (File.Exists(currentVersionFile))
			{
				Tomler tomler	= new Tomler();

				tomler.Load(currentVersionFile);

				this.Company	= tomler.GetValue("Version", "Company");
				this.Product	= tomler.GetValue("Version", "Product");
				this.Major		= tomler.GetValue("Version", "Major").ToNumber<int>();
				this.Minor		= tomler.GetValue("Version", "Minor").ToNumber<int>();
				this.Build		= tomler.GetValue("Version", "Build").ToNumber<int>();
				this.Revision	= tomler.GetValue("Version", "Revision").ToNumber<int>();

				string stageString	= tomler.GetValue("Version", "Stage");

				if (!String.IsNullOrEmpty(stageString))
				{
					Stage stage = Stage.None;
					if (Enum.TryParse<Stage>(stageString, out stage))
					{
						this.Stage = stage;
					}
				}

				this.StageIndex	= tomler.GetValue("Version", "StageIndex");
			}
		}

		public void ToToml(string fileName)
		{
			Tomler tomler	= new Tomler();

			tomler.AddSection("Version");

			tomler.SetValue("Version", "Company", this.Company?? "");
			tomler.SetValue("Version", "Product", this.Product?? "");
			tomler.SetValue("Version", "Major", this.Major);
			tomler.SetValue("Version", "Minor", this.Minor);
			tomler.SetValue("Version", "Build", this.Build);
			tomler.SetValue("Version", "Revision", this.Revision);
			tomler.SetValue("Version", "Stage", this.Stage);
			tomler.SetValue("Version", "StageIndex", this.StageIndex?? "");

			tomler.Save(fileName);
		}
		#endregion

		#region String Representation
		public override string ToString()
		{
			return $"{this.Major}.{this.Minor}.{this.Build}.{this.Revision}";
		}

		public string ToReleaseString()
		{
			string result = $"{this}";

			if (this.Stage != Stage.None)
			{
				result += $"_{this.Stage.ToString().ToLower()}";
			}

			if (!String.IsNullOrEmpty(this.StageIndex))
			{
				result += $"-{this.StageIndex}";
			}

			return result;
		}
		#endregion
	}
}
