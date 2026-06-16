/**********************************************************************************************
* File:         Language.cs                                                                   *
* Contents:     Class Language                                                                *
* Author:       Alex Konnen (info@pikkatech.eu)                                               *
* Date:         2014-05-31 09:56                                                              *
* Version:      1.0                                                                           *
* Copyright:    PikkaTech Development and Consulting (www.pikkatech.eu)                       *
**********************************************************************************************/
namespace Factotum.Dictionaries
{
	///	Provides an abstraction of a language classification 
	///	according to ISO-639 (http://de.wikipedia.org/wiki/ISO_639),
	///	including alpha-2, alpha-3 and numerical representation.
	///	Stand: 2009
	///	http://www.loc.gov/standards/iso639-2/php/code_list.php
	public class Language
	{
		#region Properties
		/// <summary>
		/// Two-character representation of a language, e.g. "de" for German.
		/// </summary>
		public string Alpha2 {get;set;}

		/// <summary>
		/// Three-character representation of a language, e.g. "ger" for German.
		/// </summary>
		public string Alpha3 {get;set;}

		/// <summary>
		/// Representative name of the language
		/// </summary>
		public string Name {get;set;}
		#endregion

		#region String representation
		/// <summary>
		/// String representation.
		/// </summary>
		/// <returns>The name of the language.</returns>
		public override string ToString()
		{
			return this.Name;
		}
		#endregion

		#region Static Data
		/// <summary>
		/// Dictionary of languages according to http://de.wikipedia.org/wiki/ISO_639 .
		/// Key: the code of the language
		/// Value: the instance of Language.
		/// </summary>
		public readonly static Language[] Languages = new Language[]
		{
			new Language{Alpha3="eng",	Alpha2="en",	Name="English"},
			new Language{Alpha3="deu",	Alpha2="de",	Name="German"},
			new Language{Alpha3="fra",	Alpha2="fr",	Name="French"},
			new Language{Alpha3="spa",	Alpha2="es",	Name="Spanish"},
			new Language{Alpha3="ita",	Alpha2="it",	Name="Italian"},
			new Language{Alpha3="por",	Alpha2="pt",	Name="Portuguese"},
			new Language{Alpha3="rus",	Alpha2="ru",	Name="Russian"},
			new Language{Alpha3="zho",	Alpha2="zh",	Name="Chinese"},
			new Language{Alpha3="ara",	Alpha2="ar",	Name="Arabic"},
			new Language{Alpha3="hin",	Alpha2="hi",	Name="Hindi"},
			new Language{Alpha3="urd",	Alpha2="ur",	Name="Urdu"},
			new Language{Alpha3="ben",	Alpha2="bn",	Name="Bengali"},
			new Language{Alpha3="jpn",	Alpha2="ja",	Name="Japanese"},
			new Language{Alpha3="tur",	Alpha2="tr",	Name="Turkish"},
			new Language{Alpha3="kor",	Alpha2="ko",	Name="Korean"},
			new Language{Alpha3="pol",	Alpha2="pl",	Name="Polish"},
			new Language{Alpha3="ukr",	Alpha2="uk",	Name="Ukrainian"},
			new Language{Alpha3="fas",	Alpha2="fa",	Name="Persian"},
			new Language{Alpha3="aar",	Alpha2="aa",	Name="Afar"},
			new Language{Alpha3="abk",	Alpha2="ab",	Name="Abkhazian"},
			new Language{Alpha3="ace",	Alpha2="",		Name="Achinese"},
			new Language{Alpha3="ach",	Alpha2="",		Name="Acoli"},
			new Language{Alpha3="ada",	Alpha2="",		Name="Adangme"},
			new Language{Alpha3="ady",	Alpha2="",		Name="Adyghe; Adygei"},
			new Language{Alpha3="afa",	Alpha2="",		Name="Afro-Asiatic languages"},
			new Language{Alpha3="afh",	Alpha2="",		Name="Afrihili"},
			new Language{Alpha3="afr",	Alpha2="af",	Name="Afrikaans"},
			new Language{Alpha3="ain",	Alpha2="",		Name="Ainu"},
			new Language{Alpha3="aka",	Alpha2="ak",	Name="Akan"},
			new Language{Alpha3="akk",	Alpha2="",		Name="Akkadian"},
			new Language{Alpha3="sqi",	Alpha2="sq",	Name="Albanian"},
			new Language{Alpha3="ale",	Alpha2="",		Name="Aleut"},
			new Language{Alpha3="alg",	Alpha2="",		Name="Algonquian languages"},
			new Language{Alpha3="alt",	Alpha2="",		Name="Southern Altai"},
			new Language{Alpha3="amh",	Alpha2="am",	Name="Amharic"},
			new Language{Alpha3="ang",	Alpha2="",		Name="English, Old (ca.450-1100)"},
			new Language{Alpha3="anp",	Alpha2="",		Name="Angika"},
			new Language{Alpha3="apa",	Alpha2="",		Name="Apache languages"},
			new Language{Alpha3="arc",	Alpha2="",		Name="Official Aramaic (700-300 BCE, Imperial Aramaic (700-300 BCE)"},
			new Language{Alpha3="arg",	Alpha2="an",	Name="Aragonese"},
			new Language{Alpha3="hye",	Alpha2="hy",	Name="Armenian"},
			new Language{Alpha3="arn",	Alpha2="",		Name="Mapudungun; Mapuche"},
			new Language{Alpha3="arp",	Alpha2="",		Name="Arapaho"},
			new Language{Alpha3="art",	Alpha2="",		Name="Artificial languages"},
			new Language{Alpha3="arw",	Alpha2="",		Name="Arawak"},
			new Language{Alpha3="asm",	Alpha2="as",	Name="Assamese"},
			new Language{Alpha3="ast",	Alpha2="",		Name="Asturian; Bable; Leonese; Asturleonese"},
			new Language{Alpha3="ath",	Alpha2="",		Name="Athapascan languages"},
			new Language{Alpha3="aus",	Alpha2="",		Name="Australian languages"},
			new Language{Alpha3="ava",	Alpha2="av",	Name="Avaric"},
			new Language{Alpha3="ave",	Alpha2="ae",	Name="Avestan"},
			new Language{Alpha3="awa",	Alpha2="",		Name="Awadhi"},
			new Language{Alpha3="aym",	Alpha2="ay",	Name="Aymara"},
			new Language{Alpha3="aze",	Alpha2="az",	Name="Azerbaijani"},
			new Language{Alpha3="bad",	Alpha2="",		Name="Banda languages"},
			new Language{Alpha3="bai",	Alpha2="",		Name="Bamileke languages"},
			new Language{Alpha3="bak",	Alpha2="ba",	Name="Bashkir"},
			new Language{Alpha3="bal",	Alpha2="",		Name="Baluchi"},
			new Language{Alpha3="bam",	Alpha2="bm",	Name="Bambara"},
			new Language{Alpha3="ban",	Alpha2="",		Name="Balinese"},
			new Language{Alpha3="eus",	Alpha2="eu",	Name="Basque"},
			new Language{Alpha3="bas",	Alpha2="",		Name="Basa"},
			new Language{Alpha3="bat",	Alpha2="",		Name="Baltic languages"},
			new Language{Alpha3="bej",	Alpha2="",		Name="Beja; Bedawiyet"},
			new Language{Alpha3="bel",	Alpha2="be",	Name="Belarusian"},
			new Language{Alpha3="bem",	Alpha2="",		Name="Bemba"},
			new Language{Alpha3="ber",	Alpha2="",		Name="Berber languages"},
			new Language{Alpha3="bho",	Alpha2="",		Name="Bhojpuri"},
			new Language{Alpha3="bih",	Alpha2="bh",	Name="Bihari languages"},
			new Language{Alpha3="bik",	Alpha2="",		Name="Bikol"},
			new Language{Alpha3="bin",	Alpha2="",		Name="Bini; Edo"},
			new Language{Alpha3="bis",	Alpha2="bi",	Name="Bislama"},
			new Language{Alpha3="bla",	Alpha2="",		Name="Siksika"},
			new Language{Alpha3="bnt",	Alpha2="",		Name="Bantu languages"},
			new Language{Alpha3="bod",	Alpha2="bo",	Name="Tibetan"},
			new Language{Alpha3="bos",	Alpha2="bs",	Name="Bosnian"},
			new Language{Alpha3="bra",	Alpha2="",		Name="Braj"},
			new Language{Alpha3="bre",	Alpha2="br",	Name="Breton"},
			new Language{Alpha3="btk",	Alpha2="",		Name="Batak languages"},
			new Language{Alpha3="bua",	Alpha2="",		Name="Buriat"},
			new Language{Alpha3="bug",	Alpha2="",		Name="Buginese"},
			new Language{Alpha3="bul",	Alpha2="bg",	Name="Bulgarian"},
			new Language{Alpha3="mya",	Alpha2="my",	Name="Burmese"},
			new Language{Alpha3="byn",	Alpha2="",		Name="Blin; Bilin"},
			new Language{Alpha3="cad",	Alpha2="",		Name="Caddo"},
			new Language{Alpha3="cai",	Alpha2="",		Name="Central American Indian languages"},
			new Language{Alpha3="car",	Alpha2="",		Name="Galibi Carib"},
			new Language{Alpha3="cat",	Alpha2="ca",	Name="Catalan; Valencian"},
			new Language{Alpha3="cau",	Alpha2="",		Name="Caucasian languages"},
			new Language{Alpha3="ceb",	Alpha2="",		Name="Cebuano"},
			new Language{Alpha3="cel",	Alpha2="",		Name="Celtic languages"},
			new Language{Alpha3="ces",	Alpha2="cs",	Name="Czech"},
			new Language{Alpha3="cha",	Alpha2="ch",	Name="Chamorro"},
			new Language{Alpha3="chb",	Alpha2="",		Name="Chibcha"},
			new Language{Alpha3="che",	Alpha2="ce",	Name="Chechen"},
			new Language{Alpha3="chg",	Alpha2="",		Name="Chagatai"},
			new Language{Alpha3="chk",	Alpha2="",		Name="Chuukese"},
			new Language{Alpha3="chm",	Alpha2="",		Name="Mari"},
			new Language{Alpha3="chn",	Alpha2="",		Name="Chinook jargon"},
			new Language{Alpha3="cho",	Alpha2="",		Name="Choctaw"},
			new Language{Alpha3="chp",	Alpha2="",		Name="Chipewyan; Dene Suline"},
			new Language{Alpha3="chr",	Alpha2="",		Name="Cherokee"},
			new Language{Alpha3="chu",	Alpha2="cu",	Name="Church Slavic; Old Slavonic; Church Slavonic; Old Bulgarian; Old Church Slavonic"},
			new Language{Alpha3="chv",	Alpha2="cv",	Name="Chuvash"},
			new Language{Alpha3="chy",	Alpha2="",		Name="Cheyenne"},
			new Language{Alpha3="cmc",	Alpha2="",		Name="Chamic languages"},
			new Language{Alpha3="cop",	Alpha2="",		Name="Coptic"},
			new Language{Alpha3="cor",	Alpha2="kw",	Name="Cornish"},
			new Language{Alpha3="cos",	Alpha2="co",	Name="Corsican"},
			new Language{Alpha3="cpe",	Alpha2="",		Name="Creoles and pidgins, English based"},
			new Language{Alpha3="cpf",	Alpha2="",		Name="Creoles and pidgins, French-based"},
			new Language{Alpha3="cpp",	Alpha2="",		Name="Creoles and pidgins, Portuguese-based"},
			new Language{Alpha3="cre",	Alpha2="cr",	Name="Cree"},
			new Language{Alpha3="crh",	Alpha2="",		Name="Crimean Tatar; Crimean Turkish"},
			new Language{Alpha3="crp",	Alpha2="",		Name="Creoles and pidgins"},
			new Language{Alpha3="csb",	Alpha2="",		Name="Kashubian"},
			new Language{Alpha3="cus",	Alpha2="",		Name="Cushitic languages"},
			new Language{Alpha3="cym",	Alpha2="cy",	Name="Welsh"},
			new Language{Alpha3="ces",	Alpha2="cs",	Name="Czech"},
			new Language{Alpha3="dak",	Alpha2="",		Name="Dakota"},
			new Language{Alpha3="dan",	Alpha2="da",	Name="Danish"},
			new Language{Alpha3="dar",	Alpha2="",		Name="Dargwa"},
			new Language{Alpha3="day",	Alpha2="",		Name="Land Dayak languages"},
			new Language{Alpha3="del",	Alpha2="",		Name="Delaware"},
			new Language{Alpha3="den",	Alpha2="",		Name="Slave (Athapascan)"},
			new Language{Alpha3="dgr",	Alpha2="",		Name="Dogrib"},
			new Language{Alpha3="din",	Alpha2="",		Name="Dinka"},
			new Language{Alpha3="div",	Alpha2="dv",	Name="Divehi; Dhivehi; Maldivian"},
			new Language{Alpha3="doi",	Alpha2="",		Name="Dogri"},
			new Language{Alpha3="dra",	Alpha2="",		Name="Dravidian languages"},
			new Language{Alpha3="dsb",	Alpha2="",		Name="Lower Sorbian"},
			new Language{Alpha3="dua",	Alpha2="",		Name="Duala"},
			new Language{Alpha3="dum",	Alpha2="",		Name="Dutch, Middle (ca.1050-1350)"},
			new Language{Alpha3="nld",	Alpha2="nl",	Name="Dutch; Flemish"},
			new Language{Alpha3="dyu",	Alpha2="",		Name="Dyula"},
			new Language{Alpha3="dzo",	Alpha2="dz",	Name="Dzongkha"},
			new Language{Alpha3="efi",	Alpha2="",		Name="Efik"},
			new Language{Alpha3="egy",	Alpha2="",		Name="Egyptian (Ancient)"},
			new Language{Alpha3="eka",	Alpha2="",		Name="Ekajuk"},
			new Language{Alpha3="ell",	Alpha2="el",	Name="Greek, Modern (1453-)"},
			new Language{Alpha3="elx",	Alpha2="",		Name="Elamite"},
			new Language{Alpha3="enm",	Alpha2="",		Name="English, Middle (1100-1500)"},
			new Language{Alpha3="epo",	Alpha2="eo",	Name="Esperanto"},
			new Language{Alpha3="est",	Alpha2="et",	Name="Estonian"},
			new Language{Alpha3="eus",	Alpha2="eu",	Name="Basque"},
			new Language{Alpha3="ewe",	Alpha2="ee",	Name="Ewe"},
			new Language{Alpha3="ewo",	Alpha2="",		Name="Ewondo"},
			new Language{Alpha3="fan",	Alpha2="",		Name="Fang"},
			new Language{Alpha3="fao",	Alpha2="fo",	Name="Faroese"},
			new Language{Alpha3="fat",	Alpha2="",		Name="Fanti"},
			new Language{Alpha3="fij",	Alpha2="fj",	Name="Fijian"},
			new Language{Alpha3="fil",	Alpha2="",		Name="Filipino; Pilipino"},
			new Language{Alpha3="fin",	Alpha2="fi",	Name="Finnish"},
			new Language{Alpha3="fiu",	Alpha2="",		Name="Finno-Ugrian languages"},
			new Language{Alpha3="fon",	Alpha2="",		Name="Fon"},
			new Language{Alpha3="frm",	Alpha2="",		Name="French, Middle (ca.1400-1600)"},
			new Language{Alpha3="fro",	Alpha2="",		Name="French, Old (842-ca.1400)"},
			new Language{Alpha3="frr",	Alpha2="",		Name="Northern Frisian"},
			new Language{Alpha3="frs",	Alpha2="",		Name="Eastern Frisian"},
			new Language{Alpha3="fry",	Alpha2="fy",	Name="Western Frisian"},
			new Language{Alpha3="ful",	Alpha2="ff",	Name="Fulah"},
			new Language{Alpha3="fur",	Alpha2="",		Name="Friulian"},
			new Language{Alpha3="gaa",	Alpha2="",		Name="Ga"},
			new Language{Alpha3="gay",	Alpha2="",		Name="Gayo"},
			new Language{Alpha3="gba",	Alpha2="",		Name="Gbaya"},
			new Language{Alpha3="gem",	Alpha2="",		Name="Germanic languages"},
			new Language{Alpha3="kat",	Alpha2="ka",	Name="Georgian"},
			new Language{Alpha3="deu",	Alpha2="de",	Name="German"},
			new Language{Alpha3="gez",	Alpha2="",		Name="Geez"},
			new Language{Alpha3="gil",	Alpha2="",		Name="Gilbertese"},
			new Language{Alpha3="gla",	Alpha2="gd",	Name="Gaelic; Scottish Gaelic"},
			new Language{Alpha3="gle",	Alpha2="ga",	Name="Irish"},
			new Language{Alpha3="glg",	Alpha2="gl",	Name="Galician"},
			new Language{Alpha3="glv",	Alpha2="gv",	Name="Manx"},
			new Language{Alpha3="gmh",	Alpha2="",		Name="German, Middle High (ca.1050-1500)"},
			new Language{Alpha3="goh",	Alpha2="",		Name="German, Old High (ca.750-1050)"},
			new Language{Alpha3="gon",	Alpha2="",		Name="Gondi"},
			new Language{Alpha3="gor",	Alpha2="",		Name="Gorontalo"},
			new Language{Alpha3="got",	Alpha2="",		Name="Gothic"},
			new Language{Alpha3="grb",	Alpha2="",		Name="Grebo"},
			new Language{Alpha3="grc",	Alpha2="",		Name="Greek, Ancient (to 1453)"},
			new Language{Alpha3="ell",	Alpha2="el",	Name="Greek, Modern (1453-)"},
			new Language{Alpha3="grn",	Alpha2="gn",	Name="Guarani"},
			new Language{Alpha3="gsw",	Alpha2="",		Name="Swiss German; Alemannic; Alsatian"},
			new Language{Alpha3="guj",	Alpha2="gu",	Name="Gujarati"},
			new Language{Alpha3="gwi",	Alpha2="",		Name="Gwich'in"},
			new Language{Alpha3="hai",	Alpha2="",		Name="Haida"},
			new Language{Alpha3="hat",	Alpha2="ht",	Name="Haitian; Haitian Creole"},
			new Language{Alpha3="hau",	Alpha2="ha",	Name="Hausa"},
			new Language{Alpha3="haw",	Alpha2="",		Name="Hawaiian"},
			new Language{Alpha3="heb",	Alpha2="he",	Name="Hebrew"},
			new Language{Alpha3="her",	Alpha2="hz",	Name="Herero"},
			new Language{Alpha3="hil",	Alpha2="",		Name="Hiligaynon"},
			new Language{Alpha3="him",	Alpha2="",		Name="Himachali languages; Western Pahari languages"},
			new Language{Alpha3="hit",	Alpha2="",		Name="Hittite"},
			new Language{Alpha3="hmn",	Alpha2="",		Name="Hmong"},
			new Language{Alpha3="hmo",	Alpha2="ho",	Name="Hiri Motu"},
			new Language{Alpha3="hrv",	Alpha2="hr",	Name="Croatian"},
			new Language{Alpha3="hsb",	Alpha2="",		Name="Upper Sorbian"},
			new Language{Alpha3="hun",	Alpha2="hu",	Name="Hungarian"},
			new Language{Alpha3="hup",	Alpha2="",		Name="Hupa"},
			new Language{Alpha3="hye",	Alpha2="hy",	Name="Armenian"},
			new Language{Alpha3="iba",	Alpha2="",		Name="Iban"},
			new Language{Alpha3="ibo",	Alpha2="ig",	Name="Igbo"},
			new Language{Alpha3="isl",	Alpha2="is",	Name="Icelandic"},
			new Language{Alpha3="ido",	Alpha2="io",	Name="Ido"},
			new Language{Alpha3="iii",	Alpha2="ii",	Name="Sichuan Yi; Nuosu"},
			new Language{Alpha3="ijo",	Alpha2="",		Name="Ijo languages"},
			new Language{Alpha3="iku",	Alpha2="iu",	Name="Inuktitut"},
			new Language{Alpha3="ile",	Alpha2="ie",	Name="Interlingue; Occidental"},
			new Language{Alpha3="ilo",	Alpha2="",		Name="Iloko"},
			new Language{Alpha3="ina",	Alpha2="ia",	Name="Interlingua (International Auxiliary Language Association)"},
			new Language{Alpha3="inc",	Alpha2="",		Name="Indic languages"},
			new Language{Alpha3="ind",	Alpha2="id",	Name="Indonesian"},
			new Language{Alpha3="ine",	Alpha2="",		Name="Indo-European languages"},
			new Language{Alpha3="inh",	Alpha2="",		Name="Ingush"},
			new Language{Alpha3="ipk",	Alpha2="ik",	Name="Inupiaq"},
			new Language{Alpha3="ira",	Alpha2="",		Name="Iranian languages"},
			new Language{Alpha3="iro",	Alpha2="",		Name="Iroquoian languages"},
			new Language{Alpha3="isl",	Alpha2="is",	Name="Icelandic"},
			new Language{Alpha3="jav",	Alpha2="jv",	Name="Javanese"},
			new Language{Alpha3="jbo",	Alpha2="",		Name="Lojban"},
			new Language{Alpha3="jpr",	Alpha2="",		Name="Judeo-Persian"},
			new Language{Alpha3="jrb",	Alpha2="",		Name="Judeo-Arabic"},
			new Language{Alpha3="kaa",	Alpha2="",		Name="Kara-Kalpak"},
			new Language{Alpha3="kab",	Alpha2="",		Name="Kabyle"},
			new Language{Alpha3="kac",	Alpha2="",		Name="Kachin; Jingpho"},
			new Language{Alpha3="kal",	Alpha2="kl",	Name="Kalaallisut; Greenlandic"},
			new Language{Alpha3="kam",	Alpha2="",		Name="Kamba"},
			new Language{Alpha3="kan",	Alpha2="kn",	Name="Kannada"},
			new Language{Alpha3="kar",	Alpha2="",		Name="Karen languages"},
			new Language{Alpha3="kas",	Alpha2="ks",	Name="Kashmiri"},
			new Language{Alpha3="kat",	Alpha2="ka",	Name="Georgian"},
			new Language{Alpha3="kau",	Alpha2="kr",	Name="Kanuri"},
			new Language{Alpha3="kaw",	Alpha2="",		Name="Kawi"},
			new Language{Alpha3="kaz",	Alpha2="kk",	Name="Kazakh"},
			new Language{Alpha3="kbd",	Alpha2="",		Name="Kabardian"},
			new Language{Alpha3="kha",	Alpha2="",		Name="Khasi"},
			new Language{Alpha3="khi",	Alpha2="",		Name="Khoisan languages"},
			new Language{Alpha3="khm",	Alpha2="km",	Name="Central Khmer"},
			new Language{Alpha3="kho",	Alpha2="",		Name="Khotanese; Sakan"},
			new Language{Alpha3="kik",	Alpha2="ki",	Name="Kikuyu; Gikuyu"},
			new Language{Alpha3="kin",	Alpha2="rw",	Name="Kinyarwanda"},
			new Language{Alpha3="kir",	Alpha2="ky",	Name="Kirghiz; Kyrgyz"},
			new Language{Alpha3="kmb",	Alpha2="",		Name="Kimbundu"},
			new Language{Alpha3="kok",	Alpha2="",		Name="Konkani"},
			new Language{Alpha3="kom",	Alpha2="kv",	Name="Komi"},
			new Language{Alpha3="kon",	Alpha2="kg",	Name="Kongo"},
			new Language{Alpha3="kos",	Alpha2="",		Name="Kosraean"},
			new Language{Alpha3="kpe",	Alpha2="",		Name="Kpelle"},
			new Language{Alpha3="krc",	Alpha2="",		Name="Karachay-Balkar"},
			new Language{Alpha3="krl",	Alpha2="",		Name="Karelian"},
			new Language{Alpha3="kro",	Alpha2="",		Name="Kru languages"},
			new Language{Alpha3="kru",	Alpha2="",		Name="Kurukh"},
			new Language{Alpha3="kua",	Alpha2="kj",	Name="Kuanyama; Kwanyama"},
			new Language{Alpha3="kum",	Alpha2="",		Name="Kumyk"},
			new Language{Alpha3="kur",	Alpha2="ku",	Name="Kurdish"},
			new Language{Alpha3="kut",	Alpha2="",		Name="Kutenai"},
			new Language{Alpha3="lad",	Alpha2="",		Name="Ladino"},
			new Language{Alpha3="lah",	Alpha2="",		Name="Lahnda"},
			new Language{Alpha3="lam",	Alpha2="",		Name="Lamba"},
			new Language{Alpha3="lao",	Alpha2="lo",	Name="Lao"},
			new Language{Alpha3="lat",	Alpha2="language",	Name="Latin"},
			new Language{Alpha3="lav",	Alpha2="lv",	Name="Latvian"},
			new Language{Alpha3="lez",	Alpha2="",		Name="Lezghian"},
			new Language{Alpha3="lim",	Alpha2="li",	Name="Limburgan; Limburger; Limburgish"},
			new Language{Alpha3="lin",	Alpha2="ln",	Name="Lingala"},
			new Language{Alpha3="lit",	Alpha2="lt",	Name="Lithuanian"},
			new Language{Alpha3="lol",	Alpha2="",		Name="Mongo"},
			new Language{Alpha3="loz",	Alpha2="",		Name="Lozi"},
			new Language{Alpha3="ltz",	Alpha2="lb",	Name="Luxembourgish; Letzeburgesch"},
			new Language{Alpha3="lua",	Alpha2="",		Name="Luba-Lulua"},
			new Language{Alpha3="lub",	Alpha2="lu",	Name="Luba-Katanga"},
			new Language{Alpha3="lug",	Alpha2="lg",	Name="Ganda"},
			new Language{Alpha3="lui",	Alpha2="",		Name="Luiseno"},
			new Language{Alpha3="lun",	Alpha2="",		Name="Lunda"},
			new Language{Alpha3="luo",	Alpha2="",		Name="Luo (Kenya and Tanzania)"},
			new Language{Alpha3="lus",	Alpha2="",		Name="Lushai"},
			new Language{Alpha3="mkd",	Alpha2="mk",	Name="Macedonian"},
			new Language{Alpha3="mad",	Alpha2="",		Name="Madurese"},
			new Language{Alpha3="mag",	Alpha2="",		Name="Magahi"},
			new Language{Alpha3="mah",	Alpha2="mh",	Name="Marshallese"},
			new Language{Alpha3="mai",	Alpha2="",		Name="Maithili"},
			new Language{Alpha3="mak",	Alpha2="",		Name="Makasar"},
			new Language{Alpha3="mal",	Alpha2="ml",	Name="Malayalam"},
			new Language{Alpha3="man",	Alpha2="",		Name="Mandingo"},
			new Language{Alpha3="mri",	Alpha2="mi",	Name="Maori"},
			new Language{Alpha3="map",	Alpha2="",		Name="Austronesian languages"},
			new Language{Alpha3="mar",	Alpha2="mr",	Name="Marathi"},
			new Language{Alpha3="mas",	Alpha2="",		Name="Masai"},
			new Language{Alpha3="msa",	Alpha2="ms",	Name="Malay"},
			new Language{Alpha3="mdf",	Alpha2="",		Name="Moksha"},
			new Language{Alpha3="mdr",	Alpha2="",		Name="Mandar"},
			new Language{Alpha3="men",	Alpha2="",		Name="Mende"},
			new Language{Alpha3="mga",	Alpha2="",		Name="Irish, Middle (900-1200)"},
			new Language{Alpha3="mic",	Alpha2="",		Name="Mi'kmaq; Micmac"},
			new Language{Alpha3="min",	Alpha2="",		Name="Minangkabau"},
			new Language{Alpha3="mis",	Alpha2="",		Name="Uncoded languages"},
			new Language{Alpha3="mkd",	Alpha2="mk",	Name="Macedonian"},
			new Language{Alpha3="mkh",	Alpha2="",		Name="Mon-Khmer languages"},
			new Language{Alpha3="mlg",	Alpha2="mg",	Name="Malagasy"},
			new Language{Alpha3="mlt",	Alpha2="mt",	Name="Maltese"},
			new Language{Alpha3="mnc",	Alpha2="",		Name="Manchu"},
			new Language{Alpha3="mni",	Alpha2="",		Name="Manipuri"},
			new Language{Alpha3="mno",	Alpha2="",		Name="Manobo languages"},
			new Language{Alpha3="moh",	Alpha2="",		Name="Mohawk"},
			new Language{Alpha3="mon",	Alpha2="mn",	Name="Mongolian"},
			new Language{Alpha3="mos",	Alpha2="",		Name="Mossi"},
			new Language{Alpha3="mri",	Alpha2="mi",	Name="Maori"},
			new Language{Alpha3="msa",	Alpha2="ms",	Name="Malay"},
			new Language{Alpha3="mul",	Alpha2="",		Name="Multiple languages"},
			new Language{Alpha3="mun",	Alpha2="",		Name="Munda languages"},
			new Language{Alpha3="mus",	Alpha2="",		Name="Creek"},
			new Language{Alpha3="mwl",	Alpha2="",		Name="Mirandese"},
			new Language{Alpha3="mwr",	Alpha2="",		Name="Marwari"},
			new Language{Alpha3="mya",	Alpha2="my",	Name="Burmese"},
			new Language{Alpha3="myn",	Alpha2="",		Name="Mayan languages"},
			new Language{Alpha3="myv",	Alpha2="",		Name="Erzya"},
			new Language{Alpha3="nah",	Alpha2="",		Name="Nahuatl languages"},
			new Language{Alpha3="nai",	Alpha2="",		Name="North American Indian languages"},
			new Language{Alpha3="nap",	Alpha2="",		Name="Neapolitan"},
			new Language{Alpha3="nau",	Alpha2="na",	Name="Nauru"},
			new Language{Alpha3="nav",	Alpha2="nv",	Name="Navajo; Navaho"},
			new Language{Alpha3="nbl",	Alpha2="nr",	Name="Ndebele, South; South Ndebele"},
			new Language{Alpha3="nde",	Alpha2="nd",	Name="Ndebele, North; North Ndebele"},
			new Language{Alpha3="ndo",	Alpha2="ng",	Name="Ndonga"},
			new Language{Alpha3="nds",	Alpha2="",		Name="Low German; Low Saxon; German, Low; Saxon, Low"},
			new Language{Alpha3="nep",	Alpha2="ne",	Name="Nepali"},
			new Language{Alpha3="new",	Alpha2="",		Name="Nepal Bhasa; Newari"},
			new Language{Alpha3="nia",	Alpha2="",		Name="Nias"},
			new Language{Alpha3="nic",	Alpha2="",		Name="Niger-Kordofanian languages"},
			new Language{Alpha3="niu",	Alpha2="",		Name="Niuean"},
			new Language{Alpha3="nld",	Alpha2="nl",	Name="Dutch; Flemish"},
			new Language{Alpha3="nno",	Alpha2="nn",	Name="Norwegian Nynorsk; Nynorsk, Norwegian"},
			new Language{Alpha3="nob",	Alpha2="nb",	Name="Bokmål, Norwegian; Norwegian Bokmål"},
			new Language{Alpha3="nog",	Alpha2="",		Name="Nogai"},
			new Language{Alpha3="non",	Alpha2="",		Name="Norse, Old"},
			new Language{Alpha3="nor",	Alpha2="no",	Name="Norwegian"},
			new Language{Alpha3="nqo",	Alpha2="",		Name="N'Ko"},
			new Language{Alpha3="nso",	Alpha2="",		Name="Pedi; Sepedi; Northern Sotho"},
			new Language{Alpha3="nub",	Alpha2="",		Name="Nubian languages"},
			new Language{Alpha3="nwc",	Alpha2="",		Name="Classical Newari; Old Newari; Classical Nepal Bhasa"},
			new Language{Alpha3="nya",	Alpha2="ny",	Name="Chichewa; Chewa; Nyanja"},
			new Language{Alpha3="nym",	Alpha2="",		Name="Nyamwezi"},
			new Language{Alpha3="nyn",	Alpha2="",		Name="Nyankole"},
			new Language{Alpha3="nyo",	Alpha2="",		Name="Nyoro"},
			new Language{Alpha3="nzi",	Alpha2="",		Name="Nzima"},
			new Language{Alpha3="oci",	Alpha2="oc",	Name="Occitan (post 1500)"},
			new Language{Alpha3="oji",	Alpha2="oj",	Name="Ojibwa"},
			new Language{Alpha3="ori",	Alpha2="or",	Name="Oriya"},
			new Language{Alpha3="orm",	Alpha2="om",	Name="Oromo"},
			new Language{Alpha3="osa",	Alpha2="",		Name="Osage"},
			new Language{Alpha3="oss",	Alpha2="os",	Name="Ossetian; Ossetic"},
			new Language{Alpha3="ota",	Alpha2="",		Name="Turkish, Ottoman (1500-1928)"},
			new Language{Alpha3="oto",	Alpha2="",		Name="Otomian languages"},
			new Language{Alpha3="paa",	Alpha2="",		Name="Papuan languages"},
			new Language{Alpha3="pag",	Alpha2="",		Name="Pangasinan"},
			new Language{Alpha3="pal",	Alpha2="",		Name="Pahlavi"},
			new Language{Alpha3="pam",	Alpha2="",		Name="Pampanga; Kapampangan"},
			new Language{Alpha3="pan",	Alpha2="pa",	Name="Panjabi; Punjabi"},
			new Language{Alpha3="pap",	Alpha2="",		Name="Papiamento"},
			new Language{Alpha3="pau",	Alpha2="",		Name="Palauan"},
			new Language{Alpha3="peo",	Alpha2="",		Name="Persian, Old (ca.600-400 B.C.)"},
			new Language{Alpha3="fas",	Alpha2="fa",	Name="Persian"},
			new Language{Alpha3="phi",	Alpha2="",		Name="Philippine languages"},
			new Language{Alpha3="phn",	Alpha2="",		Name="Phoenician"},
			new Language{Alpha3="pli",	Alpha2="pi",	Name="Pali"},
			new Language{Alpha3="pon",	Alpha2="",		Name="Pohnpeian"},
			new Language{Alpha3="pra",	Alpha2="",		Name="Prakrit languages"},
			new Language{Alpha3="pro",	Alpha2="",		Name="Provençal, Old (to 1500,Occitan, Old (to 1500)"},
			new Language{Alpha3="pus",	Alpha2="ps",	Name="Pushto; Pashto"},
			new Language{Alpha3="qaa",	Alpha2="",		Name="Reserved for local use"},
			new Language{Alpha3="que",	Alpha2="qu",	Name="Quechua"},
			new Language{Alpha3="raj",	Alpha2="",		Name="Rajasthani"},
			new Language{Alpha3="rap",	Alpha2="",		Name="Rapanui"},
			new Language{Alpha3="rar",	Alpha2="",		Name="Rarotongan; Cook Islands Maori"},
			new Language{Alpha3="roa",	Alpha2="",		Name="Romance languages"},
			new Language{Alpha3="roh",	Alpha2="rm",	Name="Romansh"},
			new Language{Alpha3="rom",	Alpha2="",		Name="Romany"},
			new Language{Alpha3="ron",	Alpha2="ro",	Name="Romanian; Moldavian; Moldovan"},
			new Language{Alpha3="run",	Alpha2="rn",	Name="Rundi"},
			new Language{Alpha3="rup",	Alpha2="",		Name="Aromanian; Arumanian; Macedo-Romanian"},
			new Language{Alpha3="sad",	Alpha2="",		Name="Sandawe"},
			new Language{Alpha3="sag",	Alpha2="sg",	Name="Sango"},
			new Language{Alpha3="sah",	Alpha2="",		Name="Yakut"},
			new Language{Alpha3="sai",	Alpha2="",		Name="South American Indian languages"},
			new Language{Alpha3="sal",	Alpha2="",		Name="Salishan languages"},
			new Language{Alpha3="sam",	Alpha2="",		Name="Samaritan Aramaic"},
			new Language{Alpha3="san",	Alpha2="sa",	Name="Sanskrit"},
			new Language{Alpha3="sas",	Alpha2="",		Name="Sasak"},
			new Language{Alpha3="sat",	Alpha2="",		Name="Santali"},
			new Language{Alpha3="scn",	Alpha2="",		Name="Sicilian"},
			new Language{Alpha3="sco",	Alpha2="",		Name="Scots"},
			new Language{Alpha3="sel",	Alpha2="",		Name="Selkup"},
			new Language{Alpha3="sem",	Alpha2="",		Name="Semitic languages"},
			new Language{Alpha3="sga",	Alpha2="",		Name="Irish, Old (to 900)"},
			new Language{Alpha3="sgn",	Alpha2="",		Name="Sign Languages"},
			new Language{Alpha3="shn",	Alpha2="",		Name="Shan"},
			new Language{Alpha3="sid",	Alpha2="",		Name="Sidamo"},
			new Language{Alpha3="sin",	Alpha2="si",	Name="Sinhala; Sinhalese"},
			new Language{Alpha3="sio",	Alpha2="",		Name="Siouan languages"},
			new Language{Alpha3="sit",	Alpha2="",		Name="Sino-Tibetan languages"},
			new Language{Alpha3="sla",	Alpha2="",		Name="Slavic languages"},
			new Language{Alpha3="slk",	Alpha2="sk",	Name="Slovak"},
			new Language{Alpha3="slv",	Alpha2="sl",	Name="Slovenian"},
			new Language{Alpha3="sma",	Alpha2="",		Name="Southern Sami"},
			new Language{Alpha3="sme",	Alpha2="se",	Name="Northern Sami"},
			new Language{Alpha3="smi",	Alpha2="",		Name="Sami languages"},
			new Language{Alpha3="smj",	Alpha2="",		Name="Lule Sami"},
			new Language{Alpha3="smn",	Alpha2="",		Name="Inari Sami"},
			new Language{Alpha3="smo",	Alpha2="sm",	Name="Samoan"},
			new Language{Alpha3="sms",	Alpha2="",		Name="Skolt Sami"},
			new Language{Alpha3="sna",	Alpha2="sn",	Name="Shona"},
			new Language{Alpha3="snd",	Alpha2="sd",	Name="Sindhi"},
			new Language{Alpha3="snk",	Alpha2="",		Name="Soninke"},
			new Language{Alpha3="sog",	Alpha2="",		Name="Sogdian"},
			new Language{Alpha3="som",	Alpha2="so",	Name="Somali"},
			new Language{Alpha3="son",	Alpha2="",		Name="Songhai languages"},
			new Language{Alpha3="sot",	Alpha2="st",	Name="Sotho, Southern"},
			new Language{Alpha3="sqi",	Alpha2="sq",	Name="Albanian"},
			new Language{Alpha3="srd",	Alpha2="sc",	Name="Sardinian"},
			new Language{Alpha3="srn",	Alpha2="",		Name="Sranan Tongo"},
			new Language{Alpha3="srp",	Alpha2="sr",	Name="Serbian"},
			new Language{Alpha3="srr",	Alpha2="",		Name="Serer"},
			new Language{Alpha3="ssa",	Alpha2="",		Name="Nilo-Saharan languages"},
			new Language{Alpha3="ssw",	Alpha2="ss",	Name="Swati"},
			new Language{Alpha3="suk",	Alpha2="",		Name="Sukuma"},
			new Language{Alpha3="sun",	Alpha2="su",	Name="Sundanese"},
			new Language{Alpha3="sus",	Alpha2="",		Name="Susu"},
			new Language{Alpha3="sux",	Alpha2="",		Name="Sumerian"},
			new Language{Alpha3="swa",	Alpha2="sw",	Name="Swahili"},
			new Language{Alpha3="swe",	Alpha2="sv",	Name="Swedish"},
			new Language{Alpha3="syc",	Alpha2="",		Name="Classical Syriac"},
			new Language{Alpha3="syr",	Alpha2="",		Name="Syriac"},
			new Language{Alpha3="tah",	Alpha2="ty",	Name="Tahitian"},
			new Language{Alpha3="tai",	Alpha2="",		Name="Tai languages"},
			new Language{Alpha3="tam",	Alpha2="ta",	Name="Tamil"},
			new Language{Alpha3="tat",	Alpha2="tt",	Name="Tatar"},
			new Language{Alpha3="tel",	Alpha2="te",	Name="Telugu"},
			new Language{Alpha3="tem",	Alpha2="",		Name="Timne"},
			new Language{Alpha3="ter",	Alpha2="",		Name="Tereno"},
			new Language{Alpha3="tet",	Alpha2="",		Name="Tetum"},
			new Language{Alpha3="tgk",	Alpha2="tg",	Name="Tajik"},
			new Language{Alpha3="tgl",	Alpha2="tl",	Name="Tagalog"},
			new Language{Alpha3="tha",	Alpha2="th",	Name="Thai"},
			new Language{Alpha3="bod",	Alpha2="bo",	Name="Tibetan"},
			new Language{Alpha3="tig",	Alpha2="",		Name="Tigre"},
			new Language{Alpha3="tir",	Alpha2="ti",	Name="Tigrinya"},
			new Language{Alpha3="tiv",	Alpha2="",		Name="Tiv"},
			new Language{Alpha3="tkl",	Alpha2="",		Name="Tokelau"},
			new Language{Alpha3="tlh",	Alpha2="",		Name="Klingon; tlhIngan-Hol"},
			new Language{Alpha3="tli",	Alpha2="",		Name="Tlingit"},
			new Language{Alpha3="tmh",	Alpha2="",		Name="Tamashek"},
			new Language{Alpha3="tog",	Alpha2="",		Name="Tonga (Nyasa)"},
			new Language{Alpha3="ton",	Alpha2="to",	Name="Tonga (Tonga Islands)"},
			new Language{Alpha3="tpi",	Alpha2="",		Name="Tok Pisin"},
			new Language{Alpha3="tsi",	Alpha2="",		Name="Tsimshian"},
			new Language{Alpha3="tsn",	Alpha2="tn",	Name="Tswana"},
			new Language{Alpha3="tso",	Alpha2="ts",	Name="Tsonga"},
			new Language{Alpha3="tuk",	Alpha2="tk",	Name="Turkmen"},
			new Language{Alpha3="tum",	Alpha2="",		Name="Tumbuka"},
			new Language{Alpha3="tup",	Alpha2="",		Name="Tupi languages"},
			new Language{Alpha3="tut",	Alpha2="",		Name="Altaic languages"},
			new Language{Alpha3="tvl",	Alpha2="",		Name="Tuvalu"},
			new Language{Alpha3="twi",	Alpha2="tw",	Name="Twi"},
			new Language{Alpha3="tyv",	Alpha2="",		Name="Tuvinian"},
			new Language{Alpha3="udm",	Alpha2="",		Name="Udmurt"},
			new Language{Alpha3="uga",	Alpha2="",		Name="Ugaritic"},
			new Language{Alpha3="uig",	Alpha2="ug",	Name="Uighur; Uyghur"},
			new Language{Alpha3="umb",	Alpha2="",		Name="Umbundu"},
			new Language{Alpha3="und",	Alpha2="",		Name="Undetermined"},
			new Language{Alpha3="uzb",	Alpha2="uz",	Name="Uzbek"},
			new Language{Alpha3="vai",	Alpha2="",		Name="Vai"},
			new Language{Alpha3="ven",	Alpha2="ve",	Name="Venda"},
			new Language{Alpha3="vie",	Alpha2="vi",	Name="Vietnamese"},
			new Language{Alpha3="vol",	Alpha2="vo",	Name="Volapük"},
			new Language{Alpha3="vot",	Alpha2="",		Name="Votic"},
			new Language{Alpha3="wak",	Alpha2="",		Name="Wakashan languages"},
			new Language{Alpha3="wal",	Alpha2="",		Name="Wolaitta; Wolaytta"},
			new Language{Alpha3="war",	Alpha2="",		Name="Waray"},
			new Language{Alpha3="was",	Alpha2="",		Name="Washo"},
			new Language{Alpha3="cym",	Alpha2="cy",	Name="Welsh"},
			new Language{Alpha3="wen",	Alpha2="",		Name="Sorbian languages"},
			new Language{Alpha3="wln",	Alpha2="wa",	Name="Walloon"},
			new Language{Alpha3="wol",	Alpha2="wo",	Name="Wolof"},
			new Language{Alpha3="xal",	Alpha2="",		Name="Kalmyk; Oirat"},
			new Language{Alpha3="xho",	Alpha2="xh",	Name="Xhosa"},
			new Language{Alpha3="yao",	Alpha2="",		Name="Yao"},
			new Language{Alpha3="yap",	Alpha2="",		Name="Yapese"},
			new Language{Alpha3="yid",	Alpha2="yi",	Name="Yiddish"},
			new Language{Alpha3="yor",	Alpha2="yo",	Name="Yoruba"},
			new Language{Alpha3="ypk",	Alpha2="",		Name="Yupik languages"},
			new Language{Alpha3="zap",	Alpha2="",		Name="Zapotec"},
			new Language{Alpha3="zbl",	Alpha2="",		Name="Blissymbols; Blissymbolics; Bliss"},
			new Language{Alpha3="zen",	Alpha2="",		Name="Zenaga"},
			new Language{Alpha3="zha",	Alpha2="za",	Name="Zhuang; Chuang"},
			new Language{Alpha3="zho",	Alpha2="zh",	Name="Chinese"},
			new Language{Alpha3="znd",	Alpha2="",		Name="Zande languages"},
			new Language{Alpha3="zul",	Alpha2="zu",	Name="Zulu"},
			new Language{Alpha3="zun",	Alpha2="",		Name="Zuni"},
			new Language{Alpha3="#zx",	Alpha2="",		Name="No linguistic content; Not applicable"},
			new Language{Alpha3="#zz",	Alpha2="",		Name="Zaza; Dimili; Dimli; Kirdki; Kirmanjki; Zazaki"}
		};

		/// <summary>
		/// List (incomplete) of languages using Arabic graphic.
		/// </summary>
		public readonly static string[] UsesArabicGraphic = ["ar", "fa", "ug", "ur"];
		#endregion

		#region Search
		/// <summary>
		/// Selects the language by the alpha code. First the alpha2 code is tried, 
		/// if it delivers no result, then the alpha3 code.
		/// </summary>
		/// <param name="alpha">The alpha.</param>
		/// <returns>Instance of Language, if found, otherwise null.</returns>
		public static Language ByCode(string alpha)
		{
			Language language	= Languages.FirstOrDefault(language => language.Alpha2 == alpha.ToLower());

			if (language != null)
			{
				return language;
			}

			return Languages.FirstOrDefault(language => language.Alpha3 == alpha.ToLower());
		}

		/// <summary>
		/// Find the language by its exact name.
		/// </summary>
		/// <param name="name">The name of the language to find by (case-insensitive).</param>
		/// <returns>The language foung, if successful, otherwise null.</returns>
		public static Language ByName(string name)
		{
			return Languages.FirstOrDefault(language => language.Name.ToLower() == name.ToLower());
		}

		/// <summary>
		/// Selects languages by a name token.
		/// </summary>
		/// <param name="nameToken">The name token to be contained in a language's name to include (case-insensitive).</param>
		/// <returns>Array of languages containing the name token.</returns>
		public static Language[] ByNameToken(string nameToken)
		{
			if(String.IsNullOrEmpty(nameToken))
			{
				return new Language[0];
			}

			return Languages.Where(language => language.Name.ToLower().Contains(nameToken.ToLower())).ToArray();
		}
		#endregion

		#region Codes
		/// <summary>
		/// Gets all language codes: Alpha2 for those languages where Alpha2 exists, otherwise Alpha3.
		/// </summary>
		public static string[] AllCodes
		{
			get
			{
				List<string> codes = new List<string>();

				foreach (Language language in Languages)
				{
					codes.Add(language.Alpha2.Length > 0 ? language.Alpha2 : language.Alpha3);
				}

				return codes.ToArray();
			}
		}
		#endregion
	}
}
