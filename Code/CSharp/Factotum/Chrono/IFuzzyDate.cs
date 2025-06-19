/***********************************************************************************
* File:         IFuzzyDate.cs                                                      *
* Contents:     Interface IFuzzyDate                                               *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-19 14:00                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Factotum.Chrono
{
	public interface IFuzzyDate
	{
		bool IsExact	{get;set;}

		bool Equals(object obj);
	}
}
