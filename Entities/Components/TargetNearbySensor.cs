using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class TargetNearbySensor : IComponent {
        public string Name {
            get {
                return "minecraft:target_nearby_sensor";
            }
        }

        public double? InsideRange { get; set; }
        public double? OutsideRange { get; set; }
        public EntityEvent OnInsideRange { get; set; }
        public EntityEvent OnOutsideRange { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("inside_range", InsideRange);
            jObject.AddIfNotNull("outside_range", OutsideRange);
            jObject.AddIfNotNull("on_inside_range", OnInsideRange?.Name);
            jObject.AddIfNotNull("on_outside_range", OnOutsideRange?.Name);

            return new JProperty(Name, jObject);
        }
    }
}
