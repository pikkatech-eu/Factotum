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
using static System.Net.Mime.MediaTypeNames;

namespace Factotum.Text
{
	/// <summary>
	/// Extensions for the String class.
	/// </summary>
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

		private static Dictionary<char, char> EASTERN_ARABIC_NUMERALS = new Dictionary<char, char>
		{
			['0'] =	'٠',
			['1'] =	'١',
			['2'] =	'٢',
			['3'] =	'٣',
			['4'] =	'٤',
			['5'] =	'٥',
			['6'] =	'٦',
			['7'] =	'٧',
			['8'] =	'٨',
			['9'] =	'٩'
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

		/// <summary>
		/// Capitalization of a word.
		/// </summary>
		/// <param name="word">The word to capitalize.</param>
		/// <returns>The word capitalized.</returns>
		public static string Capitalize(this string word)
		{
			if (String.IsNullOrEmpty(word))
			{
				return word;
			}
			else if (word.Length == 1)
			{
				return word.ToUpper();
			}
			else
			{
				return $"{word.Substring(0, 1).ToUpper()}{word.Substring(1)}";
			}
		}

		/// <summary>
		/// Converts a string containing Western Arabic numerals (0..9) to Eastern Arabis numerals (٠..٩).
		/// </summary>
		/// <param name="word">The word to perform conversion on.</param>
		/// <returns>Resulting word with Arabic numerals converted.</returns>
		public static string ToEasternArabicNumerals(this string word)
		{
			char[] result = word.ToCharArray();

			for (int i = 0; i < result.Length; i++)
			{
				if (EASTERN_ARABIC_NUMERALS.ContainsKey(result[i]))
				{
					result[i]	= EASTERN_ARABIC_NUMERALS[result[i]];
				}
			}

			return new string(result);
		}

		/// <summary>
		/// Truncates a word up to a defined length.
		/// </summary>
		/// <param name="word">The word to truncate.</param>
		/// <param name="length">The length to truncate to.</param>
		/// <returns>The word itself, if it is not longer than length, otherwise the initial substring of length.</returns>
		public static string Truncate(this string word, int length)
		{
			if (word.Length <= length)
			{
				return word;
			}
			else
			{
				return word.Substring(0, length);
			}
		}

		/// <summary>
		/// Defines scripts used in a probe string.
		/// </summary>
		/// <param name="source">The source probe string.</param>
		/// <param name="ignoreUnsupported">If set to true (default), all unsupported characters are ignored.</param>
		/// <returns>
		///		Dictionary of frequencies, where the key is the ISO 15294 code of the script, 
		///		value its relative frequency in the probe string.
		///	</returns>
		/// <exception cref="ArgumentException">Thrown if the argument string is null.</exception>
		public static Dictionary<string, double> GetWritingScripts(this string source, bool ignoreUnsupported = true)
		{
			if (source == null)
			{
				throw new ArgumentException("Argument string is null");
			}

			Dictionary<string, double>	occurrences = new Dictionary<string, double>();

			int length = 0;

			foreach (var rune in source.EnumerateRunes())
			{
				string script = GetCharScript(rune.Value);

				if (script == "Zzzz" && ignoreUnsupported)
				{
					continue;
				}

				if (!occurrences.ContainsKey(script))
				{
					occurrences.Add(script, 0);
				}

				occurrences[script]++;
				length ++;
			}

			foreach (string code in occurrences.Keys)
			{
				occurrences[code] /= length;
			}

			return occurrences;
		}

		/// <summary>
		/// Tries to define the presumably only script of a probe string.
		/// </summary>
		/// <param name="source">The probe string.</param>
		/// <param name="ignoreUnsupported">If set to true (default), all unsupported characters are ignored.</param>
		/// <returns>The ISO 15294 code of the script, if it is the only one used, otherwise "Zzzz" (undetermined script).</returns>
		public static string GetWritingScript(this string source, bool ignoreUnsupported = true)
		{
			Dictionary<string, double> frequencies = GetWritingScripts(source, ignoreUnsupported);

			if (frequencies.Count == 1)
			{
				return frequencies.Keys.ToArray()[0];
			}
			else
			{
				return "Zyyy";
			}
		}

		/// <summary>
		/// Attempt to infer language from script.
		/// </summary>
		/// <param name="iso15924">ISO 15924 code of the script.</param>
		/// <returns>
		///		Attemptive ISO 639 code of the language, if supported, 
		///		otherwise "und" (ISO 639 'undefined').
		///	</returns>
		public static string? InferLikelyLanguage(this string iso15924)
		{
			return iso15924 switch
			{
				"Grek" => "ell",
				"Armn" => "hye",
				"Geor" => "kat",
				"Hang" => "kor",
				"Hebr" => "heb",
				"Copt" => "cop",
				"Thai" => "tha",
				"Hira" => "ja",
				"Kana" => "ja",
				_	   => "und"
			};
		}

		/// <summary>
		/// Defines the Unicode range of a character.
		/// </summary>
		/// <param name="codePoint">Integer value of the charecter.</param>
		/// <returns>
		///		ISO 15294 code of the character, if the Unicode range is presently supported, otherwise "Zzzz".
		///	</returns>
		private static string GetCharScript(int codePoint)
		{
			return codePoint switch
			{
				>= 0x0041 and <= 0x024F => "Latn",
				>= 0x0370 and <= 0x03FF => "Grek",
				>= 0x0400 and <= 0x052F => "Cyrl",
				>= 0x0590 and <= 0x05FF => "Hebr",
				>= 0x0600 and <= 0x06FF => "Arab",
				>= 0x0900 and <= 0x097F => "Deva",
				>= 0x0E00 and <= 0x0E7F => "Thai",
				>= 0x3040 and <= 0x309F => "Hira",
				>= 0x30A0 and <= 0x30FF => "Kana",
				>= 0x4E00 and <= 0x9FFF => "Hani",
				>= 0x0530 and <= 0x058F => "Armn",
				>= 0x10A0 and <= 0x10FF => "Geor",
				>= 0x1200 and <= 0x137F => "Ethi",
				>= 0x2C80 and <= 0x2CFF => "Copt",
				>= 0xAC00 and <= 0xD7AF => "Hang",
				_ => "Zzzz"
			};
		}

		/// <summary>
		/// The first character of a string.
		/// </summary>
		/// <param name="input">Tghe argument string.</param>
		/// <returns>The 1st character of the string, if it is not null or empty, an empty string instead.</returns>
		public static string FirstCharacterOrEmpty(this string input)
		{
			return string.IsNullOrEmpty(input) ? string.Empty : input.Substring(0, 1);
		}
		#endregion
	}
}
