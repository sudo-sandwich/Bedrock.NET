using System;
using System.Collections.Generic;
using System.Text;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;

namespace Bedrock.Entities.Components.Movements {
    public class MovementJump : MovementBase {
        public override string Name {
            get {
                return "minecraft:movement.jump";
            }
        }

        public Range<double> JumpDelay { get; set; }

        public override JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("max_turn", MaxTurn);
            jObject.AddIfNotNull("jump_delay", JumpDelay);

            return new JProperty(Name, jObject);
        }
    }
}
