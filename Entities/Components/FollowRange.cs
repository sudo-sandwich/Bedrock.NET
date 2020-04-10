using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class FollowRange : IComponent {
        public string Name {
            get {
                return "minecraft:follow_range";
            }
        }

        public double? Value { get; set; }
        public double? Max { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("value", Value);
            jObject.AddIfNotNull("max", Max);

            return new JProperty(Name, jObject);
        }
    }
}
