﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Movements {
    public class MovementGeneric : MovementBase {
        public override string Name {
            get {
                return "minecraft:movement.generic";
            }
        }
    }
}
