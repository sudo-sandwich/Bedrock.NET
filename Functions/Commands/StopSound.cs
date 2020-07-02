using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class StopSound : Command {
        public TargetSelector Target { get; private set; }
        public string Sound { get; private set; }

        public StopSound(TargetSelector target, string sound) {
            Target = target;
            Sound = sound;
        }

        public override string ToString() {
            return CommandHelper.Build("stopsound", Target, Sound);
        }
    }
}
