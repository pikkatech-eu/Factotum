/***********************************************************************************
* File:         GeoPolygonJsonConverter.cs                                         *
* Contents:     Class GeoPolygonJsonConverter                                      *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-06-19 22:27                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Text.Json;
using Factotum.Maths.Geospatial;

namespace Factotum.Json
{
	/// <summary>
	/// Converts GeoPolygons to and from JSON.
	/// </summary>
	public static class GeoPolygonJsonConverter
	{
		#region Public features
		/// <summary>
		/// Converts a JSON string to a GeoPolygon.
		/// Handles the OSM-geometry JSON format ("format=geojson" in the query).
		/// </summary>
		/// <param name="json">The JSON string.</param>
		/// <returns>Geopolygon converted, if successful, otherwise null.</returns>
		public static GeoPolygon FromJson(string json)
		{
			var result = FromJsonSingle(json);

			if (result != null)
			{
				return result;
			}
			else
			{
				result = FromJsonMulti(json);

				if (result != null)
				{
					return result;
				}
				else
				{
					return null;
				}
			}
		}
		#endregion

		#region Private Auxiliary
		/// <summary>
		/// Tries to extract a polygon from a single-polygon structure.
		/// </summary>
		/// <param name="json">The JSON string to extract from.</param>
		/// <returns>An instance of GeoPolygon, if successful, otherwise null.</returns>
		private static GeoPolygon FromJsonSingle(string json)
		{
			try
			{
				var myDeserializedClass = JsonSerializer.Deserialize<RootSingle>(json);
				var geometry			= myDeserializedClass.features[0].geometry;

				return ExtractSinglePolygon(geometry.coordinates[0]);
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		///		Tries to extract a polygon from a multi-polygon structure.
		///		Extracts a list of polygons and selects the biggest by surface.
		/// </summary>
		/// <param name="json">The JSON string to extract from.</param>
		/// <returns>An instance of GeoPolygon, if successful, otherwise null.</returns>
		private static GeoPolygon FromJsonMulti(string json)
		{
			try
			{
				var myDeserializedClass = JsonSerializer.Deserialize<RootMulti>(json);

				var geometry	= myDeserializedClass.features[0].geometry;

				List<GeoPolygon> polygons	= new List<GeoPolygon>();

				foreach (var subArray in geometry.coordinates[0])
				{
					GeoPolygon pg = ExtractSinglePolygon(subArray);

					polygons.Add(pg);
				}

				return polygons.MaxBy(p=>p.Surface);
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// Extracts a single polygon from a double list of doubles.
		/// </summary>
		/// <param name="coordinates">The double list of doubles treated as coordinate pairs.</param>
		/// <returns>An instance of GeoPolygon extracted.</returns>
		private static GeoPolygon ExtractSinglePolygon(List<List<double>> coordinates)
		{
			GeoPolygon polygon	= new GeoPolygon();

			foreach (var pair in coordinates)
			{
				double latitude		= pair[0];
				double longitude	= pair[1];

				GeoPoint geoPoint	= new GeoPoint(latitude, longitude);
				polygon._vertices.Add(geoPoint);
			}

			return polygon;
		}
		#endregion
	}
}
