/***********************************************************************************
* File:         ITemporalDevice.cs                                                 *
* Contents:     Interface ITemporalDevice                                          *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-20 20:22                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using Factotum.Chrono;

namespace Factotum.Gui.Chrono.Interfaces
{
	public interface ITemporalDevice
	{
		Temporal	Temporal	{get;set;}
	}
}
