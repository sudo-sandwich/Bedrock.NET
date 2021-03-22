using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Navigation {
    public class NavigationHover : NavigationBase {
        public override string Name {
            get {
                return "minecraft:navigation.hover";
            }
        }

        public bool? CanPathFromAir { get; set; }

        public override JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("avoid_damage_blocks", AvoidDamageBlocks);
            jObject.AddIfNotNull("avoid_portals", AvoidPortals);
            jObject.AddIfNotNull("avoid_sun", AvoidSun);
            jObject.AddIfNotNull("avoid_water", AvoidWater);
            jObject.AddIfNotNull("can_break_doors", CanBreakDoors);
            jObject.AddIfNotNull("can_open_doors", CanOpenDoors);
            jObject.AddIfNotNull("can_pass_doors", CanPassDoors);
            jObject.AddIfNotNull("can_path_over_water", CanPathOverWater);
            jObject.AddIfNotNull("can_path_from_air", CanPathFromAir);
            jObject.AddIfNotNull("can_sink", CanSink);

            return new JProperty(Name, jObject);
        }
    }
}
