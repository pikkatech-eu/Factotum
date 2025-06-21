/***********************************************************************************
* File:         TemporalControl.cs                                                 *
* Contents:     Class TemporalControl                                              *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-20 20:35                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Windows.Forms;
using Factotum.Chrono;
using Factotum.Gui.Chrono.Interfaces;

namespace Factotum.Gui.Chrono.Controls
{
	public partial class SimpleTemporalControl : UserControl, ITemporalDevice
	{
		private const string SINGLE_DATE		= "Single Date";
		private const string CLOSED_INTERVAL	= "Closed Interval";
		private const string BEFORE				= "Before";
		private const string AFTER				= "After";

		private static readonly string[] TYPES	= {SINGLE_DATE, CLOSED_INTERVAL, BEFORE, AFTER};
		public SimpleTemporalControl()
		{
			InitializeComponent();

			this._ctrlStart.ValueChanged += this.StartValueChanged;
			this._ctrlEnd.ValueChanged += this.EndValueChanged;

			this._cxType.Items.AddRange(TYPES);
			this._cxType.SelectedItem = SINGLE_DATE;
		}

		private void StartValueChanged(GregorianDate gregorian)
		{
			this.Temporal.Start	= gregorian;

			this._txTemporal.Text	= this.Temporal.ToString();
		}

		private void EndValueChanged(GregorianDate gregorian)
		{
			this.Temporal.End	= gregorian;

			this._txTemporal.Text	= this.Temporal.ToString();
		}

		private void OnSelectedTypeChanged(object sender, EventArgs e)
		{
			this._txTemporal.Text	= "";

			switch (this._cxType.SelectedItem.ToString())
			{
				case SINGLE_DATE:
					this._ctrlStart.Visible	= true;
					this._ctrlEnd.Visible	= false;
					this._lblStart.Text		= "Date";
					this._lblEnd.Text		= "";

					this.Temporal.End		= this.Temporal.Start;

					break;

				case CLOSED_INTERVAL:
					this._ctrlStart.Visible	= true;
					this._ctrlEnd.Visible	= true;
					this._lblStart.Text		= "Start";
					this._lblEnd.Text		= "End";

					break;

				case BEFORE:
					this._ctrlStart.Visible	= false;
					this._ctrlEnd.Visible	= true;
					this._lblStart.Text		= "";
					this._lblEnd.Text		= "End";

					this.Temporal.Start		= null;

					break;

				case AFTER:
					this._ctrlStart.Visible	= true;
					this._ctrlEnd.Visible	= false;
					this._lblStart.Text		= "Start";
					this._lblEnd.Text		= "";

					this.Temporal.End		= null;

					break;

				default:
					break;
			}
		}

		public Temporal Temporal
		{
			get
			{
				Temporal t	= new Temporal();
				t.Start		= this._ctrlStart.GregorianDate;
				t.End		= this._ctrlEnd.GregorianDate;

				return t;
			}

			set
			{
				this._ctrlStart.GregorianDate	= value.Start;
				this._ctrlEnd.GregorianDate		= value.End;
			}
		}
	}
}
