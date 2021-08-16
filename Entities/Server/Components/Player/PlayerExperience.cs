using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Player {
    public class PlayerExperience : PlayerBase {
        public override string Name {
            get {
                return "minecraft:player.experience";
            }
        }
    }
}
