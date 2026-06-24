/***********************************************************************************
* File:         GeospatialExtensions.cs                                            *
* Contents:     Class GeospatialExtensions                                         *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-06-24 12:01                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factotum.Maths.Geospatial
{
	public static class GeospatialExtensions
	{
		public static GeoPolygon MainPolygon(this IEnumerable<GeoPolygon> polygons)
		{
			return polygons.MaxBy(p => p.Surface);
		}
	}
}
