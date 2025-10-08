/**********************************************************************************************
* File:         ReligiousAffiliation.cs                                                       *
* Contents:     Class ReligiousAffiliation                                                    *
* Author:       Alex Konnen (alex@viassol.eu)                                                 *
* Date:         2012-08-19 12:11                                                              *
* Version:      1.0                                                                           *
* Copyright:    Esquisse Laboratories (esquisse@viasol.eu)                                    *
**********************************************************************************************/
namespace Factotum.Dictionaries
{
	/// <summary>
	/// Religious affiliations.
	/// Based on "RELIGIOUS OR OTHER BELIEF SYSTEM AFFILIATION CODE".
	/// NHS of UK: https://www.datadictionary.nhs.uk/attributes/religious_or_other_belief_system_affiliation_code.html?hl=religious%2Cother%2Cbelief%2Csystem%2Caffiliation%2Ccode
	/// </summary>
	public class ReligiousAffiliation
	{
		#region Properties
		/// <summary>
		/// Classification code.
		/// </summary>
		public	string	Code		{get;set;}

		/// <summary>
		/// Concept description.
		/// </summary>
		public	string	Description	{get;set;}
		#endregion

		#region Static Data
		/// <summary>
		/// Source: 
		/// RELIGIOUS OR OTHER BELIEF SYSTEM AFFILIATION CODE
		/// NHS is a UK national standard, the codes are regarded as UK national codes for Religios Affiliation in Medicine.
		/// Compared with e few other standards available, seems to be more thorough developed and thus acepted.
		/// https://www.datadictionary.nhs.uk/attributes/religious_or_other_belief_system_affiliation_code.html?hl=religious%2Cother%2Cbelief%2Csystem%2Caffiliation%2Ccode
		/// </summary>
		public static	Dictionary<string, string> Branches = new Dictionary<string, string>()
		{
			{"A",	"Baha'i"},
			{"B",	"Buddhist"},
			{"C",	"Christian"},
			{"D",	"Hindu"},
			{"E",	"Jain"},
			{"F",	"Jewish"},
			{"G",	"Muslim"},
			{"H",	"Pagan"},
			{"I",	"Sikh"},
			{"J",	"Zoroastrian"},
			{"K",	"Other"},
			{"L",	"None"},

			/// 	Religion not given - patient refused
			{"M",	"Declined"},

			///		Should be used when the patient has not been asked for their religious affiliation
			{"N",	"Unknown"},
		};

		/// <summary>
		/// Source: 
		/// RELIGIOUS OR OTHER BELIEF SYSTEM AFFILIATION CODE
		/// NHS is a UK national standard, the codes are regarded as UK national codes for Religios Affiliation in Medicine.
		/// Compared with e few other standards available, seems to be more thorough developed and thus acepted.
		/// http://www.datadictionary.nhs.uk/data_dictionary/attributes/r/red/religious_or_other_belief_system_affiliation_code_de.asp?shownav=1
		/// The synonyms were not applied.
		/// </summary>
		public static Dictionary<string, ReligiousAffiliation> Religions = new Dictionary<string, ReligiousAffiliation>()
		{
			{"A1",	new ReligiousAffiliation{Code="A1",		Description="Baha'i"}},
			{"B1",	new ReligiousAffiliation{Code="B1",		Description="Buddhist"}},
			{"B2",	new ReligiousAffiliation{Code="B2",		Description="Mahayana Buddhist"}},
			{"B3",	new ReligiousAffiliation{Code="B3",		Description="New Kadampa Tradition Buddhist"}},
			{"B4",	new ReligiousAffiliation{Code="B4",		Description="Nichiren Buddhist"}},
			{"B5",	new ReligiousAffiliation{Code="B5",		Description="Pure Land Buddhist"}},
			{"B6",	new ReligiousAffiliation{Code="B6",		Description="Theravada Buddhist"}},
			{"B7",	new ReligiousAffiliation{Code="B7",		Description="Tibetan Buddhist"}},
			{"B8",	new ReligiousAffiliation{Code="B8",		Description="Zen Buddhist"}},
			{"C1",	new ReligiousAffiliation{Code="C1",		Description="Christian"}},
			{"C2",	new ReligiousAffiliation{Code="C2",		Description="Amish"}},
			{"C3",	new ReligiousAffiliation{Code="C3",		Description="Anabaptist"}},
			{"C4",	new ReligiousAffiliation{Code="C4",		Description="Anglican"}},
			{"C5",	new ReligiousAffiliation{Code="C5",		Description="Apostolic Pentecostalist"}},
			{"C6",	new ReligiousAffiliation{Code="C6",		Description="Armenian Catholic"}},
			{"C7",	new ReligiousAffiliation{Code="C7",		Description="Armenian Orthodox"}},
			{"C8",	new ReligiousAffiliation{Code="C8",		Description="Baptist"}},
			{"C9",	new ReligiousAffiliation{Code="C9",		Description="Brethren"}},
			{"C10",	new ReligiousAffiliation{Code="C10",	Description="Bulgarian Orthodox"}},
			{"C11", new ReligiousAffiliation{Code="C11",	Description="Calvinist"}},
			{"C12", new ReligiousAffiliation{Code="C12",	Description="Catholic: Not Roman Catholic"}},
			{"C13", new ReligiousAffiliation{Code="C13",	Description="Celtic Christian"}},
			{"C14", new ReligiousAffiliation{Code="C14",	Description="Celtic Orthodox Christian"}},
			{"C15", new ReligiousAffiliation{Code="C15",	Description="Chinese Evangelical Christian"}},
			{"C16", new ReligiousAffiliation{Code="C16",	Description="Christadelphian"}},
			{"C17", new ReligiousAffiliation{Code="C17",	Description="Christian Existentialist"}},
			{"C18", new ReligiousAffiliation{Code="C18",	Description="Christian Humanist"}},
			{"C19", new ReligiousAffiliation{Code="C19",	Description="Christian Scientist"}},
			{"C20", new ReligiousAffiliation{Code="C20",	Description="Christian Spiritualist"}},
			{"C21", new ReligiousAffiliation{Code="C21",	Description="Church in Wales"}},
			{"C22", new ReligiousAffiliation{Code="C22",	Description="Church of England"}},
			{"C23", new ReligiousAffiliation{Code="C23",	Description="Church of God of Prophecy"}},
			{"C24", new ReligiousAffiliation{Code="C24",	Description="Church of Ireland"}},
			{"C25", new ReligiousAffiliation{Code="C25",	Description="Church of Scotland"}},
			{"C26", new ReligiousAffiliation{Code="C26",	Description="Congregationalist"}},
			{"C27", new ReligiousAffiliation{Code="C27",	Description="Coptic Orthodox"}},
			{"C28", new ReligiousAffiliation{Code="C28",	Description="Eastern Catholic"}},
			{"C29", new ReligiousAffiliation{Code="C29",	Description="Eastern Orthodox"}},
			{"C30", new ReligiousAffiliation{Code="C30",	Description="Elim Pentecostalist"}},
			{"C31", new ReligiousAffiliation{Code="C31",	Description="Ethiopian Orthodox"}},
			{"C32", new ReligiousAffiliation{Code="C32",	Description="Evangelical Christian"}},
			{"C33", new ReligiousAffiliation{Code="C33",	Description="Exclusive Brethren"}},
			{"C34", new ReligiousAffiliation{Code="C34",	Description="Free Church"}},
			{"C35", new ReligiousAffiliation{Code="C35",	Description="Free Church of Scotland"}},
			{"C36", new ReligiousAffiliation{Code="C36",	Description="Free Evangelical Presbyterian"}},
			{"C37", new ReligiousAffiliation{Code="C37",	Description="Free Methodist"}},
			{"C38", new ReligiousAffiliation{Code="C38",	Description="Free Presbyterian"}},
			{"C39", new ReligiousAffiliation{Code="C39",	Description="French Protestant"}},
			{"C40", new ReligiousAffiliation{Code="C40",	Description="Greek Catholic"}},
			{"C41", new ReligiousAffiliation{Code="C41",	Description="Greek Orthodox"}},
			{"C42", new ReligiousAffiliation{Code="C42",	Description="Independent Methodist"}},
			{"C43", new ReligiousAffiliation{Code="C43",	Description="Indian Orthodox"}},
			{"C44", new ReligiousAffiliation{Code="C44",	Description="Jehovah's Witness"}},
			{"C45", new ReligiousAffiliation{Code="C45",	Description="Judaic Christian"}},
			{"C46", new ReligiousAffiliation{Code="C46",	Description="Lutheran"}},
			{"C47", new ReligiousAffiliation{Code="C47",	Description="Mennonite"}},
			{"C48", new ReligiousAffiliation{Code="C48",	Description="Messianic Jew"}},
			{"C49", new ReligiousAffiliation{Code="C49",	Description="Methodist"}},
			{"C50", new ReligiousAffiliation{Code="C50",	Description="Moravian"}},
			{"C51", new ReligiousAffiliation{Code="C51",	Description="Mormon"}},
			{"C52", new ReligiousAffiliation{Code="C52",	Description="Nazarene Church"}},
			{"C53", new ReligiousAffiliation{Code="C53",	Description="New Testament Pentacostalist"}},
			{"C54", new ReligiousAffiliation{Code="C54",	Description="Nonconformist"}},
			{"C55", new ReligiousAffiliation{Code="C55",	Description="Old Catholic"}},
			{"C56", new ReligiousAffiliation{Code="C56",	Description="Open Brethren"}},
			{"C57", new ReligiousAffiliation{Code="C57",	Description="Orthodox Christian"}},
			{"C58", new ReligiousAffiliation{Code="C58",	Description="Pentecostalist"}},
			{"C59", new ReligiousAffiliation{Code="C59",	Description="Presbyterian"}},
			{"C60", new ReligiousAffiliation{Code="C60",	Description="Protestant"}},
			{"C61", new ReligiousAffiliation{Code="C61",	Description="Plymouth Brethren"}},
			{"C62", new ReligiousAffiliation{Code="C62",	Description="Quaker"}},
			{"C63", new ReligiousAffiliation{Code="C63",	Description="Rastafari"}},
			{"C64", new ReligiousAffiliation{Code="C64",	Description="Reformed Christian"}},
			{"C65", new ReligiousAffiliation{Code="C65",	Description="Reformed Presbyterian"}},
			{"C66", new ReligiousAffiliation{Code="C66",	Description="Reformed Protestant"}},
			{"C67", new ReligiousAffiliation{Code="C67",	Description="Roman Catholic"}},
			{"C68", new ReligiousAffiliation{Code="C68",	Description="Romanian Orthodox"}},
			{"C69", new ReligiousAffiliation{Code="C69",	Description="Russian Orthodox"}},
			{"C70", new ReligiousAffiliation{Code="C70",	Description="Salvation Army Member"}},
			{"C71", new ReligiousAffiliation{Code="C71",	Description="Scottish Episcopalian"}},
			{"C72", new ReligiousAffiliation{Code="C72",	Description="Serbian Orthodox"}},
			{"C73", new ReligiousAffiliation{Code="C73",	Description="Seventh Day Adventist"}},
			{"C74", new ReligiousAffiliation{Code="C74",	Description="Syrian Orthodox"}},
			{"C75", new ReligiousAffiliation{Code="C75",	Description="Ukrainian Catholic"}},
			{"C76", new ReligiousAffiliation{Code="C76",	Description="Ukrainian Orthodox"}},
			{"C77", new ReligiousAffiliation{Code="C77",	Description="Uniate Catholic"}},
			{"C78", new ReligiousAffiliation{Code="C78",	Description="Unitarian"}},
			{"C79", new ReligiousAffiliation{Code="C79",	Description="United Reform"}},
			{"C80", new ReligiousAffiliation{Code="C80",	Description="Zwinglian"}},
			{"D1",	new ReligiousAffiliation{Code="D1",		Description="Hindu"}},
			{"D2",	new ReligiousAffiliation{Code="D2",		Description="Advaitin Hindu"}},
			{"D3",	new ReligiousAffiliation{Code="D3",		Description="Arya Samaj Hindu"}},
			{"D4",	new ReligiousAffiliation{Code="D4",		Description="Shakti Hindu"}},
			{"D5",	new ReligiousAffiliation{Code="D5",		Description="Shiva Hindu"}},
			{"D6",	new ReligiousAffiliation{Code="D6",		Description="Vaishnava Hindu"}},
			{"E1",	new ReligiousAffiliation{Code="E1",		Description="Jain"}},
			{"F1",	new ReligiousAffiliation{Code="F1",		Description="Jewish"}},
			{"F2",	new ReligiousAffiliation{Code="F2",		Description="Ashkenazi Jew"}},
			{"F3",	new ReligiousAffiliation{Code="F3",		Description="Haredi Jew"}},
			{"F4",	new ReligiousAffiliation{Code="F4",		Description="Hasidic Jew"}},
			{"F5",	new ReligiousAffiliation{Code="F5",		Description="Liberal Jew"}},
			{"F6",	new ReligiousAffiliation{Code="F6",		Description="Masorti Jew"}},
			{"F7",	new ReligiousAffiliation{Code="F7",		Description="Orthodox Jew"}},
			{"F8",	new ReligiousAffiliation{Code="F8",		Description="Reform Jew"}},
			{"G1",	new ReligiousAffiliation{Code="G1",		Description="Muslim"}},
			{"G2",	new ReligiousAffiliation{Code="G2",		Description="Ahmadi"}},
			{"G3",	new ReligiousAffiliation{Code="G3",		Description="Druze"}},
			{"G4",	new ReligiousAffiliation{Code="G4",		Description="Ismaili Muslim"}},
			{"G5",	new ReligiousAffiliation{Code="G5",		Description="Shi'ite Muslim"}},
			{"G6",	new ReligiousAffiliation{Code="G6",		Description="Sunni Muslim"}},
			{"H1",	new ReligiousAffiliation{Code="H1",		Description="Pagan"}},
			{"H2",	new ReligiousAffiliation{Code="H2",		Description="Asatruar"}},
			{"H3",	new ReligiousAffiliation{Code="H3",		Description="Celtic Pagan"}},
			{"H4",	new ReligiousAffiliation{Code="H4",		Description="Druid"}},
			{"H5",	new ReligiousAffiliation{Code="H5",		Description="Goddess"}},
			{"H6",	new ReligiousAffiliation{Code="H6",		Description="Heathen"}},
			{"H7",	new ReligiousAffiliation{Code="H7",		Description="Occultist"}},
			{"H8",	new ReligiousAffiliation{Code="H8",		Description="Shaman"}},
			{"H9",	new ReligiousAffiliation{Code="H9",		Description="Wiccan"}},
			{"I1",	new ReligiousAffiliation{Code="I1",		Description="Sikh"}},
			{"J1",	new ReligiousAffiliation{Code="J1",		Description="Zoroastrian"}},

			///		Should be used when the patient has been asked for their religious affiliation but they are unsure what it is
			{"K1",	new ReligiousAffiliation{Code="K1",		Description="Agnostic"}},
			{"K2",	new ReligiousAffiliation{Code="K2",		Description="Ancestral Worship"}},
			{"K3",	new ReligiousAffiliation{Code="K3",		Description="Animist"}},
			{"K4",	new ReligiousAffiliation{Code="K4",		Description="Anthroposophist"}},
			{"K5",	new ReligiousAffiliation{Code="K5",		Description="Black Magic"}},
			{"K6",	new ReligiousAffiliation{Code="K6",		Description="Brahma Kumari"}},
			{"K7",	new ReligiousAffiliation{Code="K7",		Description="British Israelite"}},
			{"K8",	new ReligiousAffiliation{Code="K8",		Description="Chondogyo"}},
			{"K9",	new ReligiousAffiliation{Code="K9",		Description="Confucianist"}},
			{"K10", new ReligiousAffiliation{Code="K10",	Description="Deist"}},
			{"K11", new ReligiousAffiliation{Code="K11",	Description="Humanist"}},
			{"K12", new ReligiousAffiliation{Code="K12",	Description="Infinite Way"}},
			{"K13", new ReligiousAffiliation{Code="K13",	Description="Kabbalist"}},
			{"K14", new ReligiousAffiliation{Code="K14",	Description="Lightworker"}},
			{"K15", new ReligiousAffiliation{Code="K15",	Description="New Age Practitioner"}},
			{"K16", new ReligiousAffiliation{Code="K16",	Description="Native American Religion"}},
			{"K17", new ReligiousAffiliation{Code="K17",	Description="Pantheist"}},
			{"K18", new ReligiousAffiliation{Code="K18",	Description="Peyotist"}},
			{"K19", new ReligiousAffiliation{Code="K19",	Description="Radha Soami"}},

			///		Should be used whenthe patient has been asked for their religious affiliation and it is one that is not listed
			{"K20", new ReligiousAffiliation{Code="K20",	Description="Religion (Other Not Listed)"}},
			{"K21", new ReligiousAffiliation{Code="K21",	Description="Santeri"}},
			{"K22", new ReligiousAffiliation{Code="K22",	Description="Satanist"}},
			{"K23", new ReligiousAffiliation{Code="K23",	Description="Scientologist"}},
			{"K24", new ReligiousAffiliation{Code="K24",	Description="Secularist"}},
			{"K25", new ReligiousAffiliation{Code="K25",	Description="Shumei"}},
			{"K26", new ReligiousAffiliation{Code="K26",	Description="Shinto"}},
			{"K27", new ReligiousAffiliation{Code="K27",	Description="Spiritualist"}},
			{"K28", new ReligiousAffiliation{Code="K28",	Description="Swedenborgian"}},
			{"K29", new ReligiousAffiliation{Code="K29",	Description="Taoist"}},
			{"K30", new ReligiousAffiliation{Code="K30",	Description="Unitarian-Universalist"}},
			{"K31", new ReligiousAffiliation{Code="K31",	Description="Universalist"}},
			{"K32", new ReligiousAffiliation{Code="K32",	Description="Vodun"}},
			{"K33", new ReligiousAffiliation{Code="k33",	Description="Yoruba"}},
			{"L1",	new ReligiousAffiliation{Code="L1",		Description="Atheist"}},
			{"L2",	new ReligiousAffiliation{Code="L2",		Description="Not Religious"}},
			{"M1",	new ReligiousAffiliation{Code="M1",		Description="Religion not given - patient refused"}},
			{"N1",	new ReligiousAffiliation{Code="N1",		Description="Patient Religion Unknown"}},
		};
		#endregion

		#region Access
		/// <summary>
		/// Gets the instances of ReligiousAffiliation belonging to a defined branch.
		/// </summary>
		/// <param name="branchCode">The branch code ("A".."N" from the Branches dictionary).</param>
		/// <returns>
		///		Dictionary containing instances of ReligiousAffiliation in the branch as a dictionary 
		///		with the instances' code as the key, instance itself as the value
		///	</returns>
		public static Dictionary<string, ReligiousAffiliation>	GetBranch(string branchCode)
		{
			return Religions.Where(kvp=>kvp.Value.Code.StartsWith(branchCode)).ToDictionary(c=>c.Key, c=>c.Value);
		}

		/// <summary>
		/// Selects the religious affiliation by the NHS code.
		/// </summary>
		/// <param name="code">The NHS code.</param>
		/// <returns>The religious affiliation, if found, otherwise null.</returns>
		public static ReligiousAffiliation ByCode(string code)
		{
			if (Religions.ContainsKey(code))
			{
				return Religions[code];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Selects religious affiliations by a name token.
		/// </summary>
		/// <param name="token">
		///		The name token to be contained in a religious affiliation's name to include (case-insensitive).
		///	</param>
		/// <returns>Array of religious affiliations containing the name token.</returns>
		public ReligiousAffiliation[] ByDescriptionToken(string token)
		{
			return Religions.Values.Where(religion => religion.Description.ToLower().Contains(token.ToLower())).ToArray();
		}
		#endregion
	}
}
