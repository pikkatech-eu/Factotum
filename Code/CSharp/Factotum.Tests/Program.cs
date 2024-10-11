using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Factotum.Xml;
using FMC = Factotum.Maths.Constants;

namespace Factotum.Tests
{
	internal class Program
	{
		static void Main(string[] args)
		{
			XElement x = new XElement("main");

			x.AppendElement("int", 42);
			x.AppendElement("int", 43);

			x.AppendElement("bool", true);

			x.AppendElement("dateTime", DateTime.Now);

			var p = FMC.PI;

		}
	}
}
