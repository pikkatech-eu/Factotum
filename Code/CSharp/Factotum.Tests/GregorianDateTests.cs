/***********************************************************************************
* File:         GregorianDateTests.cs                                              *
* Contents:     Class GregorianDateTests                                           *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-20 19:31                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factotum.Chrono;
using NUnit.Framework;


///		2003-11-09 (ISO)
///		2003 November 9
///		2003Nov9 or 2003Nov09
///		2003-Nov-9 or 2003-Nov-09
///		2003.11.09
///		2003/11/09 or 2003/11/9
///		
namespace Factotum.Tests
{
	[TestFixture]
	public class GregorianDateTests
	{
		[Test]
		public void ParsingYmdDateString_ValidIsoDateString_Succeeds()
		{
			string input = "  2003-11-09	";

			GregorianDate gregorian = GregorianDate.Parse(input);

			Assert.That(gregorian.IsExact);
			Assert.That(gregorian.Year == 2003);
			Assert.That(gregorian.Month == 11);
			Assert.That(gregorian.Day == 9);
		}

		[Test]
		public void ParsingYmdDateString_ValidDottedDateString_Succeeds()
		{
			string input = "  2003.11.09	";

			GregorianDate gregorian = GregorianDate.Parse(input);

			Assert.That(gregorian.IsExact);
			Assert.That(gregorian.Year == 2003);
			Assert.That(gregorian.Month == 11);
			Assert.That(gregorian.Day == 9);
		}

		[Test]
		public void ParsingYmdDateString_ValidSlashedDateString_Succeeds()
		{
			string input = "  2003/11/09	";

			GregorianDate gregorian = GregorianDate.Parse(input);

			Assert.That(gregorian.IsExact);
			Assert.That(gregorian.Year == 2003);
			Assert.That(gregorian.Month == 11);
			Assert.That(gregorian.Day == 9);
		}

		[Test]
		public void ParsingYmdDateString_InvalidIsoDateString_ThrowsException()
		{
			string input = "  2003-11-o9	";

			Assert.Throws<FormatException>(() => GregorianDate.Parse(input));
		}

		[Test]
		public void ParsingInexactYmdDatestring_ValidIso_Succeeds()
		{
			string input = "  ~2003-11-09	";

			GregorianDate gregorian = GregorianDate.Parse(input);

			Assert.That(!gregorian.IsExact);
			Assert.That(gregorian.Year == 2003);
			Assert.That(gregorian.Month == 11);
			Assert.That(gregorian.Day == 9);
		}

		[Test]
		public void ParsingInexactYmdDatestring_WrongFuzzinessSymbol_ThrowsException()
		{
			string input = "*2003-11-09";

			Assert.Throws<FormatException>(() => GregorianDate.Parse(input));
		}

		[Test]
		public void ParsingYmdDateString_IsoYearMonth_Succeeds()
		{
			string input = "  2003-11	";

			GregorianDate gregorian = GregorianDate.Parse(input);

			Assert.That(gregorian.IsExact);
			Assert.That(gregorian.Year == 2003);
			Assert.That(gregorian.Month == 11);
			Assert.That(gregorian.Day == null);
		}
	}
}
