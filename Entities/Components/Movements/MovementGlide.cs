using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Movements {
    public class MovementGlide : MovementBase {
        public override string Name => "minecraft:movement.glide";

        public double? StartSpeed { get; set; }
        public double? SpeedWhenTurning { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("max_turn", MaxTurn);
            jObject.AddIfNotNull("start_speed", StartSpeed);
            jObject.AddIfNotNull("speed_when_turning", SpeedWhenTurning);

            return new JProperty(Name, jObject);
        }
    }
}
