/***********************************************************************************
* File:         Program.cs                                                         *
* Contents:     Class Program                                                      *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-08-21 16:04                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using Factotum.Maths;
using Factotum.Toml;

namespace Factotum.Tests
{
	public static class Program
	{
		public static void Main()
		{
			Maths.DiscreteRandomizer r = new Maths.DiscreteRandomizer([2, 3, 5]);

			//for (int i = 0; i < 10; i++)
			//{
			//	int randomIndex = r.RandomIndex();
			//}
			
			string[] strings = {"miau", "hru", "ia"};

			string random = r.RandomObject<string>(strings);

			object[] objects = [42, 2.87, DateTime.Now];

			object randomObject = r.RandomObject(objects);
		}
	}
}
