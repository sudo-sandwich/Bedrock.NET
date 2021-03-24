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
        public string OnInsideRangeEvent { get; set; }
        public string OnInsideRangeTarget { get; set; }
        public string OnOutsideRangeEvent { get; set; }
        public string OnOutsideRangeTarget { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("inside_range", InsideRange);
            jObject.AddIfNotNull("outside_range", OutsideRange);

            if (OnInsideRangeEvent != null) {
                JObject insideRange = new JObject() {
                    { "event", OnInsideRangeEvent }
                };
                insideRange.AddIfNotNull("target", OnInsideRangeTarget);

                jObject.Add(new JProperty("on_inside_range", insideRange));
            }

            if (OnOutsideRangeEvent != null) {
                JObject outsideRange = new JObject() {
                    { "event", OnOutsideRangeEvent }
                };
                outsideRange.AddIfNotNull("target", OnOutsideRangeTarget);

                jObject.Add(new JProperty("on_outside_range", outsideRange));
            }

            return new JProperty(Name, jObject);
        }
    }
}
