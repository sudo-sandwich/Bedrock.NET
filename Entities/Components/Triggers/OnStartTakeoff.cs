using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Triggers {
    public class OnStartTakeoff : TriggerBase {
        public override string Name {
            get {
                return "minecraft:on_start_takeoff";
            }
        }
    }
}