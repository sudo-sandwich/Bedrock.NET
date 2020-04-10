using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class TitleReset : Command {
        public TargetSelector Selector { get; private set; }

        public TitleReset(TargetSelector selector) {
            Selector = selector;
        }

        public override string ToString() {
            return CommandHelper.Build("title", Selector, "reset");
        }
    }
}
