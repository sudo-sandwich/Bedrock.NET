using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Player {
    public class PlayerLevel : PlayerBase {
        public override string Name {
            get {
                return "minecraft:player.level";
            }
        }
    }
}
