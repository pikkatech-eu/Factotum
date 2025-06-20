using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factotum.Chrono;
using Factotum.Gui.Chrono.Dialogs;

namespace Factotum.Tests
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TemporalDialog dialog = new TemporalDialog();

			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{

			}
		}
	}
}
