/**********************************************************************************************
* File:         CommunicationNumber.cs                                                        *
* Contents:     Class CommunicationNumber                                                     *
* Author:       Alex Konnen (alex@viassol.eu)                                                 *
* Date:         2012-08-18 19:23                                                              *
* Version:      1.0                                                                           *
* Copyright:    Esquisse Laboratories (esquisse@viasol.eu)                                    *
**********************************************************************************************/
namespace Factotum.Dictionaries
{
	/// <summary>
	/// According to HL7 2.8.52 XTN - extended telecommunication number.
	/// </summary>
	public class PhoneAreaCode
	{
		#region Properties
		/// <summary>
		/// ISO-2 country code.
		/// </summary>
		public string	CountryCode						{get;set;}

		/// <summary>
		/// Phone area code.
		/// </summary>
		public string	AreaCode						{get;set;}
		#endregion

		#region Construction
		public PhoneAreaCode(string countryCode, string areaCode)
		{
			this.CountryCode	= countryCode;
			this.AreaCode		= areaCode;
		}
		#endregion

		#region Static data
		/// <summary>
		/// Maps the Alpha-2 country code by ISO3166 into international calling codes.
		/// Source: http://www.visibone.com/countrycodes/
		/// </summary>
		public static Dictionary<string, PhoneAreaCode> PhoneAreaCodes	= new Dictionary<string, PhoneAreaCode>
		{
			["ac"] =  new PhoneAreaCode("ac", "247"),
			["ad"] =  new PhoneAreaCode("ad", "376"),
			["ae"] =  new PhoneAreaCode("ae", "971"),
			["af"] =  new PhoneAreaCode("af", "093"),
			["ag"] =  new PhoneAreaCode("ag", "1268"),
			["ai"] =  new PhoneAreaCode("ai", "1264"),
			["al"] =  new PhoneAreaCode("al", "355"),
			["am"] =  new PhoneAreaCode("am", "374"),
			["an"] =  new PhoneAreaCode("an", "599"),
			["ao"] =  new PhoneAreaCode("ao", "244"),
			["aq"] =  new PhoneAreaCode("aq", "672"),
			["ar"] =  new PhoneAreaCode("ar", "054"),
			["as"] =  new PhoneAreaCode("as", "684"),
			["at"] =  new PhoneAreaCode("at", "043"),
			["au"] =  new PhoneAreaCode("au", "061"),
			["aw"] =  new PhoneAreaCode("aw", "297"),
			["az"] =  new PhoneAreaCode("az", "994"),
			["dz"] =  new PhoneAreaCode("dz", "213"),
			["ba"] =  new PhoneAreaCode("ba", "387"),
			["bb"] =  new PhoneAreaCode("bb", "1246"),
			["bd"] =  new PhoneAreaCode("bd", "880"),
			["be"] =  new PhoneAreaCode("be", "032"),
			["bf"] =  new PhoneAreaCode("bf", "226"),
			["bg"] =  new PhoneAreaCode("bg", "359"),
			["bh"] =  new PhoneAreaCode("bh", "973"),
			["bi"] =  new PhoneAreaCode("bi", "257"),
			["bj"] =  new PhoneAreaCode("bj", "229"),
			["bm"] =  new PhoneAreaCode("bm", "1441"),
			["bn"] =  new PhoneAreaCode("bn", "673"),
			["bo"] =  new PhoneAreaCode("bo", "591"),
			["br"] =  new PhoneAreaCode("br", "055"),
			["bs"] =  new PhoneAreaCode("bs", "1242"),
			["bt"] =  new PhoneAreaCode("bt", "975"),
			["bw"] =  new PhoneAreaCode("bw", "267"),
			["by"] =  new PhoneAreaCode("by", "375"),
			["bz"] =  new PhoneAreaCode("bz", "501"),
			["io"] =  new PhoneAreaCode("io", "246"),
			["vg"] =  new PhoneAreaCode("vg", "1284"),
			["ca"] =  new PhoneAreaCode("ca", "001"),
			["cc"] =  new PhoneAreaCode("cc", "061"),
			["cd"] =  new PhoneAreaCode("cd", "243"),
			["cf"] =  new PhoneAreaCode("cf", "236"),
			["cg"] =  new PhoneAreaCode("cg", "242"),
			["ch"] =  new PhoneAreaCode("ch", "041"),
			["ci"] =  new PhoneAreaCode("ci", "225"),
			["ck"] =  new PhoneAreaCode("ck", "682"),
			["cl"] =  new PhoneAreaCode("cl", "056"),
			["cm"] =  new PhoneAreaCode("cm", "237"),
			["cn"] =  new PhoneAreaCode("cn", "086"),
			["co"] =  new PhoneAreaCode("co", "057"),
			["cr"] =  new PhoneAreaCode("cr", "506"),
			["cs"] =  new PhoneAreaCode("cs", "381"),
			["cu"] =  new PhoneAreaCode("cu", "053"),
			["cv"] =  new PhoneAreaCode("cv", "238"),
			["cx"] =  new PhoneAreaCode("cx", "061"),
			["cy"] =  new PhoneAreaCode("cy", "357"),
			["cz"] =  new PhoneAreaCode("cz", "420"),
			["kh"] =  new PhoneAreaCode("kh", "855"),
			["ky"] =  new PhoneAreaCode("ky", "1345"),
			["td"] =  new PhoneAreaCode("td", "235"),
			["km"] =  new PhoneAreaCode("km", "269"),
			["hr"] =  new PhoneAreaCode("hr", "385"),
			["dd"] =  new PhoneAreaCode("dd", "049"),
			["de"] =  new PhoneAreaCode("de", "049"),
			["dj"] =  new PhoneAreaCode("dj", "253"),
			["dk"] =  new PhoneAreaCode("dk", "045"),
			["dm"] =  new PhoneAreaCode("dm", "1767"),
			["do"] =  new PhoneAreaCode("do", "1809"),
			["ec"] =  new PhoneAreaCode("ec", "593"),
			["ee"] =  new PhoneAreaCode("ee", "372"),
			["eg"] =  new PhoneAreaCode("eg", "020"),
			["eh"] =  new PhoneAreaCode("eh", "212"),
			["er"] =  new PhoneAreaCode("er", "291"),
			["es"] =  new PhoneAreaCode("es", "034"),
			["et"] =  new PhoneAreaCode("et", "251"),
			["tp"] =  new PhoneAreaCode("tp", "670"),
			["sv"] =  new PhoneAreaCode("sv", "503"),
			["gq"] =  new PhoneAreaCode("gq", "240"),
			["fi"] =  new PhoneAreaCode("fi", "358"),
			["fj"] =  new PhoneAreaCode("fj", "679"),
			["fk"] =  new PhoneAreaCode("fk", "500"),
			["fm"] =  new PhoneAreaCode("fm", "691"),
			["fo"] =  new PhoneAreaCode("fo", "298"),
			["fr"] =  new PhoneAreaCode("fr", "033"),
			["fx"] =  new PhoneAreaCode("fx", "033"),
			["gf"] =  new PhoneAreaCode("gf", "594"),
			["pf"] =  new PhoneAreaCode("pf", "689"),
			["ga"] =  new PhoneAreaCode("ga", "241"),
			["gb"] =  new PhoneAreaCode("gb", "3166"),
			["gd"] =  new PhoneAreaCode("gd", "1473"),
			["ge"] =  new PhoneAreaCode("ge", "995"),
			["gg"] =  new PhoneAreaCode("gg", "044"),
			["gh"] =  new PhoneAreaCode("gh", "233"),
			["gi"] =  new PhoneAreaCode("gi", "350"),
			["gl"] =  new PhoneAreaCode("gl", "299"),
			["gm"] =  new PhoneAreaCode("gm", "220"),
			["gn"] =  new PhoneAreaCode("gn", "224"),
			["gp"] =  new PhoneAreaCode("gp", "590"),
			["gr"] =  new PhoneAreaCode("gr", "030"),
			["gt"] =  new PhoneAreaCode("gt", "502"),
			["gu"] =  new PhoneAreaCode("gu", "1671"),
			["gw"] =  new PhoneAreaCode("gw", "245"),
			["gy"] =  new PhoneAreaCode("gy", "592"),
			["hk"] =  new PhoneAreaCode("hk", "852"),
			["hn"] =  new PhoneAreaCode("hn", "504"),
			["ht"] =  new PhoneAreaCode("ht", "509"),
			["hu"] =  new PhoneAreaCode("hu", "036"),
			["va"] =  new PhoneAreaCode("va", "379"),
			["id"] =  new PhoneAreaCode("id", "062"),
			["ie"] =  new PhoneAreaCode("ie", "353"),
			["il"] =  new PhoneAreaCode("il", "972"),
			["im"] =  new PhoneAreaCode("im", "044"),
			["in"] =  new PhoneAreaCode("in", "091"),
			["iq"] =  new PhoneAreaCode("iq", "964"),
			["ir"] =  new PhoneAreaCode("ir", "098"),
			["is"] =  new PhoneAreaCode("is", "354"),
			["it"] =  new PhoneAreaCode("it", "039"),
			["je"] =  new PhoneAreaCode("je", "044"),
			["jm"] =  new PhoneAreaCode("jm", "1876"),
			["jo"] =  new PhoneAreaCode("jo", "962"),
			["jp"] =  new PhoneAreaCode("jp", "081"),
			["ke"] =  new PhoneAreaCode("ke", "254"),
			["kg"] =  new PhoneAreaCode("kg", "996"),
			["ki"] =  new PhoneAreaCode("ki", "686"),
			["kn"] =  new PhoneAreaCode("kn", "1869"),
			["kp"] =  new PhoneAreaCode("kp", "850"),
			["kr"] =  new PhoneAreaCode("kr", "082"),
			["kw"] =  new PhoneAreaCode("kw", "965"),
			["kz"] =  new PhoneAreaCode("kz", "007"),
			["la"] =  new PhoneAreaCode("la", "856"),
			["lb"] =  new PhoneAreaCode("lb", "961"),
			["lc"] =  new PhoneAreaCode("lc", "1758"),
			["li"] =  new PhoneAreaCode("li", "041"),
			["lk"] =  new PhoneAreaCode("lk", "094"),
			["lr"] =  new PhoneAreaCode("lr", "231"),
			["ls"] =  new PhoneAreaCode("ls", "266"),
			["lt"] =  new PhoneAreaCode("lt", "370"),
			["lu"] =  new PhoneAreaCode("lu", "352"),
			["lv"] =  new PhoneAreaCode("lv", "371"),
			["ly"] =  new PhoneAreaCode("ly", "218"),
			["ma"] =  new PhoneAreaCode("ma", "212"),
			["mc"] =  new PhoneAreaCode("mc", "377"),
			["md"] =  new PhoneAreaCode("md", "373"),
			["mg"] =  new PhoneAreaCode("mg", "261"),
			["mh"] =  new PhoneAreaCode("mh", "692"),
			["mk"] =  new PhoneAreaCode("mk", "389"),
			["ml"] =  new PhoneAreaCode("ml", "223"),
			["mm"] =  new PhoneAreaCode("mm", "095"),
			["mn"] =  new PhoneAreaCode("mn", "976"),
			["mo"] =  new PhoneAreaCode("mo", "853"),
			["mp"] =  new PhoneAreaCode("mp", "1670"),
			["mq"] =  new PhoneAreaCode("mq", "596"),
			["mr"] =  new PhoneAreaCode("mr", "222"),
			["ms"] =  new PhoneAreaCode("ms", "1664"),
			["mt"] =  new PhoneAreaCode("mt", "356"),
			["mu"] =  new PhoneAreaCode("mu", "230"),
			["mv"] =  new PhoneAreaCode("mv", "960"),
			["mw"] =  new PhoneAreaCode("mw", "265"),
			["mx"] =  new PhoneAreaCode("mx", "052"),
			["my"] =  new PhoneAreaCode("my", "060"),
			["mz"] =  new PhoneAreaCode("mz", "258"),
			["yt"] =  new PhoneAreaCode("yt", "269"),
			["na"] =  new PhoneAreaCode("na", "264"),
			["nc"] =  new PhoneAreaCode("nc", "687"),
			["ne"] =  new PhoneAreaCode("ne", "227"),
			["nf"] =  new PhoneAreaCode("nf", "672"),
			["ng"] =  new PhoneAreaCode("ng", "234"),
			["ni"] =  new PhoneAreaCode("ni", "505"),
			["nl"] =  new PhoneAreaCode("nl", "031"),
			["no"] =  new PhoneAreaCode("no", "047"),
			["np"] =  new PhoneAreaCode("np", "977"),
			["nr"] =  new PhoneAreaCode("nr", "674"),
			["nu"] =  new PhoneAreaCode("nu", "683"),
			["nz"] =  new PhoneAreaCode("nz", "064"),
			["om"] =  new PhoneAreaCode("om", "968"),
			["pa"] =  new PhoneAreaCode("pa", "507"),
			["pe"] =  new PhoneAreaCode("pe", "051"),
			["pg"] =  new PhoneAreaCode("pg", "675"),
			["ph"] =  new PhoneAreaCode("ph", "063"),
			["pk"] =  new PhoneAreaCode("pk", "092"),
			["pl"] =  new PhoneAreaCode("pl", "048"),
			["pm"] =  new PhoneAreaCode("pm", "508"),
			["pn"] =  new PhoneAreaCode("pn", "872"),
			["pr"] =  new PhoneAreaCode("pr", "1787"),
			["ps"] =  new PhoneAreaCode("ps", "970"),
			["pt"] =  new PhoneAreaCode("pt", "351"),
			["pw"] =  new PhoneAreaCode("pw", "680"),
			["py"] =  new PhoneAreaCode("py", "595"),
			["qa"] =  new PhoneAreaCode("qa", "974"),
			["re"] =  new PhoneAreaCode("re", "262"),
			["ro"] =  new PhoneAreaCode("ro", "040"),
			["ru"] =  new PhoneAreaCode("ru", "007"),
			["rw"] =  new PhoneAreaCode("rw", "250"),
			["sa"] =  new PhoneAreaCode("sa", "966"),
			["sb"] =  new PhoneAreaCode("sb", "677"),
			["sc"] =  new PhoneAreaCode("sc", "248"),
			["sd"] =  new PhoneAreaCode("sd", "249"),
			["se"] =  new PhoneAreaCode("se", "046"),
			["sg"] =  new PhoneAreaCode("sg", "065"),
			["sh"] =  new PhoneAreaCode("sh", "290"),
			["si"] =  new PhoneAreaCode("si", "386"),
			["sj"] =  new PhoneAreaCode("sj", "079"),
			["sk"] =  new PhoneAreaCode("sk", "421"),
			["sl"] =  new PhoneAreaCode("sl", "232"),
			["sm"] =  new PhoneAreaCode("sm", "378"),
			["sn"] =  new PhoneAreaCode("sn", "221"),
			["so"] =  new PhoneAreaCode("so", "252"),
			["sr"] =  new PhoneAreaCode("sr", "597"),
			["st"] =  new PhoneAreaCode("st", "239"),
			["su"] =  new PhoneAreaCode("su", "015"),
			["sy"] =  new PhoneAreaCode("sy", "963"),
			["sz"] =  new PhoneAreaCode("sz", "268"),
			["vc"] =  new PhoneAreaCode("vc", "1784"),
			["ws"] =  new PhoneAreaCode("ws", "685"),
			["za"] =  new PhoneAreaCode("za", "027"),
			["tc"] =  new PhoneAreaCode("tc", "1649"),
			["tg"] =  new PhoneAreaCode("tg", "228"),
			["th"] =  new PhoneAreaCode("th", "066"),
			["tj"] =  new PhoneAreaCode("tj", "992"),
			["tk"] =  new PhoneAreaCode("tk", "690"),
			["tl"] =  new PhoneAreaCode("tl", "670"),
			["tm"] =  new PhoneAreaCode("tm", "993"),
			["tn"] =  new PhoneAreaCode("tn", "216"),
			["to"] =  new PhoneAreaCode("to", "676"),
			["tr"] =  new PhoneAreaCode("tr", "090"),
			["tt"] =  new PhoneAreaCode("tt", "1868"),
			["tv"] =  new PhoneAreaCode("tv", "688"),
			["tw"] =  new PhoneAreaCode("tw", "886"),
			["tz"] =  new PhoneAreaCode("tz", "255"),
			["ua"] =  new PhoneAreaCode("ua", "380"),
			["ug"] =  new PhoneAreaCode("ug", "256"),
			["uk"] =  new PhoneAreaCode("uk", "044"),
			["um"] =  new PhoneAreaCode("um", "808"),
			["us"] =  new PhoneAreaCode("us", "001"),
			["uy"] =  new PhoneAreaCode("uy", "598"),
			["uz"] =  new PhoneAreaCode("uz", "998"),
			["vi"] =  new PhoneAreaCode("vi", "1340"),
			["ve"] =  new PhoneAreaCode("ve", "058"),
			["vn"] =  new PhoneAreaCode("vn", "084"),
			["vu"] =  new PhoneAreaCode("vu", "678"),
			["wf"] =  new PhoneAreaCode("wf", "681"),
			["ye"] =  new PhoneAreaCode("ye", "967"),
			["yu"] =  new PhoneAreaCode("yu", "381"),
			["zm"] =  new PhoneAreaCode("zm", "260"),
			["zr"] =  new PhoneAreaCode("zr", "243"),
			["zw"] =  new PhoneAreaCode("zw", "263")
		};
		#endregion

		#region Search
		/// <summary>
		/// Searches an instance of PhoneAreaCode by country code.
		/// </summary>
		/// <param name="countryCode">The country code.</param>
		/// <returns>Instance of PhoneAreaCode, if found, otherwise null.</returns>
		public static PhoneAreaCode ByCountryCode(string countryCode)
		{
			if (PhoneAreaCodes.ContainsKey(countryCode))
			{
				return PhoneAreaCodes[countryCode];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Searches an instance of PhoneAreaCode by area code.
		/// </summary>
		/// <param name="areaCode">The area code.</param>
		/// <returns>Instance of PhoneAreaCode, if found, otherwise null.</returns>
		public static PhoneAreaCode ByAreaCode(string areaCode)
		{
			if (String.IsNullOrEmpty(areaCode))
			{
				return null;
			}

			return PhoneAreaCodes.Values.FirstOrDefault(c => c.AreaCode == areaCode);
		}
		#endregion
	}
}
