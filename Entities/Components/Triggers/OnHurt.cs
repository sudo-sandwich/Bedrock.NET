using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Triggers {
    class OnHurt : TriggerBase {
        public override string Name {
            get {
                return "minecraft:on_hurt";
            }
        }
    }
}