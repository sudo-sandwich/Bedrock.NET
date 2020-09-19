using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Triggers {
    public class OnIgnite : TriggerBase {
        public override string Name {
            get {
                return "minecraft:on_ignite";
            }
        }
    }
}