using System.Collections.Generic;
using System.Xml.Linq;
using Factotum.Xml;

namespace Factotum.Tests
{
	internal class Program
	{
		static void Main(string[] args)
		{
			XElement x = new XElement("main");

			//double[] prices = {2.87, 3.62, 4.12};

			//x.AppendElements<double>(prices, "price");

			//var result = x.ListValue<double>("price");

			Dictionary<int, double> dictionary = new Dictionary<int, double>();
			dictionary.Add(42, 2.87);
			dictionary.Add(69, 3.62);

			x.AppendDictionary<int, double>(dictionary, "price");

			var result = x.DictionaryValue<int, double>("price");
		}
	}
}
