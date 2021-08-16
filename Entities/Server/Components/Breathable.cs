using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Breathable : IComponent {
        public string Name {
            get {
                return "minecraft:breathable";
            }
        }

        public int? TotalSupply { get; set; }
        public int? SuffocateTime { get; set; }
        public double? InhaleTime { get; set; }
        public bool? BreathesAir { get; set; }
        public bool? BreathesWater { get; set; }
        public bool? BreathesLava { get; set; }
        public bool? BreathesSolids { get; set; }
        public bool? GeneratesBubbles { get; set; }
        public string[] BreatheBlocks { get; set; }
        public string[] NonBreatheBlocks { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("total_supply", TotalSupply);
            jObject.AddIfNotNull("suffocate_time", SuffocateTime);
            jObject.AddIfNotNull("inhale_time", InhaleTime);
            jObject.AddIfNotNull("breathes_air", BreathesAir);
            jObject.AddIfNotNull("breathes_water", BreathesWater);
            jObject.AddIfNotNull("breathes_lava", BreathesLava);
            jObject.AddIfNotNull("breathes_solids", BreathesSolids);
            jObject.AddIfNotNull("generates_bubbles", GeneratesBubbles);
            if (BreatheBlocks != null && BreatheBlocks.Length > 0) jObject.Add("breathe_blocks", new JArray(BreatheBlocks));
            if (NonBreatheBlocks != null && NonBreatheBlocks.Length > 0) jObject.Add("non_breathe_blocks", new JArray(NonBreatheBlocks));

            return new JProperty(Name, jObject);
        }
    }
}
