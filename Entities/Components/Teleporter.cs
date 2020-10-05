using Bedrock.Functions;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    // class name is "Teleporter" instead of "Teleport" because it would conflict with the teleport command
    public class Teleporter : IComponent {
        public string Name => "minecraft:teleport";

        public double? DarkTeleportChance { get; set; }
        public double? LightTeleportChance { get; set; }
        public double? MaxRandomTeleportTime { get; set; }
        public double? MinRandomTeleportTime { get; set; }
        public Vector3? RandomTeleportCube { get; set; }
        public bool? RandomTeleports { get; set; }
        public double? TargetDistance { get; set; }
        public double? TargetTeleportChance { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("dark_teleport_chance", DarkTeleportChance);
            jObject.AddIfNotNull("light_teleport_chance", LightTeleportChance);
            jObject.AddIfNotNull("max_random_teleport_time", MaxRandomTeleportTime);
            jObject.AddIfNotNull("min_random_teleport_time", MinRandomTeleportTime);
            jObject.AddIfNotNull("random_teleport_cube", RandomTeleportCube?.ToJArray());
            jObject.AddIfNotNull("random_teleports", RandomTeleports);
            jObject.AddIfNotNull("target_distance", TargetDistance);
            jObject.AddIfNotNull("target_teleport_chance", TargetTeleportChance);

            return new JProperty(Name, jObject);
        }
    }
}
