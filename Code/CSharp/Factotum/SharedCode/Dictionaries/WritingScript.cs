/***********************************************************************************
* File:         WritingScript.cs                                                   *
* Contents:     Class WritingScript                                                *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2024-10-31 14:27                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Collections.Generic;

namespace Factotum.Dictionaries
{
	///	Provides an abstraction of a writing system classification (script system)
	///	according to ISO-15924 (https://en.wikipedia.org/wiki/ISO_15924).
	///	Stand: 2024.
	///	http://www.loc.gov/standards/iso639-2/php/code_list.php
	public class WritingScript
	{
		#region Properties
		/// <summary>
		/// Four-character case-sensitive representation of a writing system, e.g. "Armn" for Armenian.
		/// </summary>
		public string Code {get;set;}

		/// <summary>
		/// Index by ISO-15924, e.g. 230 for Germany.
		/// </summary>
		public int Index {get;set;}

		/// <summary>
		/// Name, possibly a short description, e.g. "Armenian".
		/// </summary>
		public string Name {get;set;}
		#endregion

		#region Construction
		/// <summary>
		/// Value constructor. Creates an instance of WritingScript from provided values.
		/// </summary>
		/// <param name="code">The code of the writing system.</param>
		/// <param name="index">The index of the writing system.</param>
		/// <param name="name">The name of the writing system.</param>
		public WritingScript(string code, int index, string name)
		{
			this.Code	= code;
			this.Index	= index;
			this.Name	= name;
		}
		#endregion

		/// <summary>
		/// Dictionary of writing systems according to https://en.wikipedia.org/wiki/ISO_15924 .
		/// Key: the code of the wriring system.
		/// Value: the instance of WritingScript.
		/// </summary>
		public static readonly Dictionary<string, WritingScript> WritingScripts = new Dictionary<string, WritingScript>()
		{
			{"Adlm", 	new WritingScript("Adlm",	166, 	"Adlam")},
			{"Afak", 	new WritingScript("Afak",	439, 	"Afaka")},
			{"Aghb", 	new WritingScript("Aghb",	239, 	"Caucasian Albanian")},
			{"Ahom", 	new WritingScript("Ahom",	338, 	"Ahom, Tai Ahom")},
			{"Arab", 	new WritingScript("Arab",	160, 	"Arabic")},
			{"Aran", 	new WritingScript("Aran",	161, 	"Arabic (Nastaliq variant)")},
			{"Armi", 	new WritingScript("Armi",	124, 	"Imperial Aramaic")},
			{"Armn", 	new WritingScript("Armn",	230, 	"Armenian")},
			{"Avst", 	new WritingScript("Avst",	134, 	"Avestan")},
			{"Bali", 	new WritingScript("Bali",	360, 	"Balinese")},
			{"Bamu", 	new WritingScript("Bamu",	435, 	"Bamum")},
			{"Bass", 	new WritingScript("Bass",	259, 	"Bassa Vah")},
			{"Batk", 	new WritingScript("Batk",	365, 	"Batak")},
			{"Beng", 	new WritingScript("Beng",	325, 	"Bengali (Bangla)")},
			{"Bhks", 	new WritingScript("Bhks",	334, 	"Bhaiksuki")},
			{"Blis", 	new WritingScript("Blis",	550, 	"Blissymbols")},
			{"Bopo", 	new WritingScript("Bopo",	285, 	"Bopomofo")},
			{"Brah", 	new WritingScript("Brah",	300, 	"Brahmi")},
			{"Brai", 	new WritingScript("Brai",	570, 	"Braille")},
			{"Bugi", 	new WritingScript("Bugi",	367, 	"Buginese")},
			{"Buhd", 	new WritingScript("Buhd",	372, 	"Buhid")},
			{"Cakm", 	new WritingScript("Cakm",	349, 	"Chakma")},
			{"Cans", 	new WritingScript("Cans",	440, 	"Unified Canadian Aboriginal Syllabics")},
			{"Cari", 	new WritingScript("Cari",	201, 	"Carian")},
			{"Cham", 	new WritingScript("Cham",	358, 	"Cham")},
			{"Cher", 	new WritingScript("Cher",	445, 	"Cherokee")},
			{"Chis", 	new WritingScript("Chis",	298, 	"Chisoi")},
			{"Chrs", 	new WritingScript("Chrs",	109, 	"Chorasmian")},
			{"Cirt", 	new WritingScript("Cirt",	291, 	"Cirth")},
			{"Copt", 	new WritingScript("Copt",	204, 	"Coptic")},
			{"Cpmn", 	new WritingScript("Cpmn",	402, 	"Cypro-Minoan")},
			{"Cprt", 	new WritingScript("Cprt",	403, 	"Cypriot syllabary")},
			{"Cyrl", 	new WritingScript("Cyrl",	220, 	"Cyrillic")},
			{"Cyrs", 	new WritingScript("Cyrs",	221, 	"Cyrillic (Old Church Slavonic variant)")},
			{"Deva", 	new WritingScript("Deva",	315, 	"Devanagari (Nagari)")},
			{"Diak", 	new WritingScript("Diak",	342, 	"Dives Akuru")},
			{"Dogr", 	new WritingScript("Dogr",	328, 	"Dogra")},
			{"Dsrt", 	new WritingScript("Dsrt",	250, 	"Deseret (Mormon)")},
			{"Dupl", 	new WritingScript("Dupl",	755, 	"Duployan shorthand, Duployan stenography")},
			{"Egyd", 	new WritingScript("Egyd",	070, 	"Egyptian demotic")},
			{"Egyh", 	new WritingScript("Egyh",	060, 	"Egyptian hieratic")},
			{"Egyp", 	new WritingScript("Egyp",	050, 	"Egyptian hieroglyphs")},
			{"Elba", 	new WritingScript("Elba",	226, 	"Elbasan")},
			{"Elym", 	new WritingScript("Elym",	128, 	"Elymaic")},
			{"Ethi", 	new WritingScript("Ethi",	430, 	"Ethiopic (Geʻez)")},
			{"Gara", 	new WritingScript("Gara",	164, 	"Garay")},
			{"Geok", 	new WritingScript("Geok",	241, 	"Khutsuri (Asomtavruli and Nuskhuri)")},
			{"Geor", 	new WritingScript("Geor",	240, 	"Georgian (Mkhedruli and Mtavruli)")},
			{"Glag", 	new WritingScript("Glag",	225, 	"Glagolitic")},
			{"Gong", 	new WritingScript("Gong",	312, 	"Gunjala Gondi")},
			{"Gonm", 	new WritingScript("Gonm",	313, 	"Masaram Gondi")},
			{"Goth", 	new WritingScript("Goth",	206, 	"Gothic")},
			{"Gran", 	new WritingScript("Gran",	343, 	"Grantha")},
			{"Grek", 	new WritingScript("Grek",	200, 	"Greek")},
			{"Gujr", 	new WritingScript("Gujr",	320, 	"Gujarati")},
			{"Gukh", 	new WritingScript("Gukh",	397, 	"Gurung Khema")},
			{"Guru", 	new WritingScript("Guru",	310, 	"Gurmukhi")},
			{"Hanb", 	new WritingScript("Hanb",	503, 	"Han with Bopomofo (alias for Han + Bopomofo)")},
			{"Hang", 	new WritingScript("Hang",	286, 	"Hangul (Hangŭl, Hangeul)")},
			{"Hani", 	new WritingScript("Hani",	500, 	"Han (Hanzi, Kanji, Hanja)")},
			{"Hano", 	new WritingScript("Hano",	371, 	"Hanunoo (Hanunóo)")},
			{"Hans", 	new WritingScript("Hans",	501, 	"Han (Simplified variant)")},
			{"Hant", 	new WritingScript("Hant",	502, 	"Han (Traditional variant)")},
			{"Hatr", 	new WritingScript("Hatr",	127, 	"Hatran")},
			{"Hebr", 	new WritingScript("Hebr",	125, 	"Hebrew")},
			{"Hira", 	new WritingScript("Hira",	410, 	"Hiragana")},
			{"Hluw", 	new WritingScript("Hluw",	080, 	"Anatolian Hieroglyphs (Luwian Hieroglyphs, Hittite Hieroglyphs)")},
			{"Hmng", 	new WritingScript("Hmng",	450, 	"Pahawh Hmong")},
			{"Hmnp", 	new WritingScript("Hmnp",	451, 	"Nyiakeng Puachue Hmong")},
			{"Hrkt", 	new WritingScript("Hrkt",	412, 	"Japanese syllabaries (alias for Hiragana + Katakana)")},
			{"Hung", 	new WritingScript("Hung",	176, 	"Old Hungarian (Hungarian Runic)")},
			{"Inds", 	new WritingScript("Inds",	610, 	"Indus (Harappan)")},
			{"Ital", 	new WritingScript("Ital",	210, 	"Old Italic (Etruscan, Oscan, etc.)")},
			{"Jamo", 	new WritingScript("Jamo",	284, 	"Jamo (alias for Jamo subset of Hangul)")},
			{"Java", 	new WritingScript("Java",	361, 	"Javanese")},
			{"Jpan", 	new WritingScript("Jpan",	413, 	"Japanese (alias for Han + Hiragana + Katakana)")},
			{"Jurc", 	new WritingScript("Jurc",	510, 	"Jurchen")},
			{"Kali", 	new WritingScript("Kali",	357, 	"Kayah Li")},
			{"Kana", 	new WritingScript("Kana",	411, 	"Katakana")},
			{"Kawi", 	new WritingScript("Kawi",	368, 	"Kawi")},
			{"Khar", 	new WritingScript("Khar",	305, 	"Kharoshthi")},
			{"Khmr", 	new WritingScript("Khmr",	355, 	"Khmer")},
			{"Khoj", 	new WritingScript("Khoj",	322, 	"Khojki")},
			{"Kitl", 	new WritingScript("Kitl",	505, 	"Khitan large script")},
			{"Kits", 	new WritingScript("Kits",	288, 	"Khitan small script")},
			{"Knda", 	new WritingScript("Knda",	345, 	"Kannada")},
			{"Kore", 	new WritingScript("Kore",	287, 	"Korean (alias for Hangul + Han)")},
			{"Kpel", 	new WritingScript("Kpel",	436, 	"Kpelle")},
			{"Krai", 	new WritingScript("Krai",	396, 	"Kirat Rai")},
			{"Kthi", 	new WritingScript("Kthi",	317, 	"Kaithi")},
			{"Lana", 	new WritingScript("Lana",	351, 	"Tai Tham (Lanna)")},
			{"Laoo", 	new WritingScript("Laoo",	356, 	"Lao")},
			{"Latf", 	new WritingScript("Latf",	217, 	"Latin (Fraktur variant)")},
			{"Latg", 	new WritingScript("Latg",	216, 	"Latin (Gaelic variant)")},
			{"Latn", 	new WritingScript("Latn",	215, 	"Latin")},
			{"Leke", 	new WritingScript("Leke",	364, 	"Leke")},
			{"Lepc", 	new WritingScript("Lepc",	335, 	"Lepcha (Róng)")},
			{"Limb", 	new WritingScript("Limb",	336, 	"Limbu")},
			{"Lina", 	new WritingScript("Lina",	400, 	"Linear A")},
			{"Linb", 	new WritingScript("Linb",	401, 	"Linear B")},
			{"Lisu", 	new WritingScript("Lisu",	399, 	"Lisu (Fraser)")},
			{"Loma", 	new WritingScript("Loma",	437, 	"Loma")},
			{"Lyci", 	new WritingScript("Lyci",	202, 	"Lycian")},
			{"Lydi", 	new WritingScript("Lydi",	116, 	"Lydian")},
			{"Mahj", 	new WritingScript("Mahj",	314, 	"Mahajani")},
			{"Maka", 	new WritingScript("Maka",	366, 	"Makasar")},
			{"Mand", 	new WritingScript("Mand",	140, 	"Mandaic, Mandaean")},
			{"Mani", 	new WritingScript("Mani",	139, 	"Manichaean")},
			{"Marc", 	new WritingScript("Marc",	332, 	"Marchen")},
			{"Maya", 	new WritingScript("Maya",	090, 	"Mayan hieroglyphs")},
			{"Medf", 	new WritingScript("Medf",	265, 	"Medefaidrin (Oberi Okaime, Oberi Ɔkaimɛ)")},
			{"Mend", 	new WritingScript("Mend",	438, 	"Mende Kikakui")},
			{"Merc", 	new WritingScript("Merc",	101, 	"Meroitic Cursive")},
			{"Mero", 	new WritingScript("Mero",	100, 	"Meroitic Hieroglyphs")},
			{"Mlym", 	new WritingScript("Mlym",	347, 	"Malayalam")},
			{"Modi", 	new WritingScript("Modi",	324, 	"Modi, Moḍī")},
			{"Mong", 	new WritingScript("Mong",	145, 	"Mongolian")},
			{"Moon", 	new WritingScript("Moon",	218, 	"Moon (Moon code, Moon script, Moon type)")},
			{"Mroo", 	new WritingScript("Mroo",	264, 	"Mro, Mru")},
			{"Mtei", 	new WritingScript("Mtei",	337, 	"Meitei Mayek (Meithei, Meetei)")},
			{"Mult", 	new WritingScript("Mult",	323, 	"Multani")},
			{"Mymr", 	new WritingScript("Mymr",	350, 	"Myanmar (Burmese)")},
			{"Nagm", 	new WritingScript("Nagm",	295, 	"Nag Mundari")},
			{"Nand", 	new WritingScript("Nand",	311, 	"Nandinagari")},
			{"Narb", 	new WritingScript("Narb",	106, 	"Old North Arabian (Ancient North Arabian)")},
			{"Nbat", 	new WritingScript("Nbat",	159, 	"Nabataean")},
			{"Newa", 	new WritingScript("Newa",	333, 	"Newa, Newar, Newari, Nepāla lipi")},
			{"Nkdb", 	new WritingScript("Nkdb",	085, 	"Naxi Dongba (na²¹ɕi³³ to³³ba²¹, Nakhi Tomba)")},
			{"Nkgb", 	new WritingScript("Nkgb",	420, 	"Naxi Geba (na²¹ɕi³³ gʌ²¹ba²¹, 'Na-'Khi ²Ggŏ-¹baw, Nakhi Geba)")},
			{"Nkoo", 	new WritingScript("Nkoo",	165, 	"N’Ko")},
			{"Nshu", 	new WritingScript("Nshu",	499, 	"Nüshu")},
			{"Ogam", 	new WritingScript("Ogam",	212, 	"Ogham")},
			{"Olck", 	new WritingScript("Olck",	261, 	"Ol Chiki (Ol Cemet’, Ol, Santali)")},
			{"Onao", 	new WritingScript("Onao",	296, 	"Ol Onal")},
			{"Orkh", 	new WritingScript("Orkh",	175, 	"Old Turkic, Orkhon Runic")},
			{"Orya", 	new WritingScript("Orya",	327, 	"Oriya (Odia)")},
			{"Osge", 	new WritingScript("Osge",	219, 	"Osage")},
			{"Osma", 	new WritingScript("Osma",	260, 	"Osmanya")},
			{"Ougr", 	new WritingScript("Ougr",	143, 	"Old Uyghur")},
			{"Palm", 	new WritingScript("Palm",	126, 	"Palmyrene")},
			{"Pauc", 	new WritingScript("Pauc",	263, 	"Pau Cin Hau")},
			{"Pcun", 	new WritingScript("Pcun",	015, 	"Proto-Cuneiform")},
			{"Pelm", 	new WritingScript("Pelm",	016, 	"Proto-Elamite")},
			{"Perm", 	new WritingScript("Perm",	227, 	"Old Permic")},
			{"Phag", 	new WritingScript("Phag",	331, 	"Phags-pa")},
			{"Phli", 	new WritingScript("Phli",	131, 	"Inscriptional Pahlavi")},
			{"Phlp", 	new WritingScript("Phlp",	132, 	"Psalter Pahlavi")},
			{"Phlv", 	new WritingScript("Phlv",	133, 	"Book Pahlavi")},
			{"Phnx", 	new WritingScript("Phnx",	115, 	"Phoenician")},
			{"Piqd", 	new WritingScript("Piqd",	293, 	"Klingon (KLI pIqaD)")},
			{"Plrd", 	new WritingScript("Plrd",	282, 	"Miao (Pollard)")},
			{"Prti", 	new WritingScript("Prti",	130, 	"Inscriptional Parthian")},
			{"Psin", 	new WritingScript("Psin",	103, 	"Proto-Sinaitic")},
			{"Qaaa", 	new WritingScript("Qaaa",	949,	"Reserved for private use (range)")},
			{"Ranj", 	new WritingScript("Ranj",	303, 	"Ranjana")},
			{"Rjng", 	new WritingScript("Rjng",	363, 	"Rejang (Redjang, Kaganga)")},
			{"Rohg", 	new WritingScript("Rohg",	167, 	"Hanifi Rohingya")},
			{"Roro", 	new WritingScript("Roro",	620, 	"Rongorongo")},
			{"Runr", 	new WritingScript("Runr",	211, 	"Runic")},
			{"Samr", 	new WritingScript("Samr",	123, 	"Samaritan")},
			{"Sara", 	new WritingScript("Sara",	292, 	"Sarati")},
			{"Sarb", 	new WritingScript("Sarb",	105, 	"Old South Arabian")},
			{"Saur", 	new WritingScript("Saur",	344, 	"Saurashtra")},
			{"Sgnw", 	new WritingScript("Sgnw",	095, 	"SignWriting")},
			{"Shaw", 	new WritingScript("Shaw",	281, 	"Shavian (Shaw)")},
			{"Shrd", 	new WritingScript("Shrd",	319, 	"Sharada, Śāradā")},
			{"Shui", 	new WritingScript("Shui",	530, 	"Shuishu")},
			{"Sidd", 	new WritingScript("Sidd",	302, 	"Siddham, Siddhaṃ, Siddhamātṛkā")},
			{"Sidt", 	new WritingScript("Sidt",	180, 	"Sidetic")},
			{"Sind", 	new WritingScript("Sind",	318, 	"Khudawadi, Sindhi")},
			{"Sinh", 	new WritingScript("Sinh",	348, 	"Sinhala")},
			{"Sogd", 	new WritingScript("Sogd",	141, 	"Sogdian")},
			{"Sogo", 	new WritingScript("Sogo",	142, 	"Old Sogdian")},
			{"Sora", 	new WritingScript("Sora",	398, 	"Sora Sompeng")},
			{"Soyo", 	new WritingScript("Soyo",	329, 	"Soyombo")},
			{"Sund", 	new WritingScript("Sund",	362, 	"Sundanese")},
			{"Sunu", 	new WritingScript("Sunu",	274, 	"Sunuwar")},
			{"Sylo", 	new WritingScript("Sylo",	316, 	"Syloti Nagri")},
			{"Syrc", 	new WritingScript("Syrc",	135, 	"Syriac")},
			{"Syre", 	new WritingScript("Syre",	138, 	"Syriac (Estrangelo variant)")},
			{"Syrj", 	new WritingScript("Syrj",	137, 	"Syriac (Western variant)")},
			{"Syrn", 	new WritingScript("Syrn",	136, 	"Syriac (Eastern variant)")},
			{"Tagb", 	new WritingScript("Tagb",	373, 	"Tagbanwa")},
			{"Takr", 	new WritingScript("Takr",	321, 	"Takri, Ṭākrī, Ṭāṅkrī")},
			{"Tale", 	new WritingScript("Tale",	353, 	"Tai Le")},
			{"Talu", 	new WritingScript("Talu",	354, 	"New Tai Lue")},
			{"Taml", 	new WritingScript("Taml",	346, 	"Tamil")},
			{"Tang", 	new WritingScript("Tang",	520, 	"Tangut")},
			{"Tavt", 	new WritingScript("Tavt",	359, 	"Tai Viet")},
			{"Tayo", 	new WritingScript("Tayo",	380, 	"Tai Yo")},
			{"Telu", 	new WritingScript("Telu",	340, 	"Telugu")},
			{"Teng", 	new WritingScript("Teng",	290, 	"Tengwar")},
			{"Tfng", 	new WritingScript("Tfng",	120, 	"Tifinagh (Berber)")},
			{"Tglg", 	new WritingScript("Tglg",	370, 	"Tagalog (Baybayin, Alibata)")},
			{"Thaa", 	new WritingScript("Thaa",	170, 	"Thaana")},
			{"Thai", 	new WritingScript("Thai",	352, 	"Thai")},
			{"Tibt", 	new WritingScript("Tibt",	330, 	"Tibetan")},
			{"Tirh", 	new WritingScript("Tirh",	326, 	"Tirhuta")},
			{"Tnsa", 	new WritingScript("Tnsa",	275, 	"Tangsa")},
			{"Todr", 	new WritingScript("Todr",	229, 	"Todhri")},
			{"Tols", 	new WritingScript("Tols",	299, 	"Tolong Siki")},
			{"Toto", 	new WritingScript("Toto",	294, 	"Toto")},
			{"Tutg", 	new WritingScript("Tutg",	341, 	"Tulu-Tigalari")},
			{"Ugar", 	new WritingScript("Ugar",	040, 	"Ugaritic")},
			{"Vaii", 	new WritingScript("Vaii",	470, 	"Vai")},
			{"Visp", 	new WritingScript("Visp",	280, 	"Visible Speech")},
			{"Vith", 	new WritingScript("Vith",	228, 	"Vithkuqi")},
			{"Wara", 	new WritingScript("Wara",	262, 	"Warang Citi (Varang Kshiti)")},
			{"Wcho", 	new WritingScript("Wcho",	283, 	"Wancho")},
			{"Wole", 	new WritingScript("Wole",	480, 	"Woleai")},
			{"Xpeo", 	new WritingScript("Xpeo",	030, 	"Old Persian")},
			{"Xsux", 	new WritingScript("Xsux",	020, 	"Cuneiform, Sumero-Akkadian")},
			{"Yezi", 	new WritingScript("Yezi",	192, 	"Yezidi")},
			{"Yiii", 	new WritingScript("Yiii",	460, 	"Yi")},
			{"Zanb", 	new WritingScript("Zanb",	339, 	"Zanabazar Square (Zanabazarin Dörböljin Useg, Xewtee Dörböljin Bicig, Horizontal Square Script)")},
			{"Zinh", 	new WritingScript("Zinh",	994, 	"Code for inherited script")},
			{"Zmth", 	new WritingScript("Zmth",	995, 	"Mathematical notation")},
			{"Zsym", 	new WritingScript("Zsym",	996, 	"Symbols")},
			{"Zsye", 	new WritingScript("Zsye",	993, 	"Symbols (emoji variant)")},
			{"Zxxx", 	new WritingScript("Zxxx",	997, 	"Code for unwritten documents")},
			{"Zyyy", 	new WritingScript("Zyyy",	998, 	"Code for undetermined script")},
			{"Zzzz", 	new WritingScript("Zzzz",	999, 	"Code for uncoded script")},
		};
	}
}
