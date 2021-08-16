using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Movements {
    public class MovementFly : MovementBase {
        public override string Name {
            get {
                return "minecraft:movement.fly";
            }
        }
    }
}
