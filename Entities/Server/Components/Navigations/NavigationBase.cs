using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Navigations {
    public abstract class NavigationBase : IComponent {
        public abstract string Name { get; }

        public bool? AvoidDamageBlocks { get; set; } //not found in documentation but is present in vanilla behavior packs
        public bool? AvoidPortals { get; set; }
        public bool? AvoidSun { get; set; }
        public bool? AvoidWater { get; set; }
        public IList<string> BlocksToAvoid { get; set; } = new List<string>();
        public bool? CanBreach { get; set; }
        public bool? CanBreakDoors { get; set; }
        public bool? CanJump { get; set; }
        public bool? CanOpenDoors { get; set; }
        public bool? CanOpenIronDoors { get; set; }
        public bool? CanPassDoors { get; set; }
        public bool? CanPathFromAir { get; set; }
        public bool? CanPathOverLava { get; set; }
        public bool? CanPathOverWater { get; set; }
        public bool? CanSink { get; set; }
        public bool? CanSwim { get; set; }
        public bool? CanWalk { get; set; }
        public bool? CanWalkInLava { get; set; }
        public bool? IsAmphibious { get; set; }

        public virtual JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("avoid_damage_blocks", AvoidDamageBlocks);
            jObject.AddIfNotNull("avoid_portals", AvoidPortals);
            jObject.AddIfNotNull("avoid_sun", AvoidSun);
            jObject.AddIfNotNull("avoid_water", AvoidWater);
            if (BlocksToAvoid.Count > 0) jObject.Add("blocks_to_avoid", new JArray(BlocksToAvoid));
            jObject.AddIfNotNull("can_breach", CanBreach);
            jObject.AddIfNotNull("can_break_doors", CanBreakDoors);
            jObject.AddIfNotNull("can_jump", CanJump);
            jObject.AddIfNotNull("can_open_doors", CanOpenDoors);
            jObject.AddIfNotNull("can_open_iron_doors", CanOpenIronDoors);
            jObject.AddIfNotNull("can_pass_doors", CanPassDoors);
            jObject.AddIfNotNull("can_path_from_air", CanPathFromAir);
            jObject.AddIfNotNull("can_path_over_lava", CanPathOverLava);
            jObject.AddIfNotNull("can_path_over_water", CanPathOverWater);
            jObject.AddIfNotNull("can_sink", CanSink);
            jObject.AddIfNotNull("can_swim", CanSwim);
            jObject.AddIfNotNull("can_walk", CanWalk);
            jObject.AddIfNotNull("can_walk_in_lava", CanWalkInLava);
            jObject.AddIfNotNull("is_amphibious", IsAmphibious);

            return new JProperty(Name, jObject);
        }
    }
}
