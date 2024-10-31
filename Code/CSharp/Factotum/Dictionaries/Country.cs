/**********************************************************************************************
* File:         Country.cs                                                                    *
* Contents:     Class Country                                                                 *
* Author:       Alex Konnen (info@pikkatech.eu)                                               *
* Date:         2014-05-31 09:56                                                              *
* Version:      1.0                                                                           *
* Copyright:    PikkaTech Development and Consulting (www.pikkatech.eu)                       *
**********************************************************************************************/
using System;
using System.IO;
using System.Linq;

namespace Factotum.Dictionaries
{
	/// <summary>
	///	Provides an abstraction of a country classification 
	///	according to ISO-3166 (http://en.wikipedia.org/wiki/ISO_3166),
	///	including alpha-2, alpha-3 and numerical representation.
	///	Stand: 2009
	/// </summary>
	public class Country
	{
		#region Properties
		/// <summary>
		/// Two-character representation of a country, e.g. "de" for Germany.
		/// </summary>
		public string				Alpha2	{get; set;}

		/// <summary>
		/// Three-character representation of a country, e.g. "deu" for Germany.
		/// </summary>
		public string				Alpha3	{get; set;}

		/// <summary>
		/// Index by ISO-3166, e.g. 276 for Germany.
		/// </summary>
		public int					Index	{get; set;}

		/// <summary>
		/// The country's representative name.
		/// </summary>
		public string				Name	{get; set;}

		public static	Country[]	Countries	= new Country[]
		{
			new Country{Alpha2="af",	Alpha3="afg",	Index=4,	Name="Afghanistan"},
			new Country{Alpha2="al",	Alpha3="alb",	Index=8,	Name="Albania"},
			new Country{Alpha2="dz",	Alpha3="dza",	Index=12,	Name="Algeria"},
			new Country{Alpha2="as",	Alpha3="asm",	Index=16,	Name="American Samoa"},
			new Country{Alpha2="ad",	Alpha3="and",	Index=20,	Name="Andorra"},
			new Country{Alpha2="ao",	Alpha3="ago",	Index=24,	Name="Angola"},
			new Country{Alpha2="ai",	Alpha3="aia",	Index=660,	Name="Anguilla"},
			new Country{Alpha2="aq",	Alpha3="ata",	Index=10,	Name="Antarctica"},
			new Country{Alpha2="ag",	Alpha3="atg",	Index=28,	Name="Antigua and Barbuda"},
			new Country{Alpha2="ar",	Alpha3="arg",	Index=32,	Name="Argentina"},
			new Country{Alpha2="am",	Alpha3="arm",	Index=51,	Name="Armenia"},
			new Country{Alpha2="aw",	Alpha3="abw",	Index=533,	Name="Aruba"},
			new Country{Alpha2="au",	Alpha3="aus",	Index=36,	Name="Australia"},
			new Country{Alpha2="at",	Alpha3="aut",	Index=40,	Name="Austria"},
			new Country{Alpha2="az",	Alpha3="aze",	Index=31,	Name="Azerbaijan"},
			new Country{Alpha2="bs",	Alpha3="bhs",	Index=44,	Name="Bahamas"},
			new Country{Alpha2="bh",	Alpha3="bhr",	Index=48,	Name="Bahrain"},
			new Country{Alpha2="bd",	Alpha3="bgd",	Index=50,	Name="Bangladesh"},
			new Country{Alpha2="bb",	Alpha3="brb",	Index=52,	Name="Barbados"},
			new Country{Alpha2="by",	Alpha3="blr",	Index=112,	Name="Belarus"},
			new Country{Alpha2="be",	Alpha3="bel",	Index=56,	Name="Belgium"},
			new Country{Alpha2="bz",	Alpha3="blz",	Index=84,	Name="Belize"},
			new Country{Alpha2="bj",	Alpha3="ben",	Index=204,	Name="Benin"},
			new Country{Alpha2="bm",	Alpha3="bmu",	Index=60,	Name="Bermuda"},
			new Country{Alpha2="bt",	Alpha3="btn",	Index=64,	Name="Bhutan"},
			new Country{Alpha2="bo",	Alpha3="bol",	Index=68,	Name="Bolivia"},
			new Country{Alpha2="ba",	Alpha3="bih",	Index=70,	Name="Bosnia and Herzegowina"},
			new Country{Alpha2="bw",	Alpha3="bwa",	Index=72,	Name="Botswana"},
			new Country{Alpha2="bv",	Alpha3="bvt",	Index=74,	Name="Bouvet Island"},
			new Country{Alpha2="br",	Alpha3="bra",	Index=76,	Name="Brazil"},
			new Country{Alpha2="io",	Alpha3="iot",	Index=86,	Name="British Indian Ocean Territory"},
			new Country{Alpha2="bn",	Alpha3="brn",	Index=96,	Name="Brunei Darussalam"},
			new Country{Alpha2="bg",	Alpha3="bgr",	Index=100,	Name="Bulgaria"},
			new Country{Alpha2="bf",	Alpha3="bfa",	Index=854,	Name="Burkina Faso"},
			new Country{Alpha2="bi",	Alpha3="bdi",	Index=108,	Name="Burundi"},
			new Country{Alpha2="kh",	Alpha3="khm",	Index=116,	Name="Cambodia"},
			new Country{Alpha2="cm",	Alpha3="cmr",	Index=120,	Name="Cameroon"},
			new Country{Alpha2="ca",	Alpha3="can",	Index=124,	Name="Canada"},
			new Country{Alpha2="cv",	Alpha3="cpv",	Index=132,	Name="Cape Verde"},
			new Country{Alpha2="ky",	Alpha3="cym",	Index=136,	Name="Cayman Islands"},
			new Country{Alpha2="cf",	Alpha3="caf",	Index=140,	Name="Central African Republic"},
			new Country{Alpha2="td",	Alpha3="tcd",	Index=148,	Name="Chad"},
			new Country{Alpha2="cl",	Alpha3="chl",	Index=152,	Name="Chile"},
			new Country{Alpha2="cn",	Alpha3="chn",	Index=156,	Name="China"},
			new Country{Alpha2="cx",	Alpha3="cxr",	Index=162,	Name="Christmas Island"},
			new Country{Alpha2="cc",	Alpha3="cck",	Index=166,	Name="Cocos (Keeling Islands"},
			new Country{Alpha2="co",	Alpha3="col",	Index=170,	Name="Colombia"},
			new Country{Alpha2="km",	Alpha3="com",	Index=174,	Name="Comoros"},
			new Country{Alpha2="cd",	Alpha3="cod",	Index=180,	Name="Congo, Democratic Republic of"},
			new Country{Alpha2="cg",	Alpha3="cog",	Index=178,	Name="Congo, People''s Republic of"},
			new Country{Alpha2="ck",	Alpha3="cok",	Index=184,	Name="Cook Islands"},
			new Country{Alpha2="cr",	Alpha3="cri",	Index=188,	Name="Costa Rica"},
			new Country{Alpha2="ci",	Alpha3="civ",	Index=384,	Name="Cote D''ivoire"},
			new Country{Alpha2="hr",	Alpha3="hrv",	Index=191,	Name="Croatia"},
			new Country{Alpha2="cu",	Alpha3="cub",	Index=192,	Name="Cuba"},
			new Country{Alpha2="cy",	Alpha3="cyp",	Index=196,	Name="Cyprus"},
			new Country{Alpha2="cz",	Alpha3="cze",	Index=203,	Name="Czech Republic"},
			new Country{Alpha2="dk",	Alpha3="dnk",	Index=208,	Name="Denmark"},
			new Country{Alpha2="dj",	Alpha3="dji",	Index=262,	Name="Djibouti"},
			new Country{Alpha2="dm",	Alpha3="dma",	Index=212,	Name="Dominica"},
			new Country{Alpha2="do",	Alpha3="dom",	Index=214,	Name="Dominican Republic"},
			new Country{Alpha2="tl",	Alpha3="tls",	Index=626,	Name="East Timor"},
			new Country{Alpha2="ec",	Alpha3="ecu",	Index=218,	Name="Ecuador"},
			new Country{Alpha2="eg",	Alpha3="egy",	Index=818,	Name="Egypt"},
			new Country{Alpha2="sv",	Alpha3="slv",	Index=222,	Name="El Salvador"},
			new Country{Alpha2="gq",	Alpha3="gnq",	Index=226,	Name="Equatorial Guinea"},
			new Country{Alpha2="er",	Alpha3="eri",	Index=232,	Name="Eritrea"},
			new Country{Alpha2="ee",	Alpha3="est",	Index=233,	Name="Estonia"},
			new Country{Alpha2="et",	Alpha3="eth",	Index=231,	Name="Ethiopia"},
			new Country{Alpha2="fk",	Alpha3="flk",	Index=238,	Name="Falkland Islands (Malvinas)"},
			new Country{Alpha2="fo",	Alpha3="fro",	Index=234,	Name="Faroe Islands"},
			new Country{Alpha2="fj",	Alpha3="fji",	Index=242,	Name="Fiji"},
			new Country{Alpha2="fi",	Alpha3="fin",	Index=246,	Name="Finland"},
			new Country{Alpha2="fr",	Alpha3="fra",	Index=250,	Name="France"},
			new Country{Alpha2="fx",	Alpha3="fxx",	Index=249,	Name="France, Metropolitan"},
			new Country{Alpha2="gf",	Alpha3="guf",	Index=254,	Name="French Guiana"},
			new Country{Alpha2="pf",	Alpha3="pyf",	Index=258,	Name="French Polynesia"},
			new Country{Alpha2="tf",	Alpha3="atf",	Index=260,	Name="French Southern Territories"},
			new Country{Alpha2="ga",	Alpha3="gab",	Index=266,	Name="Gabon"},
			new Country{Alpha2="gm",	Alpha3="gmb",	Index=270,	Name="Gambia"},
			new Country{Alpha2="ge",	Alpha3="geo",	Index=268,	Name="Georgia"},
			new Country{Alpha2="de",	Alpha3="deu",	Index=276,	Name="Germany"},
			new Country{Alpha2="gh",	Alpha3="gha",	Index=288,	Name="Ghana"},
			new Country{Alpha2="gi",	Alpha3="gib",	Index=292,	Name="Gibraltar"},
			new Country{Alpha2="gr",	Alpha3="grc",	Index=300,	Name="Greece"},
			new Country{Alpha2="gl",	Alpha3="grl",	Index=304,	Name="Greenland"},
			new Country{Alpha2="gd",	Alpha3="grd",	Index=308,	Name="Grenada"},
			new Country{Alpha2="gp",	Alpha3="glp",	Index=312,	Name="Guadeloupe"},
			new Country{Alpha2="gu",	Alpha3="gum",	Index=316,	Name="Guam"},
			new Country{Alpha2="gt",	Alpha3="gtm",	Index=320,	Name="Guatemala"},
			new Country{Alpha2="gn",	Alpha3="gin",	Index=324,	Name="Guinea"},
			new Country{Alpha2="gw",	Alpha3="gnb",	Index=624,	Name="Guinea-bissau"},
			new Country{Alpha2="gy",	Alpha3="guy",	Index=328,	Name="Guyana"},
			new Country{Alpha2="ht",	Alpha3="hti",	Index=332,	Name="Haiti"},
			new Country{Alpha2="hm",	Alpha3="hmd",	Index=334,	Name="Heard and Mc Donald Islands"},
			new Country{Alpha2="hn",	Alpha3="hnd",	Index=340,	Name="Honduras"},
			new Country{Alpha2="hk",	Alpha3="hkg",	Index=344,	Name="Hong Kong"},
			new Country{Alpha2="hu",	Alpha3="hun",	Index=348,	Name="Hungary"},
			new Country{Alpha2="is",	Alpha3="isl",	Index=352,	Name="Iceland"},
			new Country{Alpha2="in",	Alpha3="ind",	Index=356,	Name="India"},
			new Country{Alpha2="id",	Alpha3="idn",	Index=360,	Name="Indonesia"},
			new Country{Alpha2="ir",	Alpha3="irn",	Index=364,	Name="Iran (Islamic Republic Of"},
			new Country{Alpha2="iq",	Alpha3="irq",	Index=368,	Name="Iraq"},
			new Country{Alpha2="ie",	Alpha3="irl",	Index=372,	Name="Ireland"},
			new Country{Alpha2="il",	Alpha3="isr",	Index=376,	Name="Israel"},
			new Country{Alpha2="it",	Alpha3="ita",	Index=380,	Name="Italy"},
			new Country{Alpha2="jm",	Alpha3="jam",	Index=388,	Name="Jamaica"},
			new Country{Alpha2="jp",	Alpha3="jpn",	Index=392,	Name="Japan"},
			new Country{Alpha2="jo",	Alpha3="jor",	Index=400,	Name="Jordan"},
			new Country{Alpha2="kz",	Alpha3="kaz",	Index=398,	Name="Kazakhstan"},
			new Country{Alpha2="ke",	Alpha3="ken",	Index=404,	Name="Kenya"},
			new Country{Alpha2="ki",	Alpha3="kir",	Index=296,	Name="Kiribati"},
			new Country{Alpha2="kp",	Alpha3="prk",	Index=408,	Name="Korea, Democratic People''s Republic"},
			new Country{Alpha2="kr",	Alpha3="kor",	Index=410,	Name="Korea, Republic of"},
			new Country{Alpha2="kw",	Alpha3="kwt",	Index=414,	Name="Kuwait"},
			new Country{Alpha2="kg",	Alpha3="kgz",	Index=417,	Name="Kyrgyzstan"},
			new Country{Alpha2="la",	Alpha3="lao",	Index=418,	Name="Lao People''s Democratic Republic"},
			new Country{Alpha2="lv",	Alpha3="lva",	Index=428,	Name="Latvia"},
			new Country{Alpha2="lb",	Alpha3="lbn",	Index=422,	Name="Lebanon"},
			new Country{Alpha2="ls",	Alpha3="lso",	Index=426,	Name="Lesotho"},
			new Country{Alpha2="lr",	Alpha3="lbr",	Index=430,	Name="Liberia"},
			new Country{Alpha2="ly",	Alpha3="lby",	Index=434,	Name="Libyan Arab Jamahiriya"},
			new Country{Alpha2="li",	Alpha3="lie",	Index=438,	Name="Liechtenstein"},
			new Country{Alpha2="lt",	Alpha3="ltu",	Index=440,	Name="Lithuania"},
			new Country{Alpha2="lu",	Alpha3="lux",	Index=442,	Name="Luxembourg"},
			new Country{Alpha2="mo",	Alpha3="mac",	Index=446,	Name="Macau"},
			new Country{Alpha2="mk",	Alpha3="mkd",	Index=807,	Name="Macedonia"},
			new Country{Alpha2="mg",	Alpha3="mdg",	Index=450,	Name="Madagascar"},
			new Country{Alpha2="mw",	Alpha3="mwi",	Index=454,	Name="Malawi"},
			new Country{Alpha2="my",	Alpha3="mys",	Index=458,	Name="Malaysia"},
			new Country{Alpha2="mv",	Alpha3="mdv",	Index=462,	Name="Maldives"},
			new Country{Alpha2="ml",	Alpha3="mli",	Index=466,	Name="Mali"},
			new Country{Alpha2="mt",	Alpha3="mlt",	Index=470,	Name="Malta"},
			new Country{Alpha2="mh",	Alpha3="mhl",	Index=584,	Name="Marshall Islands"},
			new Country{Alpha2="mq",	Alpha3="mtq",	Index=474,	Name="Martinique"},
			new Country{Alpha2="mr",	Alpha3="mrt",	Index=478,	Name="Mauritania"},
			new Country{Alpha2="mu",	Alpha3="mus",	Index=480,	Name="Mauritius"},
			new Country{Alpha2="yt",	Alpha3="myt",	Index=175,	Name="Mayotte"},
			new Country{Alpha2="mx",	Alpha3="mex",	Index=484,	Name="Mexico"},
			new Country{Alpha2="fm",	Alpha3="fsm",	Index=583,	Name="Micronesia, Federated States of"},
			new Country{Alpha2="md",	Alpha3="mda",	Index=498,	Name="Moldova, Republic of"},
			new Country{Alpha2="mc",	Alpha3="mco",	Index=492,	Name="Monaco"},
			new Country{Alpha2="mn",	Alpha3="mng",	Index=496,	Name="Mongolia"},
			new Country{Alpha2="ms",	Alpha3="msr",	Index=500,	Name="Montserrat"},
			new Country{Alpha2="ma",	Alpha3="mar",	Index=504,	Name="Morocco"},
			new Country{Alpha2="mz",	Alpha3="moz",	Index=508,	Name="Mozambique"},
			new Country{Alpha2="mm",	Alpha3="mmr",	Index=104,	Name="Myanmar"},
			new Country{Alpha2="na",	Alpha3="nam",	Index=516,	Name="Namibia"},
			new Country{Alpha2="nr",	Alpha3="nru",	Index=520,	Name="Nauru"},
			new Country{Alpha2="np",	Alpha3="npl",	Index=524,	Name="Nepal"},
			new Country{Alpha2="nl",	Alpha3="nld",	Index=528,	Name="Netherlands"},
			new Country{Alpha2="an",	Alpha3="ant",	Index=530,	Name="Netherlands Antilles"},
			new Country{Alpha2="nc",	Alpha3="ncl",	Index=540,	Name="New Caledonia"},
			new Country{Alpha2="nz",	Alpha3="nzl",	Index=554,	Name="New Zealand"},
			new Country{Alpha2="ni",	Alpha3="nic",	Index=558,	Name="Nicaragua"},
			new Country{Alpha2="ne",	Alpha3="ner",	Index=562,	Name="Niger"},
			new Country{Alpha2="ng",	Alpha3="nga",	Index=566,	Name="Nigeria"},
			new Country{Alpha2="nu",	Alpha3="niu",	Index=570,	Name="Niue"},
			new Country{Alpha2="nf",	Alpha3="nfk",	Index=574,	Name="Norfolk Island"},
			new Country{Alpha2="mp",	Alpha3="mnp",	Index=580,	Name="Northern Mariana Islands"},
			new Country{Alpha2="no",	Alpha3="nor",	Index=578,	Name="Norway"},
			new Country{Alpha2="om",	Alpha3="omn",	Index=512,	Name="Oman"},
			new Country{Alpha2="pk",	Alpha3="pak",	Index=586,	Name="Pakistan"},
			new Country{Alpha2="pw",	Alpha3="plw",	Index=585,	Name="Palau"},
			new Country{Alpha2="ps",	Alpha3="pse",	Index=275,	Name="Palestinian Territory"},
			new Country{Alpha2="pa",	Alpha3="pan",	Index=591,	Name="Panama"},
			new Country{Alpha2="pg",	Alpha3="png",	Index=598,	Name="Papua New Guinea"},
			new Country{Alpha2="py",	Alpha3="pry",	Index=600,	Name="Paraguay"},
			new Country{Alpha2="pe",	Alpha3="per",	Index=604,	Name="Peru"},
			new Country{Alpha2="ph",	Alpha3="phl",	Index=608,	Name="Philippines"},
			new Country{Alpha2="pn",	Alpha3="pcn",	Index=612,	Name="Pitcairn"},
			new Country{Alpha2="pl",	Alpha3="pol",	Index=616,	Name="Poland"},
			new Country{Alpha2="pt",	Alpha3="prt",	Index=620,	Name="Portugal"},
			new Country{Alpha2="pr",	Alpha3="pri",	Index=630,	Name="Puerto Rico"},
			new Country{Alpha2="qa",	Alpha3="qat",	Index=634,	Name="Qatar"},
			new Country{Alpha2="re",	Alpha3="reu",	Index=638,	Name="Reunion"},
			new Country{Alpha2="ro",	Alpha3="rou",	Index=642,	Name="Romania"},
			new Country{Alpha2="ru",	Alpha3="rus",	Index=643,	Name="Russian Federation"},
			new Country{Alpha2="rw",	Alpha3="rwa",	Index=646,	Name="Rwanda"},
			new Country{Alpha2="kn",	Alpha3="kna",	Index=659,	Name="Saint Kitts and Nevis"},
			new Country{Alpha2="lc",	Alpha3="lca",	Index=662,	Name="Saint Lucia"},
			new Country{Alpha2="vc",	Alpha3="vct",	Index=670,	Name="Saint Vincent and the Grenadines"},
			new Country{Alpha2="ws",	Alpha3="wsm",	Index=882,	Name="Samoa"},
			new Country{Alpha2="sm",	Alpha3="smr",	Index=674,	Name="San Marino"},
			new Country{Alpha2="st",	Alpha3="stp",	Index=678,	Name="Sao Tome and Principe"},
			new Country{Alpha2="sa",	Alpha3="sau",	Index=682,	Name="Saudi Arabia"},
			new Country{Alpha2="sn",	Alpha3="sen",	Index=686,	Name="Senegal"},
			new Country{Alpha2="sc",	Alpha3="syc",	Index=690,	Name="Seychelles"},
			new Country{Alpha2="sl",	Alpha3="sle",	Index=694,	Name="Sierra Leone"},
			new Country{Alpha2="sg",	Alpha3="sgp",	Index=702,	Name="Singapore"},
			new Country{Alpha2="sk",	Alpha3="svk",	Index=703,	Name="Slovakia"},
			new Country{Alpha2="si",	Alpha3="svn",	Index=705,	Name="Slovenia"},
			new Country{Alpha2="sb",	Alpha3="slb",	Index=90,	Name="Solomon Islands"},
			new Country{Alpha2="so",	Alpha3="som",	Index=706,	Name="Somalia"},
			new Country{Alpha2="za",	Alpha3="zaf",	Index=710,	Name="South Africa"},
			new Country{Alpha2="gs",	Alpha3="sgs",	Index=239,	Name="South Georgia and the South Sandwich Islands"},
			new Country{Alpha2="es",	Alpha3="esp",	Index=724,	Name="Spain"},
			new Country{Alpha2="lk",	Alpha3="lka",	Index=144,	Name="Sri Lanka"},
			new Country{Alpha2="sh",	Alpha3="shn",	Index=654,	Name="St. Helena"},
			new Country{Alpha2="pm",	Alpha3="spm",	Index=666,	Name="St. Pierre and Miquelon"},
			new Country{Alpha2="sd",	Alpha3="sdn",	Index=736,	Name="Sudan"},
			new Country{Alpha2="sr",	Alpha3="sur",	Index=740,	Name="Suriname"},
			new Country{Alpha2="sj",	Alpha3="sjm",	Index=744,	Name="Svalbard and Jan Mayen Islands"},
			new Country{Alpha2="sz",	Alpha3="swz",	Index=748,	Name="Swaziland"},
			new Country{Alpha2="se",	Alpha3="swe",	Index=752,	Name="Sweden"},
			new Country{Alpha2="ch",	Alpha3="che",	Index=756,	Name="Switzerland"},
			new Country{Alpha2="sy",	Alpha3="syr",	Index=760,	Name="Syrian Arab Republic"},
			new Country{Alpha2="tw",	Alpha3="twn",	Index=158,	Name="Taiwan"},
			new Country{Alpha2="tj",	Alpha3="tjk",	Index=762,	Name="Tajikistan"},
			new Country{Alpha2="tz",	Alpha3="tza",	Index=834,	Name="Tanzania, United Republic of"},
			new Country{Alpha2="th",	Alpha3="tha",	Index=764,	Name="Thailand"},
			new Country{Alpha2="tg",	Alpha3="tgo",	Index=768,	Name="Togo"},
			new Country{Alpha2="tk",	Alpha3="tkl",	Index=772,	Name="Tokelau"},
			new Country{Alpha2="to",	Alpha3="ton",	Index=776,	Name="Tonga"},
			new Country{Alpha2="tt",	Alpha3="tto",	Index=780,	Name="Trinidad and Tobago"},
			new Country{Alpha2="tn",	Alpha3="tun",	Index=788,	Name="Tunisia"},
			new Country{Alpha2="tr",	Alpha3="tur",	Index=792,	Name="Turkey"},
			new Country{Alpha2="tm",	Alpha3="tkm",	Index=795,	Name="Turkmenistan"},
			new Country{Alpha2="tc",	Alpha3="tca",	Index=796,	Name="Turks and Caicos Islands"},
			new Country{Alpha2="tv",	Alpha3="tuv",	Index=798,	Name="Tuvalu"},
			new Country{Alpha2="ug",	Alpha3="uga",	Index=800,	Name="Uganda"},
			new Country{Alpha2="ua",	Alpha3="ukr",	Index=804,	Name="Ukraine"},
			new Country{Alpha2="ae",	Alpha3="are",	Index=784,	Name="United Arab Emirates"},
			new Country{Alpha2="gb",	Alpha3="gbr",	Index=826,	Name="United Kingdom"},
			new Country{Alpha2="us",	Alpha3="usa",	Index=840,	Name="United States"},
			new Country{Alpha2="um",	Alpha3="umi",	Index=581,	Name="United States Minor Outlying Islands"},
			new Country{Alpha2="uy",	Alpha3="ury",	Index=858,	Name="Uruguay"},
			new Country{Alpha2="uz",	Alpha3="uzb",	Index=860,	Name="Uzbekistan"},
			new Country{Alpha2="vu",	Alpha3="vut",	Index=548,	Name="Vanuatu"},
			new Country{Alpha2="va",	Alpha3="vat",	Index=336,	Name="Vatican City State"},
			new Country{Alpha2="ve",	Alpha3="ven",	Index=862,	Name="Venezuela"},
			new Country{Alpha2="vn",	Alpha3="vnm",	Index=704,	Name="Viet Nam"},
			new Country{Alpha2="vg",	Alpha3="vgb",	Index=92,	Name="Virgin Islands (British"},
			new Country{Alpha2="vi",	Alpha3="vir",	Index=850,	Name="Virgin Islands (U.S."},
			new Country{Alpha2="wf",	Alpha3="wlf",	Index=876,	Name="Wallis and Futuna Islands"},
			new Country{Alpha2="eh",	Alpha3="esh",	Index=732,	Name="Western Sahara"},
			new Country{Alpha2="ye",	Alpha3="yem",	Index=887,	Name="Yemen"},
			new Country{Alpha2="yu",	Alpha3="yug",	Index=891,	Name="Yugoslavia"},
			new Country{Alpha2="zm",	Alpha3="zmb",	Index=894,	Name="Zambia"},
			new Country{Alpha2="zw",	Alpha3="zwe",	Index=716,	Name="Zimbabwe"},
			new Country{Alpha2="ax",	Alpha3="ala",	Index=248,	Name="Åland"},
			new Country{Alpha2="bl",	Alpha3="blm",	Index=652,	Name="Saint Barthélemy"},
			new Country{Alpha2="bq",	Alpha3="bes",	Index=535,	Name="Bonaire"},
			new Country{Alpha2="cw",	Alpha3="cuw",	Index=531,	Name="Curacao"},
			new Country{Alpha2="gg",	Alpha3="ggy",	Index=831,	Name="Guernsey"},
			new Country{Alpha2="im",	Alpha3="imn",	Index=833,	Name="Isle of Man"},
			new Country{Alpha2="je",	Alpha3="jey",	Index=832,	Name="Jersey"},
			new Country{Alpha2="me",	Alpha3="mne",	Index=499,	Name="Montenegro"},
			new Country{Alpha2="mf",	Alpha3="maf",	Index=663,	Name="Saint Martin"},
			new Country{Alpha2="rs",	Alpha3="srb",	Index=668,	Name="Serbia"},
			new Country{Alpha2="ss",	Alpha3="ssd",	Index=728,	Name="South Sudan"},
			new Country{Alpha2="sx",	Alpha3="sxm",	Index=534,	Name="Sint Maarten"},
			new Country{Alpha2="xk",	Alpha3="xkx",	Index=000,	Name="Kosovo"},
		};
		#endregion

		/// <summary>
		/// Selects the country by the alpha code. First the alpha2 code is tried, if it delivers no result, then the alpha3 code.
		/// </summary>
		/// <param name="alpha">The alpha.</param>
		/// <returns></returns>
		public static Country GetCountry(string alpha)
		{
			Country country	= Countries.FirstOrDefault(co => co.Alpha2 == alpha.ToLower());

			if (country != null)
			{
				return country;
			}

			return Countries.FirstOrDefault(co => co.Alpha3 == alpha.ToLower());
		}

		public static Country[] GetCountries(string nameToken)
		{
			return Countries.Where(c => c.Name.ToLower().Contains(nameToken.ToLower())).ToArray();
		}

		#region Overridden common
		/// <summary>
		/// String representation.
		/// </summary>
		/// <returns>The country's name.</returns>
		public override string ToString()
		{
			return this.Name;
		}
		#endregion
	}
}
