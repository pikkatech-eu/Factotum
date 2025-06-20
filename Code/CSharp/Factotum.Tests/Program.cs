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
			//GregorianDateDialog dialog = new GregorianDateDialog();

			//if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			//{
			//	;
			//}

			Temporal temporal = Temporal.CreateClosedIterval(DateTime.Now, DateTime.Now.AddDays(10));

			string text = temporal.ToString();

			Console.WriteLine(text);

			Temporal t1 = Temporal.Parse(text);

			text = "  --1992-05-12 ";

			t1 = Temporal.Parse(text);
		}
	}
}
