using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Movements {
    public class MovementSkip : MovementBase {
        public override string Name {
            get {
                return "minecraft:movement.skip";
            }
        }
    }
}
