/***********************************************************************************
* File:         GeospatialExtensions.cs                                            *
* Contents:     Class GeospatialExtensions                                         *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-06-24 12:01                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Factotum.Maths.Geospatial
{
	public static class GeospatialExtensions
	{
		/// <summary>
		/// Selects the biggest polygon out of a collection.
		/// </summary>
		/// <param name="polygons">Collection of polygons.</param>
		/// <returns>The biggest by surface.</returns>
		public static GeoPolygon Biggest(this IEnumerable<GeoPolygon> polygons)
		{
			return polygons.MaxBy(p => p.Surface);
		}
	}
}
