/***********************************************************************************
* File:         IGregorianDateDevice.cs                                            *
* Contents:     Interface IGregorianDateDevice                                     *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-19 16:54                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using Factotum.Chrono;

namespace Factotum.Gui.Chrono.Interfaces
{
	public interface IGregorianDateDevice
	{
		GregorianDate GregorianDate	{get;set;}
	}
}
