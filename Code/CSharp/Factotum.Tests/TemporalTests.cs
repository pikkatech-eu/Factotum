/***********************************************************************************
* File:         TemporalTests.cs                                                   *
* Contents:     Class TemporalTests                                                *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-06-20 18:26                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using Factotum.Chrono;
using NUnit.Framework;

namespace Factotum.Tests
{
	[TestFixture]
	public class TemporalTests
	{
		[Test]
		public void ParsingTemporal_ValidInstantString_Succeeds()
		{
			string text = "1999-12-05";
			Temporal t	= Temporal.Parse(text);

			Assert.That(t.IsInstant());
			Assert.That(t.Start.IsExact);
			Assert.That(t.End.IsExact);
			Assert.That(t.Start == t.End);
		}

		[Test]
		public void ParsingTemporal_InvalidInstantString_ThrowsException()
		{
			string text = "1999-12-o5";

			Assert.Throws<FormatException>(() => Temporal.Parse(text));
		}

		[Test]
		public void ParsingTemporal_ValidClosedIntervalString_Succeeds()
		{
			string text = "  1999-12-05	--   1993-12-06	";

			Temporal t	= Temporal.Parse(text);
			Assert.That(t.IsClosedInterval());

			Assert.That(t.Start.IsExact);
			Assert.That(t.End.IsExact);
		}

		[Test]
		public void ParsingTemporal_ValidIntervalBeforeString_Succeeds()
		{
			string text = "  --   1993-12-06	";

			Temporal t	= Temporal.Parse(text);

			Assert.That(t.IsIntervalBefore());
		}


		[Test]
		public void ParsingTemporal_ValidIntervalAfterString_Succeeds()
		{
			string text = " 1993-12-06 --	";

			Temporal t	= Temporal.Parse(text);

			Assert.That(t.IsIntervalAfter());
		}


		[Test]
		public void ParsingTemporal_RandomInvalidString_ThrowsException()
		{
			string text = " gjap5673483ß^#	";

			Assert.Throws<FormatException>(() => Temporal.Parse(text));
		}
	}
}
