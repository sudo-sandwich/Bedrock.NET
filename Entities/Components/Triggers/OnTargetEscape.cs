using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Triggers {
    public class OnTargetEscape : TriggerBase {
        public override string Name {
            get {
                return "minecraft:on_target_escape";
            }
        }
    }
}