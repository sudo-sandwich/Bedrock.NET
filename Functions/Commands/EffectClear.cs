using Bedrock.Functions.Commands;
using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class EffectClear : Command {
        public TargetSelector Target { get; private set; }

        public EffectClear(TargetSelector target) {
            Target = target;
        }

        public override string ToString() {
            return CommandHelper.Build("effect", Target, "clear");
        }
    }
}
