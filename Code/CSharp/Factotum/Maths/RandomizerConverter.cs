/***********************************************************************************
* File:         RandomizerConverter.cs                                             *
* Contents:     Class RandomizerConverter                                          *
* Author:       Stacy Maimoon (stacy.maimoon@seznam.cz)                            *
* Date:         2026-09-26 20:30                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Factotum.Maths
{
	public class RandomizerConverter : JsonConverter<Randomizer>
	{
		public override Randomizer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			using JsonDocument document = JsonDocument.ParseValue(ref reader);

			JsonElement root = document.RootElement;

			DistributionType type = root.GetProperty("DistributionType").Deserialize<DistributionType>(options);

			var parameters = root.GetProperty("Parameters").Deserialize<double[]>(options) ?? [];

			return new Randomizer(type, parameters);
		}

		public override void Write(Utf8JsonWriter writer, Randomizer value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();

			writer.WritePropertyName("DistributionType");

			JsonSerializer.Serialize(writer, value.DistributionType, options);

			writer.WritePropertyName("Parameters");
			JsonSerializer.Serialize(writer, value.Parameters, options);

			if (value.DistributionType == DistributionType.Empiric)
			{
				writer.WritePropertyName("Distribution");
				JsonSerializer.Serialize(writer, value.Distribution, options);
			}

			writer.WriteEndObject();
		}
	}
}
