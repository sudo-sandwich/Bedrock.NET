using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Navigation {
    public abstract class NavigationBase : IComponent {
        public abstract string Name { get; }

        public bool? AvoidDamageBlocks { get; set; } //not found in documentation but is present in vanilla behavior packs
        public bool? AvoidPortals { get; set; }
        public bool? AvoidSun { get; set; }
        public bool? AvoidWater { get; set; }
        public bool? CanBreakDoors { get; set; }
        public bool? CanOpenDoors { get; set; }
        public bool? CanPassDoors { get; set; }
        public bool? CanPathOverWater { get; set; }
        public bool? CanSink { get; set; }

        public virtual JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("avoid_damage_blocks", AvoidDamageBlocks);
            jObject.AddIfNotNull("avoid_portals", AvoidPortals);
            jObject.AddIfNotNull("avoid_sun", AvoidSun);
            jObject.AddIfNotNull("avoid_water", AvoidWater);
            jObject.AddIfNotNull("can_break_doors", CanBreakDoors);
            jObject.AddIfNotNull("can_open_doors", CanOpenDoors);
            jObject.AddIfNotNull("can_pass_doors", CanPassDoors);
            jObject.AddIfNotNull("can_path_over_water", CanPathOverWater);
            jObject.AddIfNotNull("can_sink", CanSink);

            return new JProperty(Name, jObject);
        }
    }
}
