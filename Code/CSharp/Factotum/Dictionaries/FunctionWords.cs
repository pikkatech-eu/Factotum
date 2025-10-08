/***********************************************************************************
* File:         FunctionWords.cs                                                   *
* Contents:     Class FunctionWords                                                *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-10-08 10:12                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Factotum.Dictionaries
{
	public static class FunctionWords
	{
		#region Data
		public static Dictionary<string, string[]> FUNCTION_WORDS = new Dictionary<string, string[]>
		{
			["en"] = new string[]
			{
				"the", "a", "an", "of", "on", "in", "at", "by", "with", "from",
				"to", "under", "over", "near", "between", "about"
			},

			["fr"] = new string[]
			{
				"le", "la", "les", "l'", "l’", "un", "une", "des", "du", "de", "de la", "de l'", "de l’",
				"au", "aux", "à", "dans", "sur", "sous", "chez", "entre", "par", "pour", "avec", "envers", "vers"
			},

			["it"] = new string[]
			{
				"il", "lo", "la", "l'", "l’", "i", "gli", "le", "un", "una", "uno",
				"dei", "degli", "delle", "del", "della", "dell'", "dell’",
				"di", "a", "da", "in", "con", "su", "per", "tra", "fra", "verso"
			},

			["es"] = new string[]
			{
				"el", "la", "los", "las", "un", "una", "unos", "unas",
				"de", "a", "en", "con", "por", "para", "sobre", "entre", "hasta", "sin", "tras"
			},

			["ar"] = new string[]
			{
				"al-", "fi", "min", "ila", "‘ala", "'ala", "'an", "ma‘a", "ma'a", "bi-", "li-"
			},

			["pt"] = new string[]
			{
				"o", "a", "os", "as", "um", "uma", "uns", "umas",
				"do", "da", "dos", "das", "no", "na", "nos", "nas",
				"de", "em", "a", "por", "para", "com", "entre", "sobre", "até", "sem", "desde"
			},

			["nl"] = new string[]
			{
				"de", "het", "een", "'s", "’s", "'t", "den", "der",
				"van", "op", "aan", "in", "bij", "naar", "met", "tot", "over", "onder",
				"uit", "om", "boven", "tussen"
			},

			["sv"] = new string[]
			{
				"en", "ett", "av", "på", "i", "till", "från", "med", "under", "över",
				"vid", "mellan", "efter", "före", "mot", "utan"
			},

			["pl"] = new string[]
			{
				"z", "ze", "na", "do", "w", "we", "od", "po", "przy", "nad",
				"pod", "przed", "za", "bez", "między", "u"
			},

			["cs"] = new string[]
			{
				"z", "ze", "na", "do", "v", "ve", "od", "po", "při", "nad",
				"pod", "před", "za", "bez", "mezi", "u", "kolem"
			}
		};
		#endregion

		/// <summary>
		/// Searches for a language in which a probe word is a functional word.
		/// </summary>
		/// <param name="probe">The word to test.</param>
		/// <returns>
		///		ISO-2 code of the first encountered language in which the probe word is defined, null if there is none.
		///	</returns>
		///	<remarks>
		///		E.g. for the probe word "la" the result will be "fr", "it" and "es" will be ignored, 
		///		since the French array is first encountered.
		///	</remarks>
		public static string OfLanguage(string probe)
		{
			foreach (string language in FUNCTION_WORDS.Keys)
			{
				if (FUNCTION_WORDS[language].Contains(probe.ToLower()))
				{
					return language;
				}
			}

			return null;
		}

		/// <summary>
		/// Checks if a probe word is functional in one of the defined languages.
		/// </summary>
		/// <param name="probe">The word to test.</param>
		/// <returns>True, if such a language is registered.</returns>
		public static bool IsFunctionalWord(string probe)
		{
			return OfLanguage(probe) != null;
		}
	}
}
