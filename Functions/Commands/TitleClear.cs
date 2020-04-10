using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class TitleClear : Command {
        public TargetSelector Selector { get; private set; }

        public TitleClear(TargetSelector selector) {
            Selector = selector;
        }

        public override string ToString() {
            return CommandHelper.Build("title", Selector, "clear");
        }
    }
}
