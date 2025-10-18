/***********************************************************************************
* File:         Program.cs                                                         *
* Contents:     Class Program                                                      *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-08-21 16:04                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/


using Factotum.Idiophonus;
using Factotum.Maths;
using Factotum.Toml;

namespace Factotum.Tests
{
	public static class Program
	{
		public static void Main()
		{
			Language language = new Language();

			string text = language.Phrases(20);

			Console.WriteLine(text);

			//for (int i = 0; i < 10; i++)
			//{
			//	string phrase = language.Phrase();

			//	Console.WriteLine(phrase);
			//}
		}
	}
}
