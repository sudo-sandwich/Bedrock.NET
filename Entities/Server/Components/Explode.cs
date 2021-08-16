using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Explode : IComponent {
        public string Name {
            get {
                return "minecraft:explode";
            }
        }

        public double? FuseLength { get; set; }
        public Range<double> FuseLengthRange { get; set; }
        public double? Power { get; set; }
        public double? MaxResistance { get; set; }
        public bool? FuseLit { get; set; }
        public bool? CausesFire { get; set; }
        public bool? BreaksBlocks { get; set; }
        public bool? FireAffectedByGriefing { get; set; }
        public bool? DestroyAffectedByGriefing { get; set; }
        public bool? AllowDamageUnderwater { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("fuse_length", FuseLength);
            jObject.AddIfNotNull("fuse_length", FuseLengthRange); // this line will throw an exception is FuseLength is also defined, should only ever define one of the two
            jObject.AddIfNotNull("power", Power);
            jObject.AddIfNotNull("max_resistance", MaxResistance);
            jObject.AddIfNotNull("fuse_lit", FuseLit);
            jObject.AddIfNotNull("causes_fire", CausesFire);
            jObject.AddIfNotNull("breaks_blocks", BreaksBlocks);
            jObject.AddIfNotNull("fire_affected_by_griefing", FireAffectedByGriefing);
            jObject.AddIfNotNull("destroy_affected_by_griefing", DestroyAffectedByGriefing);
            jObject.AddIfNotNull("allow_damage_underwater", AllowDamageUnderwater);

            return new JProperty(Name, jObject);
        }
    }
}
