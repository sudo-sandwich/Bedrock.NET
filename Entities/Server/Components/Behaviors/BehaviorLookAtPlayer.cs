using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorLookAtPlayer : BehaviorLookAtBase {
        public override string Name {
            get {
                return "minecraft:behavior.look_at_player";
            }
        }
    }
}
