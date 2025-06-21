/***********************************************************************************
* File:         GregorianDateControl.cs                                            *
* Contents:     Class GregorianDateControl                                         *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-19 17:18                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Windows.Forms;
using Factotum.Chrono;
using Factotum.Gui.Chrono.Interfaces;

namespace Factotum.Gui.Chrono.Controls
{
	/// <summary>
	/// Simplified control without the text output and parsing
	/// </summary>
	public partial class SimpleGregorianDateControl  : UserControl, IGregorianDateDevice
	{
		public SimpleGregorianDateControl ()
		{
			InitializeComponent();

			GregorianDate gregorian = DateTime.Now;
		}

		private void OnValuesChanged(object sender, EventArgs e)
		{
			string text = this.GregorianDate.ToString();

			this.ValueChanged?.Invoke(this.GregorianDate);
		}

		public GregorianDate GregorianDate
		{
			get
			{
				GregorianDate gregorian = new GregorianDate();
				gregorian.Year		= (int)this._nudYear.Value;
				gregorian.Month		= (int)this._nudMonth.Value;
				gregorian.Day		= (int)this._nudDay.Value;
				gregorian.IsExact	= this._cbIsExact.Checked;

				return gregorian;
			}

			set
			{
				this._nudYear.Value		= value.Year != null ? (int)value.Year : 0;
				this._nudMonth.Value	= value.Month != null ? (int)value.Month : 0;
				this._nudDay.Value		= value.Day != null ? (int)value.Day : 0;
				this._cbIsExact.Checked	= value.IsExact;
			}
		}

		public event Action<GregorianDate>	ValueChanged;
	}
}
