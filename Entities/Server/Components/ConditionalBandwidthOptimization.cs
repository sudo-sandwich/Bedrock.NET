using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class ConditionalBandwidthOptimization : IComponent {
        public string Name => "minecraft:conditional_bandwidth_optimization";

        public JProperty Generate() {
            return new JProperty(Name, new JObject());
        }
    }
}
