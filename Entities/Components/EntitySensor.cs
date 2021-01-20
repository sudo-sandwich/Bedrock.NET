using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class EntitySensor : IComponent {
        public string Name => "minecraft:entity_sensor";

        public Filter Filters { get; set; }
        public string Event { get; set; }
        public int? MaxCount { get; set; }
        public int? MinCount { get; set; }
        public bool? RelativeRange { get; set; }
        public bool? RequireAll { get; set; }
        public double? SensorRange { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("event_filters", Filters);
            jObject.AddIfNotNull("event", Event);
            jObject.AddIfNotNull("maximum_count", MaxCount);
            jObject.AddIfNotNull("minimum_count", MinCount);
            jObject.AddIfNotNull("relative_range", RelativeRange);
            jObject.AddIfNotNull("require_all", RequireAll);
            jObject.AddIfNotNull("sensor_range", SensorRange);

            return new JProperty(Name, jObject);
        }
    }
}
