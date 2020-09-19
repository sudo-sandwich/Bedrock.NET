using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Triggers {
    public class OnTargetAcquired : TriggerBase {
        public override string Name {
            get {
                return "minecraft:on_target_acquired";
            }
        }
    }
}