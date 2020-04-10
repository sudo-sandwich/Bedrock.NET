using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Player {
    public class PlayerExperience : PlayerBase {
        public override string Name {
            get {
                return "minecraft:player.experience";
            }
        }
    }
}
