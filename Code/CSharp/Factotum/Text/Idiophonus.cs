/***********************************************************************************
* File:         Idiophonus.cs                                                      *
* Contents:     Class Idiophonus                                                   *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-10-18 23:35                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.IO;
using System.Text.Json;
using Factotum.Maths;

namespace Factotum.Text
{
	public class Idiophonus
	{
		#region Constants
		private const string DEFAULT_NAME = "Defaultese";
		private readonly Dictionary<string, double> DEFAULT_VOWELS = new Dictionary<string, double>()
		{ 
			{"a",	0.2483},
			{"e",	0.1985},
			{"i",	0.1599},
			{"o",	0.1854},
			{"u",	0.1272},			
		};

		private readonly Dictionary<string, double> DEFAULT_CONSONANTS = new Dictionary<string, double>()
		{ 
			{"b",	0.017200},
			{"c",	0.002194},
			{"d",	0.054230},
			{"f",	0.012852},
			{"g",	0.028212},
			{"h",	0.010971},
			{"j",	0.010031},
			{"k",	0.075233},
			{"l",	0.101251},
			{"m",	0.057052},
			{"n",	0.154227},
			{"p",	0.056738},
			{"q",	0.007523},
			{"r",	0.102818},
			{"s",	0.104699},
			{"t",	0.102505},
			{"v",	0.042005},
			{"y",	0.045767},
			{"z",	0.011285},
			{"st",	0.002411},
			{"sp",	0.000482},
			{"sk",	0.000241},
			{"str",	0.000031}
		};
			
		private readonly Dictionary<SyllableType, double> DEFAULT_SYLLABLES = new Dictionary<SyllableType, double>()
		{
			{SyllableType.V,	0.1000},
			{SyllableType.CV,	0.2000},
			{SyllableType.VC,	0.5000},
			{SyllableType.CVC,	0.2000}
		};

		private readonly Dictionary<int, double> DEFAULT_WORD_LENGTHS = new Dictionary<int, double>()
		{
			{1, 0.0294},
			{2, 0.0588},
			{3, 0.0882},
			{4, 0.1176},
			{5, 0.2353},
			{6, 0.2941},
			{7, 0.1471},
			{8, 0.0294}
		};

		private readonly Dictionary<int, double> DEFAULT_PHRASE_WORD_NUMBERS = new Dictionary<int, double>()
		{
			{1, 0.0028},
			{2, 0.0142},
			{3, 0.0284},
			{4, 0.2841},
			{5, 0.2272},
			{6, 0.3409},
			{7, 0.1705},
			{8, 0.0568},
			{9, 0.0142},
			{10, 0.0028}
		};

		private readonly Dictionary<string, double> DEFAULT_INNER_PUNCTUATION = new Dictionary<string, double>()
		{ 
			{" ",	0.9320},
			{", ",	0.0466},
			{"; ",	0.0093},
			{"-",	0.0047},
			{" - ", 0.0028},
			{": ",	0.0047}
		};

		private readonly Dictionary<string, double> DEFAULT_FINAL_PUNCTUATION = new Dictionary<string, double>()
		{ 
			{".", 0.9090},
			{"!", 0.0454},
			{"?", 0.0454}
		};
		#endregion

		#region Private members
		private DiscreteRandomizer	_vowelRandomizer;
		private DiscreteRandomizer	_consonantRandomizer;
		private DiscreteRandomizer	_syllableTypeRandomizer;
		private DiscreteRandomizer	_innerPunctuationRandomizer;
		private DiscreteRandomizer	_finalPunctuationRandomizer;
		private DiscreteRandomizer	_wordLengthRandomizer;
		private DiscreteRandomizer	_phraseWordNumberRandomizer;
		#endregion

		#region Properties
		/// <summary>
		/// The name of the language.
		/// </summary>
		public string Name {get;set;}

		/// <summary>
		/// Vowels and all vowel-like atomic items of the language:
		/// vowels properly, dipthongs, triphtongs.
		/// The key is the atomic text element, the value its relative frequency in the texts.
		/// </summary>
		public Dictionary<string, double> Vowels {get;set;}

		/// <summary>
		/// Consonants and all consonant-like atomic items of the language:
		/// consonants properly, double and triple consonants.
		/// The key is the atomic text element, the value its relative frequency in the texts.
		/// </summary>
		public Dictionary<string, double> Consonants {get;set;}

		/// <summary>
		/// Syllable types and their distribution in the language.
		/// Key: syllabic type; value: its relative frequency.
		/// </summary>
		public Dictionary<SyllableType, double> Syllables {get;set;}

		/// <summary>
		/// Inner punctuation signs of the language:
		/// The key is the atomic text element, the value its relative frequency in the texts.
		/// </summary>
		public Dictionary<string, double> InnerPunctuation {get;set;}

		/// <summary>
		/// Final punctuation signs of the language:
		/// The key is the atomic text element, the value its relative frequency in the texts.
		/// </summary>
		public Dictionary<string, double> FinalPunctuation {get;set;}
		
		/// <summary>
		/// Distribution of word lengths.
		/// Key: length of a word; value: its relative frequency.
		/// </summary>
		public Dictionary<int, double> WordLengthDistribution {get;set;}

		/// <summary>
		/// Distribution of phrase word numbers.
		/// Key: number of words in a phrase; value: its relative frequency.
		/// </summary>
		public Dictionary<int, double> PhraseWordNumberDistribution {get;set;}
		#endregion

		#region Construction
		public Idiophonus
						(
							string name	= DEFAULT_NAME,
							Dictionary<string, double> vowels = null,
							Dictionary<string, double> consonants = null,
							Dictionary<SyllableType, double> syllables = null,
							Dictionary<string, double> innerPunctuation = null,
							Dictionary<string, double> finalPunctuation = null,
							Dictionary<int, double> wordLengths = null,
							Dictionary<int, double> phraseWordNumbers = null
						)
		{
			this.Name							= name;
			this.Vowels							= vowels ?? DEFAULT_VOWELS;
			this.Consonants						= vowels ?? DEFAULT_CONSONANTS;
			this.Syllables						= syllables ?? DEFAULT_SYLLABLES;
			this.InnerPunctuation				= innerPunctuation ?? DEFAULT_INNER_PUNCTUATION;
			this.FinalPunctuation				= finalPunctuation ?? DEFAULT_FINAL_PUNCTUATION;
			this.WordLengthDistribution			= wordLengths ?? DEFAULT_WORD_LENGTHS;
			this.PhraseWordNumberDistribution	= phraseWordNumbers ?? DEFAULT_PHRASE_WORD_NUMBERS;

			// Initialization of randomizers
			this._vowelRandomizer				= new DiscreteRandomizer(this.Vowels.Values);
			this._consonantRandomizer			= new DiscreteRandomizer(this.Consonants.Values);
			this._syllableTypeRandomizer		= new DiscreteRandomizer(this.Syllables.Values);
			this._innerPunctuationRandomizer	= new DiscreteRandomizer(this.InnerPunctuation.Values);
			this._finalPunctuationRandomizer	= new DiscreteRandomizer(this.FinalPunctuation.Values);
			this._wordLengthRandomizer			= new DiscreteRandomizer(this.WordLengthDistribution.Values);
			this._phraseWordNumberRandomizer	= new DiscreteRandomizer(this.PhraseWordNumberDistribution.Values);
		}
		#endregion

		#region Public Creation
		public string Word(int length = 0)
		{
			if (length == 0)
			{
				length = this._wordLengthRandomizer.RandomObject(this.WordLengthDistribution.Keys);
			}

			string result = "";
			
			while (result.Length != length)
			{
				result = this.CreateWord(length);
			}

			return result;
		}

		public string Phrase(int numberOfWords = 0)
		{
			if (numberOfWords == 0)
			{
				numberOfWords = this._phraseWordNumberRandomizer.RandomObject(this.PhraseWordNumberDistribution.Keys);
			}

			string result = "";

			for (int i = 0; i < numberOfWords; i++)
			{
				string word = this.Word();
				result += word;

				string innerPunctuation = this._innerPunctuationRandomizer.RandomObject(this.InnerPunctuation.Keys);
				result += innerPunctuation;
			}

			foreach (string p in this.InnerPunctuation.Keys)
			{
				if (result.EndsWith(p))
				{
					result = result.Substring(0, result.Length - p.Length);
				}
			}

			string finalPunctuation = this._finalPunctuationRandomizer.RandomObject(this.FinalPunctuation.Keys);

			result += finalPunctuation;

			result = result.Capitalize();

			return result;
		}

		public string Phrases(int numberOfPhrases)
		{
			string result = "";

			for (int i = 0; i < numberOfPhrases; i++)
			{
				result += this.Phrase() + " ";
			}

			return result;
		}
		#endregion

		#region Json
		public string ToJson()
		{
			string json = JsonSerializer.Serialize<Idiophonus>(this, new JsonSerializerOptions{WriteIndented=true});

			return json;
		}

		public static Idiophonus FromJson(string json)
		{
			return JsonSerializer.Deserialize<Idiophonus>(json);
		}
		#endregion

		#region I/O
		public void Save(string path)
		{
			File.WriteAllText(path, this.ToJson());
		}

		public static Idiophonus Load(string path)
		{
			return FromJson(File.ReadAllText(path));
		}
		#endregion

		#region Private Creation
		private string Vowel()
		{
			return this._vowelRandomizer.RandomObject(this.Vowels.Keys);
		}

		private string Consonant()
		{
			return this._consonantRandomizer.RandomObject(this.Consonants.Keys);
		}

		private string Syllable(int length = 0)
		{
			SyllableType syllableType = this._syllableTypeRandomizer.RandomObject(Enum.GetValues<SyllableType>());

			switch (syllableType)
			{
				case SyllableType.V:
					return this.Vowel();

				case SyllableType.CV:
					return this.Consonant() + this.Vowel();

				case SyllableType.VC:
					return this.Vowel() + this.Consonant();

				case SyllableType.CVC:
					return this.Consonant() + this.Vowel() + this.Consonant();

				case SyllableType.Unknown:
				default:
					return "";
			}
		}

		private string CreateWord(int length)
		{
			int averageSyllableLength = 2;

			string result = "";

			int numberOfSyllables = length / averageSyllableLength;

			if (numberOfSyllables == 0)
			{
				numberOfSyllables = 1;
			}

			for (int i = 0; i < numberOfSyllables; i++)
			{
				result += this.Syllable();
			}

			return result;
		}
		#endregion

		#region Private Auxiliary
		private void NormalizeDictionary<T>(Dictionary<T, double> source)
		{
			double sum = source.Values.Sum();

			foreach (T key in source.Keys)
			{
				source[key] = source[key] / sum;
			}
		}
		#endregion
	}

	public enum SyllableType
	{
		/// <summary>
		/// Unknown syllable type.
		/// </summary>
		Unknown	= -1,

		/// <summary>
		/// Vowel syllable
		/// </summary>
		V	= 0,

		/// <summary>
		/// "CV" syllable, e.g. 'cu'
		/// </summary>
		CV	= 1,

		/// <summary>
		/// "VC" syllable
		/// </summary>
		VC	= 2,

		/// <summary>
		/// "CVC" syllable.
		/// </summary>
		CVC	= 3
	}
}
