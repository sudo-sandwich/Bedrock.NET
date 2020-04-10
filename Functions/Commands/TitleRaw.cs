using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class TitleRaw : Command {
        public TargetSelector Target { get; private set; }
        public TitleType Type { get; private set; }
        public RawText Text { get; private set; }

        public TitleRaw(TargetSelector target, TitleType type, RawText text) {
            Target = target;
            Type = type;
            Text = text;
        }

        public override string ToString() {
            return CommandHelper.Build("titleraw", Target, Type.GetDescription(), Text);
        }
    }
}
