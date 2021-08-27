using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class CameraShakeStop : Command {
        public TargetSelector Target { get; private set; }

        public CameraShakeStop(TargetSelector target) {
            Target = target;
        }

        public override string ToString() => CommandHelper.Build("camerashake", "stop", Target);
    }
}
