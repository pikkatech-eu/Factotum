/***********************************************************************************
* File:         Grammar.cs                                                         *
* Contents:     Class Grammar                                                      *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-11-24 14:56                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Factotum.Dictionaries
{
	public class GrammaticalCase
	{
		/// <summary>
		/// List of all existing grammatical cases (https://universaldependencies.org/u/feat/Case.html)
		/// The first six cases correspond to the Latin declension.
		/// </summary>
		public static Dictionary<string, string> Cases{get;internal set;} = new Dictionary<string, string>()
		{
			["Nom"] =  "Nominative / Direct",
			["Acc"] =  "Accusative / Oblique",
			["Abs"] =  "Absolutive",
			["Erg"] =  "Ergative",
			["Dat"] =  "Dative",
			["Gen"] =  "Genitive",
			["Voc"] =  "Vocative",
			["Ins"] =  "Instrumental / Instructive",
			["Par"] =  "Partitive",
			["Dis"] =  "Distributive",
			["Ess"] =  "Essive / Prolative",
			["Tra"] =  "Translative / Factive",
			["Com"] =  "Comitative / Associative",
			["Abe"] =  "Abessive / Caritive / Privative",
			["Cau"] =  "Causative / Motivative / Purposive",
			["Ben"] =  "Benefactive / Destinative",
			["Cns"] =  "Considerative",
			["Cmp"] =  "Comparative",
			["Equ"] =  "Equative",
			["Loc"] =  "Locative",
			["Lat"] =  "Lative / Directional Allative",
			["Ter"] =  "Terminative / Terminal Allative",
			["Ine"] =  "Inessive",
			["Ill"] =  "Illative / Inlative",
			["Ela"] =  "Elative / Inelative",
			["Add"] =  "Additive",
			["Ade"] =  "Adessive",
			["All"] =  "Allative / Adlative",
			["Abl"] =  "Ablative / Adelative",
			["Sup"] =  "Superessive",
			["Spl"] =  "Superlative",
			["Del"] =  "Delative / Superelative",
			["Sub"] =  "Subessive",
			["Sbl"] =  "Sublative",
			["Sbe"] =  "Subelative",
			["Per"] =  "Perlative",
			["Tem"] =  "Temporal ",
		};
	}
}
