/***********************************************************************************
* File:         GregorianDateDialog.cs                                             *
* Contents:     Class GregorianDateDialog                                          *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-19 20:22                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Factotum.Chrono;
using Factotum.Gui.Chrono.Interfaces;

namespace Factotum.Gui.Chrono.Dialogs
{
	public partial class GregorianDateDialog : Form, IGregorianDateDevice
	{
		public GregorianDateDialog()
		{
			InitializeComponent();
		}

		private void OnOk(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnCancel(object sender, EventArgs e)
		{

		}

		public GregorianDate GregorianDate
		{
			get
			{
				return this._ctrlGregorianDate.GregorianDate;
			}

			set
			{
				this._ctrlGregorianDate.GregorianDate = value;
			}
		}

		public event Action<GregorianDate> ValueChanged;
	}
}
