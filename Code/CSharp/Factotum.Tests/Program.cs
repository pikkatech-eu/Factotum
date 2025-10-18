/***********************************************************************************
* File:         Program.cs                                                         *
* Contents:     Class Program                                                      *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-08-21 16:04                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/


using Factotum.Maths;
using Factotum.Text;
using Factotum.Toml;

namespace Factotum.Tests
{
	public static class Program
	{
		public static void Main()
		{
			Idiophonus language = new Idiophonus();

			string text = language.Phrases(20);

			Console.WriteLine(text);

			string json = language.ToJson();
			//for (int i = 0; i < 10; i++)
			//{
			//	string phrase = language.Phrase();

			//	Console.WriteLine(phrase);
			//}
		}
	}
}
