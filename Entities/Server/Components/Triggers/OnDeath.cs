using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Triggers {
    public class OnDeath : TriggerBase {
        public override string Name { 
            get {
                return "minecraft:on_death";
            } 
        }
    }
}
