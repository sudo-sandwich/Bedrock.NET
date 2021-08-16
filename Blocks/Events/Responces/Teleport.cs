using Bedrock.Entities.Server.Components.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class Teleport : BlockEventResponse
    {
        public bool? AvoidWater { get; set; }
#pragma warning disable CA1819 // Properties should not return arrays
        public float?[] Destination { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
        public bool? LandOnBlock { get; set; }
#pragma warning disable CA1819 // Properties should not return arrays
        public float?[] MaxRange { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
        public FilterTest Target { get; set; }

        public Teleport()
        {
            Name = "teleport";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (AvoidWater != null) jObject.Add("avoid_water", AvoidWater);
            if (Destination != null) jObject.Add("destination", new JArray(Destination));
            if (LandOnBlock != null) jObject.Add("land_on_block", LandOnBlock);
            if (MaxRange != null) jObject.Add("max_range", new JArray(MaxRange));
            if (Target != null) jObject.Add("target", Target.ToJObject());
            return new JProperty(Name, jObject);
        }
    }
}
