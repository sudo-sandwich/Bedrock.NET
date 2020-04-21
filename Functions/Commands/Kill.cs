using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Kill : Command {
        public TargetSelector Target { get; private set; }

        public Kill(TargetSelector target) {
            Target = target;
        }

        public override string ToString() {
            return CommandHelper.Build("kill", Target);
        }
    }
}
