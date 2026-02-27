//  NLPUtils Project
//  Morphological Parser
//  MorphParser.cs
//
//  Author: Cody Boisclair
//  Version: 1.0b2
//
//  Changes since 1.0b1:
//    - Consolidated all classes into a single source file.
//      (No changes in the actual classes themselves.)

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;

namespace NLPUtils
{
    /// <summary>
    /// This class contains the logic for the NLPUtils Morphological Parser.
    /// </summary>
    public static class MorphParser
    {
        private static Dictionary<string, List<List<Morph>>> irregularDict;
        private static bool preserveCase = true;
        private static string irregularsFilePath = null;
        private static bool mustUpdateIrregulars = true;
        private static bool irregularsCaseSensitive = false;

        private static bool regularSuffixesFilled = false;
        private static Dictionary<string, SyntacticCat> regularSuffixCats;
        private static Dictionary<string, string[]> regularSuffixSpellings;

        /// <value>
        /// A <see cref="System.Reflection.Version" /> object identifying the version number
        /// of the assembly containing this class.
        /// </value>
        public static Version Version
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version; }
        }

        /// <summary>
        /// Determines whether irregular forms will be matched case-sensitively.
        /// </summary>
        public static bool IrregularsCaseSensitive
        {
            get { return irregularsCaseSensitive; }
            set
            {
                irregularsCaseSensitive = value;
                mustUpdateIrregulars = true;
            }
        }

        /// <summary>
        /// Defines the local file from which additional irregular forms
        /// are to be loaded.
        /// </summary>
        public static string IrregularsFilePath
        {
            get { return irregularsFilePath; }
            set
            {
                irregularsFilePath = value;
                mustUpdateIrregulars = true;
            }
        }
        /// <summary>
        /// If true, morphs will be kept in the case in which they appear in the
        /// original tokens; if false, they will be lowercased. Default is true.
        /// </summary>
        public static bool PreserveCase
        {
            get { return preserveCase; }
            set { preserveCase = value; }
        }

        /// <summary>
        /// Generates a list of possible parses for a given word.
        /// </summary>
        /// <param name="token">The word to be parsed.</param>
        /// <returns>A <see cref="System.Collections.Generic.List}T}" /> of possible parses,
        /// where each parse is a <see cref="System.Collections.Generic.List}T}" /> of
        /// <see cref="NLPUtils.Morph" /> objects.</returns>
        public static List<List<Morph>> ParseWord(string token)
        {
            if (!regularSuffixesFilled)
            {
                FillRegularSuffixes();
                regularSuffixesFilled = true;
            }

            // if the dictionary of irregular forms hasn't been filled in,
            // or the file reference for additional forms has been changed,
            // read the irregular forms in.
            if (irregularDict == null || mustUpdateIrregulars)
            {
                ReadIrregulars();
            }

            List<List<Morph>> results = new List<List<Morph>>();

            if (irregularDict.ContainsKey(token))
            {
                // clone the list from the dictionary
                
                results = new List<List<Morph>>();
                foreach (List<Morph> ml in irregularDict[token])
                {
                    results.Add(CapitalizeMorphListBy(ml, token));
                }
                return results;
            }

            // some common irregular forms:
            
            // -im = plural
            if (token.Length >= 5 &&
                token.EndsWith("im",StringComparison.CurrentCultureIgnoreCase))
            {
                results.Add(MakeMorphList(SyntacticCat.Noun, token.Substring(0, token.Length - 2), "s"));
                results.Add(MakeMorphList(SyntacticCat.Unknown, token));
                return results;
            }

            // -ae = plural of -a
            if (token.Length >= 4 &&
                token.EndsWith("ae",StringComparison.CurrentCultureIgnoreCase))
            {
                results.Add(MakeMorphList(SyntacticCat.Noun, token.Substring(0, token.Length - 1), "s"));
                results.Add(MakeMorphList(SyntacticCat.Unknown, token));
                return results;
            }

            // -ves = plural of -fe
            if (token.Length >= 5 &&
                token.EndsWith("ves",StringComparison.CurrentCultureIgnoreCase))
            {
                results.Add(MakeMorphList(SyntacticCat.Noun, token.Substring(0, token.Length - 3) +
                    ((Char.IsUpper(token[token.Length - 3])) ? 'F' : 'f'), "s"));
                results.Add(MakeMorphList(SyntacticCat.Unknown, token.Substring(0, token.Length - 1), token.Substring(token.Length-1)));
                results.Add(MakeMorphList(SyntacticCat.Unknown, token));
                return results;
            }

            // -ices = plural of -ex or -ix
            if (token.Length >= 5 &&
                token.EndsWith("ices",StringComparison.CurrentCultureIgnoreCase))
            {
                results.Add(MakeMorphList(SyntacticCat.Noun, token.Substring(0, token.Length - 4) +
                    ((Char.IsUpper(token[token.Length - 4])) ? 'I' : 'i') +
                    ((Char.IsUpper(token[token.Length - 3])) ? 'X' : 'x'), "s"));
                results.Add(MakeMorphList(SyntacticCat.Noun, token.Substring(0, token.Length - 4) +
                    ((Char.IsUpper(token[token.Length - 4])) ? 'E' : 'e') +
                    ((Char.IsUpper(token[token.Length - 3])) ? 'X' : 'x'), "s"));
                results.Add(MakeMorphList(SyntacticCat.Unknown, token.Substring(0, token.Length - 1), token.Substring(token.Length - 1)));
                results.Add(MakeMorphList(SyntacticCat.Unknown, token));
                return results;
            }

            // -i = plural of -us
            if (token.Length >= 3 && Char.ToLower(token[token.Length - 1]) == 'i')
            {
                results.Add(MakeMorphList(SyntacticCat.Noun, token.Substring(0, token.Length - 1) +
                    ((Char.IsUpper(token[token.Length - 1])) ? 'U' : 'u') +
                    ((Char.IsUpper(token[token.Length - 1])) ? 'S' : 's'), "s"));
                results.Add(MakeMorphList(SyntacticCat.Unknown, token));
                return results;
            }

            
            // -a = plural of -um or -on
            if (token.Length >= 3 && Char.ToLower(token[token.Length - 1]) == 'a')
            {
                results.Add(MakeMorphList(SyntacticCat.Noun, token.Substring(0, token.Length - 1) +
                    ((Char.IsUpper(token[token.Length - 1])) ? 'U' : 'u') +
                    ((Char.IsUpper(token[token.Length - 1])) ? 'M' : 'm'), "s"));
                results.Add(MakeMorphList(SyntacticCat.Noun, token.Substring(0, token.Length - 1) +
                    ((Char.IsUpper(token[token.Length - 1])) ? 'O' : 'o') +
                    ((Char.IsUpper(token[token.Length - 1])) ? 'N' : 'n'), "s"));
                results.Add(MakeMorphList(SyntacticCat.Unknown, token));
                return results;
            }

            // -aux = plural of -au
            if (token.Length >= 4 &&
                token.EndsWith("aux", StringComparison.CurrentCultureIgnoreCase))
            {
                results.Add(MakeMorphList(SyntacticCat.Noun, token.Substring(0, token.Length - 1), "s"));
                results.Add(MakeMorphList(SyntacticCat.Unknown, token));
                return results;
            }

            results = new List<List<Morph>>();

            // for all regular suffixes...
            foreach (string s in regularSuffixCats.Keys)
            {
                string[] suffixSpellings = null;
                if (regularSuffixSpellings.ContainsKey(s))
                    suffixSpellings = regularSuffixSpellings[s];
                else
                    suffixSpellings = new string[] { s };

                SyntacticCat cat = regularSuffixCats[s];

                // iterate through all spellings of the suffix
                foreach (string suffixSpelling in suffixSpellings) {
                    // suffix is a match?
                    if (token.EndsWith(suffixSpelling, StringComparison.CurrentCultureIgnoreCase))
                    {
                        string stem = token.Substring(0, token.Length - suffixSpelling.Length);
                        string suffix = token.Substring(token.Length - suffixSpelling.Length);

                        if (suffix.Equals("s", StringComparison.CurrentCultureIgnoreCase))
                        {
                            // "quizzes" -> "quiz" + "s"
                            if (stem.Length > 2 &&
                                stem.EndsWith("zz", StringComparison.CurrentCultureIgnoreCase) ||
                                stem.EndsWith("ss", StringComparison.CurrentCultureIgnoreCase))
                            {
                                results.Add(MakeMorphList(cat,
                                    stem.Substring(0, token.Length - 1), s));
                            }

                            // "babies" -> "baby" + "s"
                            if (stem.Length > 3 &&
                                stem.EndsWith("ie", StringComparison.CurrentCultureIgnoreCase) &&
                                !IsVowel(stem[stem.Length - 3]))
                            {
                                results.Add(MakeMorphList(cat,
                                    stem.Substring(0, stem.Length - 2) + (Char.IsUpper(stem[stem.Length - 2]) ? "Y" : "y"),
                                    s));
                            }

                            // -es -> -s after sh, ch, s, z, x
                            if ((stem.Length > 3 &&
                                 (stem.EndsWith("she", StringComparison.CurrentCultureIgnoreCase) ||
                                  stem.EndsWith("che", StringComparison.CurrentCultureIgnoreCase))) ||
                                (stem.Length > 2 &&
                                 (stem.EndsWith("se", StringComparison.CurrentCultureIgnoreCase) ||
                                  stem.EndsWith("ze", StringComparison.CurrentCultureIgnoreCase) ||
                                  stem.EndsWith("xe", StringComparison.CurrentCultureIgnoreCase))))
                            {
                                results.Add(MakeMorphList(cat,
                                    stem.Substring(0, stem.Length - 1), s));
                            }
                        }

                        else if (IsVowel(s[0])) // suffix starts with vowel
                        {
                            // un-double a doubled consonant at the end of the stem
                            if (stem.Length > 2 && (Char.ToLower(stem[stem.Length - 1]) == Char.ToLower(stem[stem.Length - 2])))
                            {
                                results.Add(MakeMorphList(cat, stem.Substring(0, stem.Length - 1), s));
                            }

                            // "y" changes to "i" after a consonant when preceding a suffix starting in a vowel
                            if (stem.Length > 2 && s[0] != 'i' && !IsVowel(stem[stem.Length - 2]) && stem[stem.Length - 1] == 'i')
                            {
                                results.Add(MakeMorphList(cat,
                                    stem.Substring(0, stem.Length - 1) + (Char.IsUpper(stem[stem.Length - 1]) ? "Y" : "y"),
                                    s));
                            }

                            // add "e" to end of stem when stem ends in a consonant
                            if (stem.Length > 1 && !IsVowel(stem[stem.Length - 1]))
                            {
                                results.Add(MakeMorphList(cat,
                                    stem + (Char.IsUpper(stem[stem.Length - 1]) ? "E" : "e"), s));
                            }

                            // remove "k" when stem ends in "ck"
                            if (stem.Length > 2 && stem.EndsWith("ck", StringComparison.CurrentCultureIgnoreCase))
                            {
                                results.Add(MakeMorphList(cat,
                                    stem.Substring(0, stem.Length - 1), s));
                            }
                        }

                        // if suffix does not start in vowel or stem does not end in -VC,
                        // append suffix to unmodified stem
                        if (!IsVowel(suffix[0]) ||
                            (stem.Length>2 && (IsVowel(stem[stem.Length-1]) || !IsVowel(stem[stem.Length-2]))))
                        {
                            results.Add(MakeMorphList(cat, stem, s));
                        }
                    }
                }
            }

            // finally, attach the token with no suffix appended
            // (e.g.: "rabies" is not the plural of "raby"!)
            results.Add(MakeMorphList(SyntacticCat.Unknown, token));
            
            return results;
        }

        /// <summary>
        /// Fills in the private regularSuffixCats and regularSuffixSpellings variables
        /// used in the parsing regular morphological suffixes.
        /// </summary>
        private static void FillRegularSuffixes()
        {
            regularSuffixCats = new Dictionary<string, SyntacticCat>();
            regularSuffixCats.Add("s", SyntacticCat.Unknown);
            regularSuffixCats.Add("ed", SyntacticCat.Verb);
            regularSuffixCats.Add("en", SyntacticCat.Verb);
            regularSuffixCats.Add("ing", SyntacticCat.Verb);
            regularSuffixCats.Add("er", SyntacticCat.Unknown);
            regularSuffixCats.Add("est", SyntacticCat.Unknown);
            regularSuffixSpellings = new Dictionary<string, string[]>();
            regularSuffixSpellings.Add("en", new string[] { "ed" });
        }

        /// <summary>
        /// Produces a list of morphs, lowercased if PreserveCase is true,
        /// with all morph having the specified category, based on a string representing the stem
        /// and a set of strings representing added suffixes.
        /// </summary>
        /// <param name="category">The <see cref="NLPUtils.SyntacticCat" /> to be assigned
        /// to all the morphs in the list.</param>
        /// <param name="stem">A string representing the spelling of the stem.</param>
        /// <param name="features">An array of strings representing the spellings
        /// of the features added on to the stem.</param>
        /// <returns>A <see cref="System.Collections.Generic.List{T}" /> of
        /// <see cref="Morph" /> objects representing the specified morphs.</returns>
        private static List<Morph> MakeMorphList(SyntacticCat category, string stem, params string[] features)
        {
            List<Morph> thisResult = new List<Morph>();
            thisResult.Add(new Morph(LowercaseOrNot(stem), MorphType.Stem, category));
            foreach (string feature in features)
            {
                thisResult.Add(new Morph(LowercaseOrNot(feature), MorphType.Feature, category));
            }
            return thisResult;
        }

        /// <summary>
        /// Produces a list of morphs, with the stem capitalized appropriately,
        /// with each morph assigned the category <see cref="SyntacticCat.Unknown" />,
        /// based on a string representing the stem and a set of strings
        /// representing added suffixes.
        /// </summary>
        /// <param name="stem">A string representing the spelling of the stem.</param>
        /// <param name="features">An array of strings representing the spellings
        /// of the features added on to the stem.</param>
        /// <returns>A <see cref="System.Collections.Generic.List{T}" /> of
        /// <see cref="Morph" /> objects representing the specified morphs.</returns>
        private static List<Morph> MakeMorphList(string stem, params string[] features)
        {
            return MakeMorphList(SyntacticCat.Unknown, stem, features);
        }

        /// <summary>
        /// Fills in the private irregularDict dictionary used in identifying
        /// irregular morphological forms, looking at the file specified in
        /// <see cref="IrregularsFilePath" /> for additional forms if it is defined.
        /// </summary>
        private static void ReadIrregulars()
        {
            irregularDict = new Dictionary<string, List<List<Morph>>>();
            if (irregularsCaseSensitive)
                irregularDict = new Dictionary<string, List<List<Morph>>>(StringComparer.CurrentCulture);
            else
                irregularDict = new Dictionary<string, List<List<Morph>>>(StringComparer.CurrentCultureIgnoreCase);

            Stream xs = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                Assembly.GetExecutingAssembly().GetName().Name + ".IrregularForms.xml");
            AddIrregularsFromStream(xs);
            xs.Close();

            if (irregularsFilePath != null)
            {
                try
                {
                    xs = new FileStream(irregularsFilePath, FileMode.Open);
                    AddIrregularsFromStream(xs);
                    xs.Close();
                }
                catch (FileNotFoundException)
                {
                    Console.Error.WriteLine("Error: File '" + irregularsFilePath + "' not found.");
                }
            }

            mustUpdateIrregulars = false;
        }

        /// <summary>
        /// Reads in irregular forms from an XML-formatted file available via
        /// the stream specified in the parameter <paramref name="xs"/>.
        /// </summary>
        /// <param name="xs">The stream from which the irregular forms are to be read.</param>
        private static void AddIrregularsFromStream(Stream xs)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(xs);
            }
            catch (XmlException)
            {
                Console.Error.WriteLine("XML document does not appear to be valid.");
                return;
            }

            XmlElement mainNode = doc.DocumentElement;

            foreach (XmlNode tokenNode in mainNode.GetElementsByTagName("token"))
            {
                string tokenSpell = tokenNode.Attributes["spell"].Value;
                if (tokenSpell == null)
                    continue;

                List<List<Morph>> allParses = new List<List<Morph>>();
                foreach (XmlNode parseNode in tokenNode.SelectNodes("parse"))
                {
                    List<Morph> thisParse = new List<Morph>();
                    bool firstMorph = true;
                    foreach (XmlNode morphNode in parseNode.SelectNodes("morph"))
                    {
                        MorphType thisType = firstMorph ? MorphType.Stem : MorphType.Feature;
                        if (morphNode.Attributes["type"] != null)
                        {
                            if (morphNode.Attributes["type"].Value == "stem")
                                thisType = MorphType.Stem;
                            else if (morphNode.Attributes["type"].Value.StartsWith("feat"))
                                thisType = MorphType.Feature;
                        }

                        if (firstMorph) firstMorph = false;

                        SyntacticCat thisCat = SyntacticCat.Unknown;

                        if (morphNode.Attributes["cat"] != null)
                        {
                            if (morphNode.Attributes["cat"].Value == "noun")
                                thisCat = SyntacticCat.Noun;
                            else if (morphNode.Attributes["cat"].Value == "verb")
                                thisCat = SyntacticCat.Verb;
                            else if (morphNode.Attributes["cat"].Value == "adj")
                                thisCat = SyntacticCat.Adjective;
                            else if (morphNode.Attributes["cat"].Value == "adv")
                                thisCat = SyntacticCat.Adverb;
                        }

                        if (morphNode.Attributes["spell"] != null)  // XML node has a spelling
                            thisParse.Add(new Morph(LowercaseOrNot(morphNode.Attributes["spell"].Value),
                                thisType, thisCat));
                    }

                    if (thisParse.Count > 0)  // parse isn't empty
                        allParses.Add(thisParse);
                }
                if (irregularDict.ContainsKey(tokenSpell))
                    irregularDict.Remove(tokenSpell);
                if (allParses.Count > 0)
                    irregularDict.Add(tokenSpell, allParses);
            }
        }

        /// <summary>
        /// Calls <see cref="Tokenizer.Tokenize" /> to tokenize a given sentence, then
        /// morphologically analyzes each token of the resulting token list.
        /// </summary>
        /// <param name="sentence">A string containing the sentence(s) to be tokenized.</param>
        /// <returns>A <see cref="System.Collections.Generic.List{T}"/> of results from
        /// <see cref="ParseWord"/> for each token in the sentence. </returns>
        public static List<List<List<Morph>>> TokenizeAndParse(string sentence)
        {
            List<Token> tokens = Tokenizer.Tokenize(sentence);
            List<List<List<Morph>>> result = new List<List<List<Morph>>>();
            foreach (Token t in tokens)
            {
                if (t.Type != TokenType.Word)
                {
                    List<Morph> oneMorph = new List<Morph>();
                    oneMorph.Add(new Morph(t.Content, MorphType.NonWord));
                    List<List<Morph>> oneParse = new List<List<Morph>>();
                    oneParse.Add(oneMorph);
                    result.Add(oneParse);
                }
                else
                {
                    result.Add(ParseWord(t.Content));
                }
            }
            return result;
        }

        /// <summary>
        /// Identifies whether a given character is a vowel.
        /// </summary>
        /// <param name="ch">The character to be evaluated.</param>
        /// <returns>True if <paramref name="ch"/> is a vowel; false if not.</returns>
        private static bool IsVowel(char ch)
        {
            char chLower = Char.ToLower(ch);
            return (chLower=='a' || chLower=='e' || chLower=='i' || chLower=='o' ||
                    chLower=='u' || chLower=='y');
        }

        /// <summary>
        /// Clones a list of morphs and capitalizes the stem based upon the capitalization of
        /// the first two characters in a provided string.
        /// </summary>
        /// <param name="original">The original list of morphs which is to be capitalized.</param>
        /// <param name="caps">The string identifying the capitalization pattern for the stem.</param>
        /// <returns>A list of <see cref="Morph" />s with the stem capitalized appropriately.</returns>
        private static List<Morph> CapitalizeMorphListBy(List<Morph> original, string caps)
        {
            List<Morph> newList = new List<Morph>();
            bool firstCap = Char.IsUpper(caps[0]);
            bool restCap = Char.IsUpper(caps[1]);

            foreach (Morph m in original)
            {
                if (m.Type == MorphType.Stem)
                {
                    if (firstCap && restCap)
                        newList.Add(new Morph(m.Spelling.ToUpper(), m.Type, m.Category));
                    else if (firstCap && ! restCap)
                        newList.Add(new Morph("" + Char.ToUpper(m.Spelling[0]) +
                            m.Spelling.Substring(1).ToLower(), m.Type, m.Category));
                    else
                        newList.Add(new Morph(m.Spelling.ToLower(), m.Type, m.Category));
                }
                else
                {
                        newList.Add(new Morph(m.Spelling, m.Type, m.Category));
                }
            }
            return newList;
        }

        /// <summary>
        /// Converts a string to lowercase only if <see cref="MorphParser.PreserveCase" />
        /// is false; otherwise preserves the original string.
        /// </summary>
        /// <param name="original">The original string to be converted.</param>
        /// <returns>Either the original string if PreserveCase is true,
        /// or a lowercased version if PreserveCase is false.</returns>

        private static string LowercaseOrNot(string original)
        {
            if (preserveCase)
                return original;
            else
                return original.ToLower();
        }
    }

    /// <summary>
    /// Represents a linguistic morph, as used in the output of the MorphParser class.
    /// Contains a field representing the spelling of the morph as well as a field
    /// identifying its type (so far, only distinguishes between stem and feature).
    /// </summary>
    public class Morph
    {
        private string spelling;
        private MorphType type;
        private SyntacticCat category;

        /// <value>
        /// The surface-level spelling of this morph.
        /// </value>
        public string Spelling
        {
            get { return spelling; }
            set { spelling = value; }
        }

        /// <value>
        /// The underlying type of this morph.
        /// </value>
        public MorphType Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// The syntactic category of this morph.
        /// </summary>
        public SyntacticCat Category
        {
            get { return category; }
            set { category = value; }
        }

        /// <summary>
        /// Constructor which specifies the spelling, type and syntactic category of a morph.
        /// </summary>
        /// <param name="spelling">A <see cref="System.String"/> representing
        /// the spelling of the morph.</param>
        /// <param name="type">The <see cref="NLPUtils.MorphType"/> of the morph</param>
        /// <param name="category">The <see cref="NLPUtils.SyntacticCat"/> of the morph.</param>
        public Morph(string spelling, MorphType type, SyntacticCat category)
        {
            this.spelling = spelling;
            this.type = type;
            this.category = category;
        }

        /// <summary>
        /// Constructor which specifies the spelling and type of a morph.
        /// </summary>
        /// <param name="spelling">A <see cref="System.String"/> representing
        /// the spelling of the morph.</param>
        /// <param name="type">The <see cref="NLPUtils.MorphType"/> of the morph</param>
        public Morph(string spelling, MorphType type)
        {
            this.spelling = spelling;
            this.type = type;
            this.category = SyntacticCat.Unknown;
        }

        /// <summary>
        /// Returns the spelling of the morph, with a plus sign appended before it
        /// if the morph is a feature.
        /// </summary>
        public override string ToString()
        {
            if (type == MorphType.Feature)
                return "+" + spelling;
            else
                return spelling;
        }
    }

    /// <summary>
    /// Specifies the type of a given <see cref="NLPUtils.Morph"/> object.
    /// </summary>
    public enum MorphType
    {
        /// <summary>
        /// The stem of a word.
        /// </summary>
        Stem,
        /// <summary>
        /// A feature added on to a stem.
        /// </summary>
        Feature,
        /// <summary>
        /// A 'morph' that is not part of a word (i.e., numbers and punctuation).
        /// </summary>
        NonWord
    }

    /// <summary>
    /// Specifies the syntactic category into which a morph fits
    /// (i.e., the part of speech of the stem or to which the affix is affixed).
    /// </summary>
    public enum SyntacticCat
    {
        /// <summary>
        /// A verb or verb affix.
        /// </summary>
        Verb,
        /// <summary>
        /// A noun or noun affix.
        /// </summary>
        Noun,
        /// <summary>
        /// An adjective or adjective affix.
        /// </summary>
        Adjective,
        /// <summary>
        /// An adverb or adverb affix.
        /// </summary>
        Adverb,
        /// <summary>
        /// An unknown part of speech.
        /// </summary>
        Unknown
    }
}
