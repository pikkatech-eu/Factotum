using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factotum.Gui.Chrono.Dialogs;

namespace Factotum.Tests
{
	internal class Program
	{
		static void Main(string[] args)
		{
			GregorianDateDialog dialog = new GregorianDateDialog();

			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				;
			}
		}
	}
}
