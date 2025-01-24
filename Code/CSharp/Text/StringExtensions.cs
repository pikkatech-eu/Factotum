/***********************************************************************************
* File:         StringExtensions.cs                                                *
* Contents:     Class StringExtensions                                             *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2024-10-08 19:00                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;

namespace Factotum.Text
{
	public static class StringExtensions
	{
		#region Private Data
		private static Dictionary<string, string> FOREIGN_CHARACTERS = new Dictionary<string, string>
		{
			{ "'", "" },
			{ "äæǽ", "ae" },
			{ "öœ", "oe" },
			{ "ü", "ue" },
			{ "Ä", "Ae" },
			{ "Ü", "Ue" },
			{ "Ö", "Oe" },
			{ "ÀÁÂÃÄÅǺĀĂĄǍΑΆẢẠẦẪẨẬẰẮẴẲẶА", "A" },
			{ "àáâãåǻāăąǎªαάảạầấẫẩậằắẵẳặа", "a" },
			{ "Б", "B" },
			{ "б", "b" },
			{ "ÇĆĈĊČ", "C" },
			{ "çćĉċč", "c" },
			{ "Д", "D" },
			{ "д", "d" },
			{ "ÐĎĐΔ", "Dj" },
			{ "ðďđδ", "dj" },
			{ "ÈÉÊËĒĔĖĘĚΕΈẼẺẸỀẾỄỂỆЕЭ", "E" },
			{ "èéêëēĕėęěέεẽẻẹềếễểệеэ", "e" },
			{ "Ф", "F" },
			{ "ф", "f" },
			{ "ĜĞĠĢΓГҐ", "G" },
			{ "ĝğġģγгґ", "g" },
			{ "ĤĦ", "H" },
			{ "ĥħ", "h" },
			{ "ÌÍÎÏĨĪĬǏĮİΗΉΊΙΪỈỊИЫ", "I" },
			{ "ìíîïĩīĭǐįıηήίιϊỉịиыї", "i" },
			{ "Ĵ", "J" },
			{ "ĵ", "j" },
			{ "ĶΚК", "K" },
			{ "ķκк", "k" },
			{ "ĹĻĽĿŁΛЛ", "L" },
			{ "ĺļľŀłλл", "l" },
			{ "М", "M" },
			{ "м", "m" },
			{ "ÑŃŅŇΝН", "N" },
			{ "ñńņňŉνн", "n" },
			{ "ÒÓÔÕŌŎǑŐƠØǾΟΌΩΏỎỌỒỐỖỔỘỜỚỠỞỢО", "O" },
			{ "òóôõōŏǒőơøǿºοόωώỏọồốỗổộờớỡởợо", "o" },
			{ "П", "P" },
			{ "п", "p" },
			{ "ŔŖŘΡР", "R" },
			{ "ŕŗřρр", "r" },
			{ "ŚŜŞȘŠΣС", "S" },
			{ "śŝşșšſσςс", "source" },
			{ "ȚŢŤŦτТ", "T" },
			{ "țţťŧт", "t" },
			{ "ÙÚÛŨŪŬŮŰŲƯǓǕǗǙǛŨỦỤỪỨỮỬỰУ", "U" },
			{ "ùúûũūŭůűųưǔǖǘǚǜυύϋủụừứữửựу", "u" },
			{ "ÝŸŶΥΎΫỲỸỶỴЙ", "Y" },
			{ "ýÿŷỳỹỷỵй", "y" },
			{ "В", "V" },
			{ "в", "v" },
			{ "Ŵ", "W" },
			{ "ŵ", "w" },
			{ "ŹŻŽΖЗ", "Z" },
			{ "źżžζз", "z" },
			{ "ÆǼ", "AE" },
			{ "ß", "ss" },
			{ "Ĳ", "IJ" },
			{ "ĳ", "ij" },
			{ "Œ", "OE" },
			{ "ƒ", "f" },
			{ "ξ", "ks" },
			{ "π", "p" },
			{ "β", "v" },
			{ "μ", "m" },
			{ "ψ", "ps" },
			{ "Ё", "Yo" },
			{ "ё", "yo" },
			{ "Є", "Ye" },
			{ "є", "ye" },
			{ "Ї", "Yi" },
			{ "Ж", "Zh" },
			{ "ж", "zh" },
			{ "Х", "Kh" },
			{ "х", "kh" },
			{ "Ц", "Ts" },
			{ "ц", "ts" },
			{ "Ч", "Ch" },
			{ "ч", "ch" },
			{ "Ш", "Sh" },
			{ "ш", "sh" },
			{ "Щ", "Shch" },
			{ "щ", "shch" },
			{ "ЪъЬь", "" },
			{ "Ю", "Yu" },
			{ "ю", "yu" },
			{ "Я", "Ya" },
			{ "я", "ya" },
		};
		#endregion

		#region Public Features
		/// <summary>
		/// Extension method.
		/// Normalizes a source word by replacing non-ANSI characters with their ANSI mappings.
		/// </summary>
		/// <param name="source">The word to normalize.</param>
		/// <returns>The normalized word.</returns>
		public static string ToAscii(this string source)
		{
			string text = "";

			foreach (char c in source)
			{
				int len = text.Length;

				foreach (KeyValuePair<string, string> entry in FOREIGN_CHARACTERS)
				{
					if (entry.Key.IndexOf(c) != -1)
					{
						text += entry.Value;
						break;
					}
				}

				if (len == text.Length)
				{
					text += c;
				}
			}
			return text;
		}

		/// <summary>
		/// Deletes consecutive characters in a word.
		/// </summary>
		/// <param name="word">Word to delete consecutive characters in.</param>
		/// <returns>The word with consecutive characters removed.</returns>
		public static string DeleteConsecutiveRepeats(this string word)
		{
			if (String.IsNullOrEmpty(word))
			{
				return word;
			}

			string result = word.Substring(0, 1);

			int i = 1;

			while (i < word.Length)
			{
				if (word[i] != result[result.Length - 1])
				{
					result += word[i];
				}

				i++;
			}

			return result;
		}
		#endregion
	}
}
