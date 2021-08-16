using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Triggers {
    public class OnWakeWithOwner : TriggerBase {
        public override string Name {
            get {
                return "minecraft:on_wake_with_owner";
            }
        }
    }
}