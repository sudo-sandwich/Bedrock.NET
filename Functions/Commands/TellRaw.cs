using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class TellRaw : Command {
        public TargetSelector Target { get; private set; }
        public RawText Text { get; private set; }

        public TellRaw(TargetSelector target, RawText text) {
            Target = target;
            Text = text;
        }

        public override string ToString() {
            return CommandHelper.Build("tellraw", Target, Text);
        }
    }
}
