/***********************************************************************************
* File:         FuzzyMath.cs                                                       *
* Contents:     Class FuzzyMath                                                    *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2025-04-07 22:30                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;

namespace Factotum.Maths.Fuzzy
{
    public static class FuzzyMath
    {
		public static Fint Min(Fint x, Fint y)
		{
			return new Fint(Math.Min(x.Value, y.Value), x.IsExact && y.IsExact);
		}

		public static Fint Max(Fint x, Fint y)
		{
			return new Fint(Math.Max(x.Value, y.Value), x.IsExact && y.IsExact);
		}

		public static Fint Abs(Fint x)
		{
			return new Fint(Math.Abs(x.Value), x.IsExact);
		}

		public static Fouble Min(Fouble x, Fouble y)
		{
			return new Fouble(Math.Min(x.Value, y.Value), x.IsExact && y.IsExact);
		}

		public static Fouble Max(Fouble x, Fouble y)
		{
			return new Fouble(Math.Max(x.Value, y.Value), x.IsExact && y.IsExact);
		}

		public static Fouble Abs(Fouble x)
		{
			return new Fouble(System.Math.Abs(x.Value), x.IsExact);
		}

		public static Fouble Sqrt(Fouble x)
		{
			return new Fouble(System.Math.Sqrt(x.Value), x.IsExact);
		}

		public static Fouble Floor(Fouble x)
		{
			return new Fouble(Math.Floor(x.Value), x.IsExact);
		}

		public static Fouble Ceiling(Fouble x)
		{
			return new Fouble(Math.Ceiling(x.Value), x.IsExact);
		}

		public static Fouble Pow(Fouble x, Fouble y)
		{
			return new Fouble(Math.Pow(x.Value, y.Value), x.IsExact && y.IsExact);
		}
    }
}
