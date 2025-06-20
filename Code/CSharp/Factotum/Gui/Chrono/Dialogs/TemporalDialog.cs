using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factotum.Gui.Chrono.Dialogs
{
	public partial class TemporalDialog : Form
	{
		public TemporalDialog()
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
	}
}
