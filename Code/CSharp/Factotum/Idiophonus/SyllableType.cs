/***********************************************************************************
* File:         SyllableType.cs                                                    *
* Contents:     Enum SyllableType                                                  *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-10-18 23:33                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factotum.Idiophonus
{
	/// <summary>
	/// Syllable type
	/// </summary>
	public enum SyllableType
	{
		/// <summary>
		/// Unknown syllable type.
		/// </summary>
		Unknown	= -1,

		/// <summary>
		/// Vowel syllable
		/// </summary>
		V	= 0,

		/// <summary>
		/// "CV" syllable, e.g. 'cu'
		/// </summary>
		CV	= 1,

		/// <summary>
		/// "VC" syllable
		/// </summary>
		VC	= 2,

		/// <summary>
		/// "CVC" syllable.
		/// </summary>
		CVC	= 3
	}
}
