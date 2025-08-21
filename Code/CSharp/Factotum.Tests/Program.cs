/***********************************************************************************
* File:         Program.cs                                                         *
* Contents:     Class Program                                                      *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-08-21 16:04                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using Factotum.Toml;

namespace Factotum.Tests
{
	public static class Program
	{
		public static void Main()
		{
			Tomler tomler = new Tomler();

			tomler.AddSection("Cats");
			tomler.SetValue("Cats", "Name", "Gregory");
			tomler.SetValue("Cats", "Age", "3");
			tomler.SetValue("Cats", "Weight", "2.87");

			tomler.AddSection("Dogs");
			tomler.SetValue("Dogs", "Name", "Ferenc");
			tomler.SetValue("Dogs", "BirthDate", DateTime.Now);

			string fileName = "test.toml";

			tomler.Save(fileName);

			Tomler tomler1 = new Tomler();

			tomler1.Load(fileName);

			double weight = tomler1.GetDouble("Cats", "Weight");
		}
	}
}
