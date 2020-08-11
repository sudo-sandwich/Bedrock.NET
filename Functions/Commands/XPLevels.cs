using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class XPLevels : Command {
        public int Amount { get; private set; }
        public TargetSelector Target { get; private set; }

        public XPLevels(int amount, TargetSelector target) {
            Amount = amount;
            Target = target;
        }

        public override string ToString() {
            return CommandHelper.Build("xp", Amount + "L", Target);
        }
    }
}
