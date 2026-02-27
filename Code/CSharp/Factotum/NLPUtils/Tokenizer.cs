//  NLPUtils Project
//  Tokenizer
//  Tokenizer.cs
//
//  Author: Cody Boisclair
//  Version: 1.1
//
//  Changes since version 1.0:
//    - Consolidated all tokenizer classes into a single source file.
//    - Updated regex 38 to handle carriage return as well as line feed.
//        (This is what I get for testing with files from a Unix box.)
//    - Added TokenizeToStringList(string) method.
//
//  Changes since version 1.0b1:
//    - Added Version property to return the DLL's version number.
//    - Enum values capitalized to correspond with .NET style guidelines.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NLPUtils
{
    /// <summary>
    /// This class contains the logic for the NLPUtils Tokenizer.
    /// 
    /// Tokenization is performed based on the method specified in the
    /// sed script developed by Robert MacIntyre of the University
    /// of Pennsylvania for the Penn Treebank project
    /// (http://www.cis.upenn.edu/~treebank/tokenizer.sed), using
    /// the regular expression facilities of the .NET Framework.
    /// 
    /// Additional improvements have been made to:
    /// 
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// properly tokenize numbers with commas and decimals and times with colons
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// properly tokenize single-quotes at the start of a quotation
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// - include the period in common abbreviations rather than
    /// tokenizing it as separate, if
    /// <see cref="Tokenizer.PeriodInAbbreviation" /> is true
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    public static class Tokenizer
    {
        private static bool preserveCase = true;
        private static bool parsedBrackets = false;
        private static bool expandWhats = false;
        private static bool tokenizeOnlyEndPeriod = false;
        private static bool periodInAbbreviation = true;
        
        private static Regex[] regexes;
        private static Regex[] abbrevRegs;

        /// <value>
        /// A <see cref="System.Reflection.Version" /> object identifying the version number
        /// of the assembly containing this class.
        /// </value>
        public static Version Version
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version; }
        }

        /// <value>
        /// If true, the original case of tokens processed by the tokenizer
        /// will be preserved; if false, tokens will be lowercased.
        /// 
        /// Default value is true.
        /// </value>
        public static bool PreserveCase
        {
            get { return preserveCase; }
            set	{ preserveCase = value; }
        }
        
        /// <value>
        /// If true, brackets will be converted to the form used by certain
        /// taggers such as MXPOST (e.g., "-LRB-", "-RRB-", etc.). If false,
        /// they will be left in their original form.
        /// 
        /// Default value is false.
        /// </value>
        public static bool ParsedBrackets
        {
            get { return parsedBrackets; }
            set { parsedBrackets = value; }
        }
        
        /// <value>
        /// If true, "whaddya" and "whatcha" will be expanded into
        /// their component morphemes; if false, they will be left alone.
        /// 
        /// This was an option in the original Penn tokenizer as well,
        /// and is maintained for compatibility's sake.
        /// 
        /// Default value is false.
        /// </value>
        public static bool ExpandWhats
        {
            get { return expandWhats; }
            set { expandWhats = value; }
        }
        
        /// <value>
        /// If true, only the period at the end of the string will become a separate
        /// token, as in the Penn Treebank tokenizer; if false, all periods
        /// will be tokenized.
        /// 
        /// Default value is false.
        /// </value>
        public static bool TokenizeOnlyEndPeriod
        {
            get { return tokenizeOnlyEndPeriod; }
            set { tokenizeOnlyEndPeriod = value; }
        }

        /// <summary>
        /// Determines whether or not certain common abbreviations, including all
        /// one-character initials, will include the ending period as part of the token
        /// (e.g., "Mrs." vs. "Mrs .").
        /// 
        /// Default value is true.
        /// </summary>
        public static bool PeriodInAbbreviation
        {
            get { return periodInAbbreviation; }
            set { periodInAbbreviation = value; }
        }
        
        /// <summary>
        /// Compiles all the necessary regular expressions for tokenization.
        /// Called by the Tokenize method.
        /// </summary>
        private static void CompileRegexes()
        {
            string[] regexStrings = new string[]{
                "^\"",  // 0
                "([ \\([{<])\"",  // 1
                "\\.\\s*\\.\\s*\\.",  // 2: modified to allow for ". . ."
                "([,;:@#$%&])",  // 3
                "([^.\\s])([.])([]\\)}>\"']*)\\s*$",  // 4
                "([^.\\s])([.])\\s*",  // 5
                "([?!])",  // 6
                "([\\[\\]\\(\\){}<>])",  // 7
                "\\(",  // 8
                "\\)",  // 9
                "\\[",  // 10
                "\\]",  // 11
                "{",  // 12
                "}",  // 13
                "--",  // 14
                "\"",  // 15
                "([^'])' ",  // 16
                "'([sSmMdD]) ",  // 17
                "'ll ",  // 18
                "'re ",  // 19
                "'ve ",  // 20
                "n't ",  // 21
                "'LL ",  // 22
                "'RE ",  // 23
                "'VE ",  // 24
                "N'T ",  // 25
                " ([Cc])annot ",  // 26
                " ([Dd])'ye ",  // 27
                " ([Gg])imme ",  // 28
                " ([Gg])onna ",  // 29
                " ([Gg])otta ",  // 30
                " ([Ll])emme ",  // 31
                " ([Mm])ore'n ",  // 32
                " ' ([Tt])is ",  // 33
                " ' ([Tt])was ",  // 34
                " ([Ww])anna ",  // 35
                " ([Ww])haddya ",  // 36
                " ([Ww])hatcha ",  // 37
                "[\r\n\t]",  // 38
                "  *",  // 39

                // opening single quote
                " '([A-Za-z])",  // 40

                // the following are for PeriodInAbbreviation:
                "([A-Za-z])\\.([A-Za-z])",  // 41
                "\\001([A-Za-z]+)\\.",   // 42
                "([^A-Za-z0-9'])([A-Za-z])\\.",    // 43

                // the following are for properly handling numbers with
                // embedded punctuation:
                "\\.(\\d)",   // 44
                ",(\\d)",    // 45
                "(\\d):(\\d)", // 46
                "\\001",    // 47
                "\\002",     // 48
                "\\003",     // 49

                // Further additions to Penn:
                
                // "hafta"... how'd they miss this one in Brown-K?
                " ([Hh])afta ",  // 50

                // Special cases of apostrophes beginning words:
                // "'em", "'im" and "'m" (as in "shoot 'em up"):
                "'\\s*([ei]?m) ",    // 51
                // 'nuff and 'nother
                "'\\s*([Nn]uff) ",     // 52
                "'\\s*([Nn]other) ",   // 53
                // others left to the human to evaluate
            };
            
            regexes = new Regex[regexStrings.Length];
            
            for (int i = 0; i < regexes.Length; i++) {
                regexes[i] = new Regex(regexStrings[i], RegexOptions.Compiled);
            }
        }

        /// <summary>
        /// Compiles all the necessary regexes for handling abbreviations.
        /// Called by the Tokenize method when PeriodInAbbreviation is set to true.
        /// </summary>
        private static void CompileAbbrevs()
        {
            // NOTE: I removed the ones that are potentially valid words
            // in themselves, like "Wash", "Ore", "Ark", "Pa", "Ill" and "Apt".
            // ("Oh, Pa. Go and get the wash. We don't need Noah's Ark.")
            string[] abbrevStrings = new string[]{
                 "mr", "mrs", "ms", "sr", "esq", "jr", "dr", "atty", "rev",
                 "supt", "prof", "capt", "col", "gen", "sgt", "lt", "priv",
                 "ft", "nav", "etc", "corp", "inc", "co", "ltd", "reg",
                 "jan", "feb", "febr", "mar", "apr", "jun", "jul",
                 "aug", "sep", "sept", "oct", "nov", "dec",
                 "ala", "ariz", "calif", "cal", "colo", "conn",
                 "dak", "del", "fla", "ga", "ind", "kans", "kan",
                 "kas", "ky", "la", "md", "mich", "minn", "mo",
                 "mont", "nebr", "nev", "okla", "tenn", "tex",
                 "vt", "va", "wis", "wyo", "tele", "dept", "vol",
                 "st", "rd", "ave", "av", "pl", "blvd", "bldg",
                 "gov", "sen", "rep", "brig", "cmdr", "pfc", "maj",
                 "govs", "sens", "reps", "drs", "messrs", "mmes", "mt"
            };

            abbrevRegs = new Regex[abbrevStrings.Length];
            for (int i = 0; i < abbrevRegs.Length; i++)
            {
                abbrevRegs[i] = new Regex("\\b(" + abbrevStrings[i] + ")\\.",
                    RegexOptions.IgnoreCase|RegexOptions.Compiled);
            }
        }

        /// <summary>
        /// Tokenizes a <see cref="System.String"/>, with tokenizing options determined by the
        /// properties of the Tokenizer class, and returns a list of
        /// <see cref="Token"/> objects representing the tokens that make up the string. 
        /// </summary>
        /// <param name="str">A <see cref="System.String"/> which is to be tokenized.</param>
        /// <returns>A list of <see cref="Token"/> objects, each of which represents
        /// a token of the tokenized input.</returns>
        public static List<Token> Tokenize(string str)
        {
            if (regexes == null)
                CompileRegexes();
            if (periodInAbbreviation && abbrevRegs == null)
                CompileAbbrevs();
            
            string outstr = str;
            
            List<Token> outList = new List<Token>();
            
            // Before tokenizing punctuation, substitute commas, periods and colons
            // preceding digits, to keep numbers with decimals and commas together.
            outstr = regexes[44].Replace(outstr, (char)1 + "$1");
            outstr = regexes[45].Replace(outstr, (char)2 + "$1");
            outstr = regexes[46].Replace(outstr, "$1" + (char)3 + "$2");

            // Initial quotes
            outstr = regexes[0].Replace(outstr, "`` ");
            outstr = regexes[1].Replace(outstr, "$1 `` ");

            // Ellipses and punctuation
            outstr = regexes[2].Replace(outstr, " ... ");
            outstr = regexes[3].Replace(outstr, " $1 ");

            // If tokenizing abbreviations, convert periods in the
            // appropriate places to ASCII 0x01.
            // (Using that because it's a control code that won't
            // appear even in Unicode text.)
            if (periodInAbbreviation)
            {
                // period between two letters
                outstr = regexes[41].Replace(outstr, "$1"+(char)1+"$2");
                // the last period in a series of Ab.Br.Ev.
                outstr = regexes[42].Replace(outstr, (char)1+"$1"+(char)1);
                // single-character abbreviations
                outstr = regexes[43].Replace(outstr, "$1$2"+(char)1);
                // all abbreviations specified in the list defined in CompileRegexes
                foreach (Regex rex in abbrevRegs)
                {
                    outstr = rex.Replace(outstr, "$1"+(char)1);
                }
            }

            if (tokenizeOnlyEndPeriod) { // ending period only
                outstr = regexes[4].Replace(outstr, "$1 $2$3 ");
            } else { // all periods that are not part of an ellipsis
                outstr = regexes[5].Replace(outstr, "$1 $2 ");
            }

            // Split off all ? and !
            outstr = regexes[6].Replace(outstr, " $1 ");
            
            // Parens and brackets
            outstr = regexes[7].Replace(outstr, " $1 ");
            
            if (parsedBrackets) {
                outstr = regexes[8].Replace(outstr, "-LRB-");
                outstr = regexes[9].Replace(outstr, "-RRB-");
                outstr = regexes[10].Replace(outstr, "-LSB-");
                outstr = regexes[11].Replace(outstr, "-RSB-");
                outstr = regexes[12].Replace(outstr, "-LCB-");
                outstr = regexes[13].Replace(outstr, "-RCB-");
            }
            
            // Em dash
            outstr = regexes[14].Replace(outstr, " -- ");
            
            // Add a space to the beginning and end of each line,
            // to make regexps easier
            outstr = " " + outstr + " ";
            
            outstr = regexes[15].Replace(outstr, " '' ");
            
            // close single quote / possessive
            outstr = regexes[16].Replace(outstr, "$1 ' ");

            outstr = regexes[40].Replace(outstr, " ' $1");

            // 's, 'm, 'd
            outstr = regexes[17].Replace(outstr, " '$1 ");
            
            outstr = regexes[18].Replace(outstr, " 'll ");
            outstr = regexes[19].Replace(outstr, " 're ");
            outstr = regexes[20].Replace(outstr, " 've ");
            outstr = regexes[21].Replace(outstr, " n't ");
            outstr = regexes[22].Replace(outstr, " 'LL ");
            outstr = regexes[23].Replace(outstr, " 'RE ");
            outstr = regexes[24].Replace(outstr, " 'VE ");
            outstr = regexes[25].Replace(outstr, " N'T ");
            
            outstr = regexes[26].Replace(outstr, " $1an not ");
            outstr = regexes[27].Replace(outstr, " $1' ye ");
            outstr = regexes[28].Replace(outstr, " $1im me ");
            outstr = regexes[29].Replace(outstr, " $1on na ");
            outstr = regexes[30].Replace(outstr, " $1ot ta ");
            outstr = regexes[31].Replace(outstr, " $1em me ");
            outstr = regexes[32].Replace(outstr, " $1ore 'n ");
            outstr = regexes[33].Replace(outstr, " '$1 is ");
            outstr = regexes[34].Replace(outstr, " '$1 was ");
            outstr = regexes[35].Replace(outstr, " $1an na ");

            // addition to Penn's word splits: "hafta"
            outstr = regexes[50].Replace(outstr, " $1af ta ");

            if (expandWhats)
            {
                outstr = regexes[36].Replace(outstr, " $1ha dd ya ");
                outstr = regexes[37].Replace(outstr, " $1ha t cha ");
            }

            // Fix "'em", "'im", "'m"
            outstr = regexes[51].Replace(outstr, " '$1 ");
            // "'nother", "'nuff"
            outstr = regexes[52].Replace(outstr, " '$1 ");
            outstr = regexes[53].Replace(outstr, " '$1 ");

            // Convert the 'substituted' periods and commas back to normal
            outstr = regexes[47].Replace(outstr, ".");
            outstr = regexes[48].Replace(outstr, ",");
            outstr = regexes[49].Replace(outstr, ":");
            
            // Convert any newlines or tabs to spaces
            outstr = regexes[38].Replace(outstr, " ");
            
            // Clean out any extra spaces to make parsing easier
            outstr = regexes[39].Replace(outstr, " ");
            
            // Trim spaces off front and back of string
            outstr = outstr.Trim();

            // Now split up the string into an array of token strings...			
            string[] tokenStrings =
                outstr.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            
            // and convert that to a list of Token objects
            if (!preserveCase) {
                foreach(string ts in tokenStrings)
                    outList.Add(new Token(ts.ToLower()));
            } else {
                foreach(string ts in tokenStrings)
                    outList.Add(new Token(ts));
            }
            
            return outList;
        }

        /// <summary>
        /// Like Tokenize(str), but returns a list of strings containing
        /// only the tokens without type information.
        /// This can then be used by other classes that don't know about
        /// any of the types defined by NLPUtils.
        /// </summary>
        /// <param name="str">A <see cref="System.String"/> which is to be tokenized.</param>
        /// <returns>A list of string objects, each representing a token of the input.</returns>
        public static List<string> TokenizeToStringList(string str)
        {
            List<Token> tokens = Tokenize(str);
            List<string> strings = new List<string>(tokens.Count);
            foreach (Token t in tokens)
                strings.Add(t.Content);
            return strings;
        }
    }

    /// <summary>
    /// A token, as used in the output of the Tokenizer class. Contains
    /// a field representing the text of the token as well as a field
    /// identifying its type (word, number, punctuation, etc.)
    /// </summary>
    public class Token
    {
        private static bool toStringIncludesType = false;

        /// <value>
        /// If true, the output of Token.ToString() will include the
        /// token type as well as the token text; if false, it will
        /// only be the text of the token.
        /// </value>
        public static bool ToStringIncludesType
        {
            get
            {
                return toStringIncludesType;
            }
            set
            {
                toStringIncludesType = value;
            }
        }

        private TokenType type;
        private string content;

        /// <summary>
        /// Constructor which guesses the token type based upon
        /// the textual content of the token.
        /// </summary>
        /// <param name="content">
        /// A <see cref="System.String"/> representing the textual content
        /// of the token.
        /// </param>
        public Token(string content)
        {
            this.content = content;

            // guess at token type based on first character of token
            char ch = content[0];
            if (Char.IsLetter(ch))
                this.type = TokenType.Word;
            else if (Char.IsDigit(ch))
                this.type = TokenType.Number;
            else
            { // starts with punctuation
                if (content.Length <= 1) // no more characters
                    this.type = TokenType.Punct;
                else if (Char.IsLetter(content[1]))
                    this.type = TokenType.Word;
                else if (Char.IsNumber(content[1]))
                    this.type = TokenType.Number;
                else
                    this.type = TokenType.Punct;
            }
        }

        /// <summary>
        /// Constructor which specifies both the textual content of the token
        /// and its type.
        /// </summary>
        /// <param name="content">
        /// A <see cref="System.String"/> representing the textual content
        /// of the token.
        /// </param>
        /// <param name="type">
        /// The <see cref="TokenType"/> of the token.
        /// </param>
        public Token(string content, TokenType type)
        {
            this.content = content;
            this.type = type;
        }

        /// <value>
        /// The type of the token.
        /// </value>
        public TokenType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        /// <value>
        /// The textual content of the token.
        /// </value>
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        /// <summary>
        /// Returns the textual content of the token, appending the
        /// token type in parentheses if ToStringIncludesType is true.
        /// </summary>
        public override string ToString()
        {
            string str = content;
            if (ToStringIncludesType)
            {
                str = str + "(" + type + ")";
            }
            return str;
        }
    }

    /// <summary>
    /// Specifies the type of a given <see cref="NLPUtils.Token"/> object.
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// A linguistic word.
        /// </summary>
        Word,
        /// <summary>
        /// A numeric value.
        /// </summary>
        Number,
        /// <summary>
        /// A punctuation mark.
        /// </summary>
        Punct
    }
}
