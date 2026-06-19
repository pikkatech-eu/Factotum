/***********************************************************************************
* File:         JsonGeoPolygonAuxiliary.cs                                         *
* Contents:     Auxiliary Classes for GeoPolygonJsonConverter                      *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-06-19 23:46                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

// RootSingle myDeserializedClass = JsonConvert.DeserializeObject<RootSingle>(myJsonResponse);

/// <summary>
/// Class Address.
/// Added to satgisfy JsonSerializer.
/// Not used directly.
/// </summary>
public class Address
{
	public string city { get; set; }
	public string state { get; set; }
	public string ISO31662lvl4 { get; set; }
	public string country { get; set; }
	public string country_code { get; set; }
}

/// <summary>
/// Class Properties.
/// Added to satgisfy JsonSerializer.
/// Not used directly.
/// </summary>
public class Properties
{
	public int place_id { get; set; }
	public string osm_type { get; set; }
	public int osm_id { get; set; }
	public int place_rank { get; set; }
	public string category { get; set; }
	public string type { get; set; }
	public double importance { get; set; }
	public string addresstype { get; set; }
	public string name { get; set; }
	public string display_name { get; set; }
	public Address address { get; set; }
}

/// <summary>
/// Geometry in single format.
/// Saves points as a 3-fold list of doubles.
/// </summary>
public class GeometrySingle
{
	public string type { get; set; }
	public List<List<List<double>>> coordinates { get; set; }
}

/// <summary>
/// Geometry in multi format.
/// Saves points as a 4-fold list of doubles.
/// </summary>
public class GeometryMulti
{
	public string type { get; set; }
	public List<List<List<List<double>>>> coordinates { get; set; }
}

/// <summary>
/// Feature in single format.
/// Uses GeometrySingle as geometry representation.
/// </summary>
public class FeatureSingle
{
	public string type { get; set; }
	public Properties properties { get; set; }
	public List<double> bbox { get; set; }
	public GeometrySingle geometry { get; set; }
}

/// <summary>
/// Feature in multi format.
/// Uses GeometryMulti as geometry representation.
/// </summary>
public class FeatureMulti
{
	public string type { get; set; }
	public Properties properties { get; set; }
	public List<double> bbox { get; set; }
	public GeometryMulti geometry { get; set; }
}

/// <summary>
/// Root in single format.
/// Uses FeatureSingle as feature representation.
/// </summary>
public class RootSingle
{
	public string type { get; set; }
	public string licence { get; set; }
	public List<FeatureSingle> features { get; set; }
}

/// <summary>
/// Root in multi format.
/// Uses FeatureMulti as feature representation.
/// </summary>
public class RootMulti
{
	public string type { get; set; }
	public string licence { get; set; }
	public List<FeatureMulti> features { get; set; }
}


